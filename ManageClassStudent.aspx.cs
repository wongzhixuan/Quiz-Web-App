using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Quiz_Web_App
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt;
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie reqCookie = Request.Cookies["classInfo"];
                if (reqCookie != null)
                {
                    ViewState["classID"] = int.Parse(reqCookie["classId"].ToString());
                }
                getStudentData();
                SuccessMessage.Visible = false;
                ErrorMessage.Visible = false;
                btn_checkStudent.Enabled = true;
                add_student.Enabled = false;
                tx_student_id.Enabled = true;
            }
        }

        private void getStudentData()
        {
            if (ViewState["classID"] != null)
            {
                int class_id = int.Parse(ViewState["classID"].ToString());
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ViewStudentListByClass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    ViewState["Paging"] = dataTable;
                    student_view.DataSource = dataTable;
                    student_view.DataBind();
                    con.Close();
                }
            }
        }

        protected void student_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(student_view.DataKeys[e.RowIndex].Values["student_id"].ToString());
            student_delete(id);
            
            getStudentData();
        }

        private void student_delete(int id)
        {
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand("DeleteStudentFromClass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@student_id", id);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                SuccessMessage.Text = "";
                ErrorMessage.Visible = false;
                SuccessMessage.Text = "Your Student is Deleted Successfully";
                SuccessMessage.Visible = true;
            }
            else
            {
                ErrorMessage.Text = "";
                SuccessMessage.Visible = false;
                ErrorMessage.Text = "Student Delete Failed";
                ErrorMessage.Visible = true;
            }
        }

        protected void add_student_Click(object sender, EventArgs e)
        {
            if (ViewState["classID"] != null)
            {
                int class_id = int.Parse(ViewState["classID"].ToString());
                int student_id = int.Parse(tx_student_id.Text);
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    SqlCommand cmd = new SqlCommand("CheckStudentClass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("class_id", class_id);
                    cmd.Parameters.AddWithValue("student_id", student_id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    if(dataTable.Rows.Count > 0)
                    {
                        ErrorMessage.Text = "";
                        ErrorMessage.Text = "Student already existed in class";
                        ErrorMessage.Visible = true;
                        SuccessMessage.Visible = false;
                    }
                    else
                    {
                        SqlCommand cmd_add = new SqlCommand("LinkStudentToClass", con);
                        cmd_add.CommandType = CommandType.StoredProcedure;
                        cmd_add.Parameters.AddWithValue("@class_id", class_id);
                        cmd_add.Parameters.AddWithValue("@student_id", student_id);
                        con.Open();
                        int count = int.Parse(cmd_add.ExecuteNonQuery().ToString());
                        con.Close();
                        if(count > 0)
                        {
                            SuccessMessage.Text = "";
                            ErrorMessage.Visible = false;
                            SuccessMessage.Visible = true;
                            SuccessMessage.Text = "Student (id: " + student_id + ") added to class !";
                        }
                        else
                        {
                            ErrorMessage.Text = "";
                            ErrorMessage.Text = "Failed to add student.";
                            ErrorMessage.Visible = true;
                            SuccessMessage.Visible = false;
                        }
                    
                    }


                }
                getStudentData();
                btn_checkStudent.Enabled = true;
                add_student.Enabled = false;
                tx_student_id.Enabled = true;
            }
            
        }

        protected void btn_checkStudent_Click(object sender, EventArgs e)
        {
            int student_id = int.Parse(tx_student_id.Text);
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ViewStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_id", student_id);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                ViewState["currentStudent"] = (DataTable)dataTable;
                student_data_list.DataSource = dataTable;
                student_data_list.DataBind();
                con.Close();
                if(dataTable.Rows.Count > 0)
                {
                    btn_checkStudent.Enabled = false;
                    add_student.Enabled = true;
                    tx_student_id.Enabled = false;
                }
                else
                {
                    tx_student_id.Text = "";
                    ErrorMessage.Text = "";
                    ErrorMessage.Visible = true;
                    ErrorMessage.Text = "This is not a valid student id.";
                    SuccessMessage.Visible = false;

                }
            }
        }
        public SortDirection CurrentSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["sortDirection"];
            }
            set
            {
                ViewState["sortDirection"] = value;
            }
        }
        protected void student_view_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Read column name
            string ColumnTosort = e.SortExpression;

            // Sort in Descending
            if (CurrentSortDirection == SortDirection.Ascending)
            {
                CurrentSortDirection = SortDirection.Descending;
                SortGridView(ColumnTosort, DESCENDING);
            }
            // Sort in Ascending 
            else
            {
                CurrentSortDirection = SortDirection.Ascending;
                SortGridView(ColumnTosort, ASCENDING);
            }
        }
        private void SortGridView(string sortExpression, string direction)
        {

            //  You can cache the DataTable for improving performance    
            dynamic dt = ViewState["Paging"];
            DataTable dtsort = dt;
            DataView dv = new DataView(dtsort);
            dv.Sort = sortExpression + direction;

            student_view.DataSource = dv;
            student_view.DataBind();
        }

        protected void student_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            student_view.PageIndex = e.NewPageIndex;
            student_view.DataSource = ViewState["Paging"];
            student_view.DataBind();
        }
    }
}