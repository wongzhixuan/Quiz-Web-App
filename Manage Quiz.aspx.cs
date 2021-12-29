using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

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
            int id = int.Parse(quiz_view.DataKeys[e.RowIndex].Values["QuizID"].ToString());
            if (checkDeletePermission(id))
            {
                quiz_delete(id);
            }
            else
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Cannot delete selected rows as there are something depending on it!";
            }
            
            getData();
        }

        private bool checkDeletePermission(int id)
        {
            bool canDelete = true;
            ArrayList quizList = new ArrayList();
            using (SqlConnection sqlcon = new SqlConnection(connection_string))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("SELECT Quiz_id FROM Quiz_question GROUP BY Quiz_id", sqlcon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlcon.Close();
                
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    quizList.Add(dataTable.Rows[i]["Quiz_id"].ToString());
                }
                foreach (String item in quizList)
                {
                    if (int.Parse(item) == id)
                    {
                        canDelete = false;
                    }

                }

            }
            return canDelete;
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
                ErrorMessage.Visible = false;
                SuccessMessage.Text = "Your Quiz is Deleted Successfully";
                SuccessMessage.Visible = true;
            }
            else
            {
                ErrorMessage.Text = "Quiz Delete Failed";
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
            quiz_view.EditIndex = e.NewEditIndex;
            getData();
        }

        protected void quiz_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            quiz_view.EditIndex = -1;
            getData();
        }

        protected void quiz_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txttitle = quiz_view.Rows[e.RowIndex].FindControl("txt_title") as TextBox;
            TextBox txtdescrip = quiz_view.Rows[e.RowIndex].FindControl("txt_descrip") as TextBox;
            TextBox txtscore = quiz_view.Rows[e.RowIndex].FindControl("txt_score") as TextBox;
            TextBox txtstart = quiz_view.Rows[e.RowIndex].FindControl("txt_start") as TextBox;
            TextBox txtend = quiz_view.Rows[e.RowIndex].FindControl("txt_finish") as TextBox;

            int id = int.Parse(quiz_view.DataKeys[e.RowIndex].Values["QuizID"].ToString()); 

            // validate input before updating
            if(validateInputs(txttitle.Text, txtscore.Text, txtstart.Text, txtend.Text))
            quiz_update(id, txttitle.Text.ToString(), txtdescrip.Text.ToString(), txtscore.Text.ToString(), txtstart.Text, txtend.Text);
            quiz_view.EditIndex = -1;
            getData();
        }
        private bool validateInputs(string txt_title, string txt_score, string txt_startDate, string txt_endDate)
        {
            // Important fields cannot be empty
            if (txt_title == "")
            {
                ErrorMessage.Text = "Quiz Title should not be empty";
                ErrorMessage.Visible = true;
                return false;
            }
            else if (txt_score == "")
            {
                ErrorMessage.Text = "Quiz Score should not be empty";
                ErrorMessage.Visible = true;
                return false;
            }
            else if (txt_startDate == "")
            {
                ErrorMessage.Text = "Start Date should be specified";
                ErrorMessage.Visible = true;
                return false;

            }
            else if (txt_endDate == "")
            {
                ErrorMessage.Text = "End Date should be specified";
                ErrorMessage.Visible = true;
                return false;
            }
            
            // The score should be in positive integer and not 0
            else if (int.Parse(txt_score) <= 0)
            {
                ErrorMessage.Text = "The Score should be greater than 0.";
                ErrorMessage.Visible = true;
                return false;
            }
            // the start date should be after the current time
            else if (DateTime.Parse(txt_startDate) < DateTime.Now)
            {
                ErrorMessage.Text = "The start time should not be set to past time.";
                ErrorMessage.Visible = true;
                return false;
            }
            // the end date should be at least 10 min after start date
            else if (DateTime.Parse(txt_endDate) < DateTime.Parse(txt_startDate).AddMinutes(10))
            {
                ErrorMessage.Text = "The end time should be at least 10 mins after start date.";
                ErrorMessage.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void quiz_update(int id, string text1, string text2, string text3, string text4, string text5)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {

                SqlCommand sqlCommand = new SqlCommand("UpdateQuiz", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuizID" , id);
                sqlCommand.Parameters.AddWithValue("@Title", text1);
                sqlCommand.Parameters.AddWithValue("@Description", text2);
                sqlCommand.Parameters.AddWithValue("@Score", int.Parse(text3));
                sqlCommand.Parameters.AddWithValue("@StartedDate", DateTime.Parse(text4));
                sqlCommand.Parameters.AddWithValue("@FinishedDate", DateTime.Parse(text5));
                
                sqlConnection.Open();
                int count = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (count > 0)
                {
                    ErrorMessage.Visible = false;
                    SuccessMessage.Text = "Your Quiz is Updated Successfully";
                    SuccessMessage.Visible = true;
                }
                else
                {
                    ErrorMessage.Text = "Quiz Update Failed";
                    ErrorMessage.Visible = true;
                }
            }
        }

        protected void quiz_view_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HttpCookie quizCookie = new HttpCookie("quizInfo");
            quizCookie["quizID"] = quiz_view.DataKeys[e.NewSelectedIndex].Values["QuizID"].ToString();
            Response.Cookies.Add(quizCookie);
            Response.Redirect("EditQuiz.aspx");
        }
    }
}