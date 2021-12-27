using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Quiz_Web_App
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        DataTable dt;
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getData();
                Response.Cookies.Clear();
                Response.Cookies.Remove("quizInfo");
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;
            }
        }

        private void getData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("ViewQuizes", sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CreatorId", Session["CardID"]);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                ViewState["Paging"] = dataTable;
                quiz_view.DataSource = dataTable;
                quiz_view.DataBind();
                sqlConnection.Close();
            }
        }

        protected void createQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateQuiz.aspx");
        }

        protected void quiz_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(quiz_view.DataKeys[e.RowIndex].Values["QuizID"].ToString());
            quiz_delete(id);
            getData();
        }

        private void quiz_delete(int id)
        {
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand("DeleteQuiz", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuizID", id);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                SuccessMessage.Text = "Your Quiz is Deleted Successfully";
                SuccessMessage.Visible = true;
            }
            else
            {
                ErrorMessage.Text = "Class Quiz Failed";
                ErrorMessage.Visible = true;
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

        protected void quiz_view_Sorting(object sender, GridViewSortEventArgs e)
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

            quiz_view.DataSource = dv;
            quiz_view.DataBind();
        }

        protected void quiz_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            quiz_view.PageIndex = e.NewPageIndex;
            quiz_view.DataSource = ViewState["Paging"];
            quiz_view.DataBind();
        }

        protected void quiz_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            HttpCookie quizCookie = new HttpCookie("quizInfo");
            quizCookie["quizID"] = e.NewEditIndex.ToString();
            Response.Cookies.Add(quizCookie);
            Response.Redirect("EditQuiz.aspx");
        }
    }
}