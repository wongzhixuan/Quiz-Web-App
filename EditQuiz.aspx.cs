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
    public partial class WebForm6 : System.Web.UI.Page
    {
        DataTable dt;
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        string connection_string = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                HttpCookie quizcookie = Request.Cookies["quizInfo"];
                if (quizcookie != null)
                {
                    ViewState["quizID"] = int.Parse(quizcookie["quizID"].ToString());
                }
                getData();
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;

            }
        }

        private void getData()
        {
            if (ViewState["quizID"] != null)
            {
                int quizID = int.Parse(ViewState["quizID"].ToString());
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("ViewQuizDetails", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Quiz_id", quizID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    ViewState["Paging"] = dataTable;
                    question_view.DataSource = dataTable;
                    question_view.DataBind();
                    sqlConnection.Close();
                }
                
            }
            else
            {
                Response.Write("quizID is null");
            }
        }


        protected void question_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(question_view.DataKeys[e.RowIndex].Values["Ques_id"].ToString());

            question_delete(id);

            getData();
        }

        private void question_delete(int id)
        {
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand("DeleteQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ques_id", id);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                ErrorMessage.Visible = false;
                SuccessMessage.Text = "Your Question is Deleted Successfully";
                SuccessMessage.Visible = true;
            }
            else
            {
                SuccessMessage.Visible = false;

                ErrorMessage.Text = "Question Delete Failed";
                ErrorMessage.Visible = true;
            }
        }

        protected void question_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Paging"];
            question_view.EditIndex = e.NewEditIndex;
            
            getData();
            DropDownList ddlAns = question_view.Rows[e.NewEditIndex].FindControl("dropdown_answer") as DropDownList;

            ddlAns.Items.FindByValue(dt.Rows[e.NewEditIndex]["AnsId"].ToString()).Selected = true;
        }

        protected void question_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txttitle = question_view.Rows[e.RowIndex].FindControl("txbox_title") as TextBox;
            TextBox txtscore = question_view.Rows[e.RowIndex].FindControl("txbox_score") as TextBox;
            TextBox txtop1 = question_view.Rows[e.RowIndex].FindControl("txbox_op1") as TextBox;
            TextBox txtop2 = question_view.Rows[e.RowIndex].FindControl("txbox_op2") as TextBox;
            TextBox txtop3 = question_view.Rows[e.RowIndex].FindControl("txbox_op3") as TextBox;
            TextBox txtop4 = question_view.Rows[e.RowIndex].FindControl("txbox_op4") as TextBox;
            DropDownList ddans = question_view.Rows[e.RowIndex].FindControl("dropdown_answer") as DropDownList;


            int id = int.Parse(question_view.DataKeys[e.RowIndex].Values["Ques_id"].ToString()); 
            // haven't validate input before update


            question_update(id, txttitle.Text.ToString(), txtscore.Text, txtop1.Text, txtop2.Text, txtop3.Text, txtop4.Text,ddans.SelectedValue);


            question_view.EditIndex = -1;
            getData();
        }

        private void question_update(int id, string v, string text1, string text2, string text3, string text4, string text5, string selectedValue)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {

                SqlCommand sqlCommand = new SqlCommand("UpdateQuestion", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Ques_id", id);
                sqlCommand.Parameters.AddWithValue("@Title", v);
                sqlCommand.Parameters.AddWithValue("@Score", int.Parse(text1));
                sqlCommand.Parameters.AddWithValue("@Option1", text2);
                sqlCommand.Parameters.AddWithValue("@Option2", text3);
                sqlCommand.Parameters.AddWithValue("@Option3", text4);
                sqlCommand.Parameters.AddWithValue("@Option4", text5);
                sqlCommand.Parameters.AddWithValue("@AnsId", int.Parse(selectedValue));

                sqlConnection.Open();
                int count = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (count > 0)
                {
                    ErrorMessage.Visible = false;
                    SuccessMessage.Text = "Your Question is Updated Successfully";
                    SuccessMessage.Visible = true;
                }
                else
                {
                    SuccessMessage.Visible = false;
                    ErrorMessage.Text = "Question Update Failed";
                    ErrorMessage.Visible = true;
                }
            }
        }

        protected void question_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            question_view.EditIndex = -1;
            getData();
        }

        // Sorting Function
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
        protected void question_view_Sorting(object sender, GridViewSortEventArgs e)
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

            question_view.DataSource = dv;
            question_view.DataBind();
        }

        // Changing page
        protected void question_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            question_view.PageIndex = e.NewPageIndex;
            question_view.DataSource = ViewState["Paging"];
            question_view.DataBind();
        }


        // add new question
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (validateInputs() && ViewState["quizID"] != null)
            {
                
                string title = add_title.Text.ToString();
                int score = int.Parse(add_score.Text.ToString());
                string option1 = add_op1.Text.ToString();
                string option2 = add_op2.Text.ToString();
                string option3 = add_op3.Text.ToString();
                string option4 = add_op4.Text.ToString();
                int answer = int.Parse(add_answer.SelectedValue.ToString());
                int ques_id = 0;
                int count = 0;
                bool isSuccessful = false;

                using (SqlConnection con = new SqlConnection(connection_string ))
                {
                    
                    SqlCommand cmd = new SqlCommand("InsertQuestions", con);
                    int quizID = int.Parse(ViewState["quizID"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Quiz_id", quizID);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Score", score);
                    con.Open();
                    ques_id = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if (ques_id > 0)
                    {
                        SqlCommand cmdOption = new SqlCommand("InsertOptions", con);
                        cmdOption.CommandType = CommandType.StoredProcedure;
                        cmdOption.Parameters.AddWithValue("@Ques_id", ques_id);
                        cmdOption.Parameters.AddWithValue("@Option1", option1);
                        cmdOption.Parameters.AddWithValue("@Option2", option2);
                        cmdOption.Parameters.AddWithValue("@Option3", option3);
                        cmdOption.Parameters.AddWithValue("@Option4", option4);
                        con.Open();
                        count = cmdOption.ExecuteNonQuery();
                        con.Close();
                        if(count > 0)
                        {
                            isSuccessful = true;
                        }
                        
                        SqlCommand cmdAns = new SqlCommand("InsertAnswer", con);
                        cmdAns.CommandType = CommandType.StoredProcedure;
                        cmdAns.Parameters.AddWithValue("@QuesId", ques_id);
                        cmdAns.Parameters.AddWithValue("@AnsId", answer);
                        con.Open();
                        count = cmdAns.ExecuteNonQuery();
                        con.Close();
                        if(count > 0)
                        {
                            isSuccessful = isSuccessful & true;
                        }
                        else
                        {
                            isSuccessful = isSuccessful & false;
                        }
                        if (isSuccessful)
                        {
                            ErrorMessage.Visible = false;
                            SuccessMessage.Visible = true;
                            SuccessMessage.Text = "You have successfully add a new question!";
                        }
                        else
                        {
                            ErrorMessage.Visible = true;
                            SuccessMessage.Visible = false;
                            ErrorMessage.Text = "Error! Question add failed!";
                        }
                        getData();

                    }




                }
            }
        }

        private bool validateInputs()
        {
            if(add_answer.SelectedValue == "-1" || add_title.Text == "" || add_score.Text == "" || add_op1.Text == "" ||add_op2.Text=="" || add_op3.Text == "" || add_op4.Text == "")
            {
                addErrorMessage("Please fill in all fields!");
                return false;
            }
            else if(int.Parse(add_score.Text.ToString()) <= 0)
            {
                addErrorMessage("Please assign some marks for the question (>0)");
                return false;
            }
            return true;
        }

        private void addSuccessMsg(string message)
        {
            ErrorMessage.Visible = false;
            SuccessMessage.Text = message;
            SuccessMessage.Visible = true;
        }
        private void addErrorMessage(string message)
        {
            ErrorMessage.Visible = true;
            ErrorMessage.Text = message;
            SuccessMessage.Visible = false;
        }

        
    }
}