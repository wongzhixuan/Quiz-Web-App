using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Quiz_Web_App
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataTable dt;
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        string connection_string = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getData();
                
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;
            }
        }
        public void getData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("ViewClasses", sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@teacher_id", Session["CardID"]);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                ViewState["Paging"] = dataTable;
                class_view.DataSource = dataTable;
                class_view.DataBind();
                sqlConnection.Close();
            }
        }
        private void class_update(string text1, string text2, int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                
                SqlCommand sqlCommand = new SqlCommand("UpdateClass", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@class_id", id);
                sqlCommand.Parameters.AddWithValue("@class_name", text1);
                sqlCommand.Parameters.AddWithValue("@class_description", text2);
                DateTime date = DateTime.Now;
                sqlCommand.Parameters.AddWithValue("@created_date", date);
                sqlConnection.Open();
                int count = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (count > 0)
                {
                    ErrorMessage.Visible = false;
                    SuccessMessage.Text = "Your Class is Updated Successfully";
                    SuccessMessage.Visible = true;
                }
                else
                {
                    SuccessMessage.Visible = false;
                    ErrorMessage.Text = "Class Update Failed";
                    ErrorMessage.Visible = true;
                }
            }
            
        }

        protected void class_delete(int id)
        {
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand("DeleteClass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@class_id", id);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                ErrorMessage.Visible = false;
                SuccessMessage.Text = "Your Class is Deleted Successfully";
                SuccessMessage.Visible = true;
            }
            else
            {
                SuccessMessage.Visible = false;
                ErrorMessage.Text = "Class Delete Failed";
                ErrorMessage.Visible = true;
            }
        }

        protected void createClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClass.aspx");
        }

        protected void class_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            class_view.EditIndex = -1;
            getData();
        }

        protected void class_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtname = class_view.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox txtdescrip = class_view.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;

            int id = Convert.ToInt16(class_view.DataKeys[e.RowIndex].Values["class_id"].ToString());
            class_update(txtname.Text, txtdescrip.Text, id);
            class_view.EditIndex = -1;
            getData();
        }

        protected void class_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(class_view.DataKeys[e.RowIndex].Values["class_id"].ToString());
            if (checkDeletePermission(id))
            {
                class_delete(id);
            }
            else
            {
                SuccessMessage.Visible = false;
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Cannot delete selected rows as there are something depending on it!";
            }
            
            getData();
        }
        
        private bool checkDeletePermission(int id)
        {
            bool canDelete = true;
            ArrayList classList = new ArrayList();
            using (SqlConnection sqlcon = new SqlConnection(connection_string))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("SELECT ClassId FROM Quiz GROUP BY ClassId ", sqlcon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlcon.Close();
                ViewState["ClassTable"] = dataTable;
                for (int i = 0; i < dataTable.Rows.Count ; i++)
                {
                    classList.Add(dataTable.Rows[i]["ClassId"].ToString());
                }
                foreach(String item in classList)
                {
                    if(int.Parse(item) == id)
                    {
                        canDelete = false;
                    }
                    
                }
                
            }
            return canDelete;

        }

        protected void class_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            class_view.EditIndex = e.NewEditIndex;
            getData();
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
        protected void class_view_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Read column name
            string ColumnTosort = e.SortExpression;

            // Sort in Descending
            if(CurrentSortDirection == SortDirection.Ascending)
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

            class_view.DataSource = dv;
            class_view.DataBind();
        }

        protected void class_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            class_view.PageIndex = e.NewPageIndex;
            class_view.DataSource = ViewState["Paging"];
            class_view.DataBind();
        }

        protected void class_view_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HttpCookie classCookie = new HttpCookie("classInfo");
            classCookie["classId"] = class_view.DataKeys[e.NewSelectedIndex].Values["class_id"].ToString();
            Response.Cookies.Add(classCookie);
            Response.Redirect("ManageClassStudent.aspx");
        }
    }
}