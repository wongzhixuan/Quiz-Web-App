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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Cookies.Clear();
                Response.Cookies.Remove("quizInformation");
                ClearTextBox();
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;
                add_ques.Enabled = false;
                create_quiz.Enabled = true;
                ViewState["quizID"] = null;
                setInitialClass();

            }
            
        }

        private void setInitialClass()
        {

            ArrayList classList = GetClassList();
            foreach(ListItem item in classList)
            {
                dropdown_class.Items.Add(item);
            }
        }

        private ArrayList GetClassList()
        {
            ArrayList classList = new ArrayList();
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetClasses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacher_id", Session["CardID"]);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                con.Close();
                ViewState["ClassTable"] = dataTable;
                for (int i = 0; i < dataTable.Rows.Count - 1; i++)
                {
                    classList.Add(new ListItem(dataTable.Rows[i]["class_name"].ToString(), dataTable.Rows[i]["class_id"].ToString()));
                    
                }
                return classList;

            }
        }

        private void ClearTextBox()
        {
            txt_title.Text = "";
            hfQuizID.Value = "";
            txt_description.Text = txt_score.Text =  "";
            dropdown_class.SelectedValue = "-1";
            
        }

        protected void create_quiz_Click(object sender, EventArgs e)
        {
            if (Session["CardID"] != null)
            {
                if(validateInputs()){
                    String title = txt_title.Text.Trim().ToString();
                    String id = Session["CardID"].ToString();
                    int classID = Convert.ToInt32(dropdown_class.SelectedValue.ToString());
                    String descrip = txt_description.Text.Trim().ToString();
                    int score = Convert.ToInt32(txt_score.Text.Trim().ToString());
                    DateTime start_date = DateTime.Parse(txt_startDate.Text);
                    DateTime end_date = DateTime.Parse(txt_endDate.Text);
                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("CreateQuiz", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QuizID", Convert.ToInt32(hfQuizID.Value == "" ? "0" : hfQuizID.Value));
                        cmd.Parameters.AddWithValue("@CreatorId", id);
                        cmd.Parameters.AddWithValue("@ClassId", classID);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description",descrip);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@StartedDate", start_date);
                        cmd.Parameters.AddWithValue("@FinishedDate", end_date);

                        int quizID = 0;
                        quizID = Convert.ToInt32(cmd.ExecuteScalar());
                        
                        con.Close();
                        if (quizID > 0)
                        {
                            ViewState["quizID"] = quizID;
                            SuccessMessage.Text = "Your Quiz is Created Successfully. ";
                            SuccessMessage.Visible = true;
                            create_quiz.Enabled = false;
                            add_ques.Enabled = true;
                        }
                        else
                        {
                            ErrorMessage.Text = "Quiz Create Failed.";
                            ErrorMessage.Visible = true;
                        }

                    }
                }
                
            }
            
        }

        private bool validateInputs()
        {
            if(txt_title.Text.Trim() == "")
            {
                ErrorMessage.Text = "Quiz Title should not be empty";
                ErrorMessage.Visible = true;
                return false;
            }
            else if (txt_score.Text.Trim() == "")
            {
                ErrorMessage.Text = "Quiz Score should not be empty";
                ErrorMessage.Visible = true;
                return false;
            }
            else if (txt_startDate.Text.Trim() == "")
            {
                ErrorMessage.Text = "Start Date should be specified";
                ErrorMessage.Visible = true;
                return false;

            }
            else if (txt_endDate.Text.Trim() == "")
            {
                ErrorMessage.Text = "End Date should be specified";
                ErrorMessage.Visible = true;
                return false;
            }
            else if (dropdown_class.SelectedValue == "-1")
            {
                ErrorMessage.Text = "Please select a class!";
                ErrorMessage.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

       

        protected void add_ques_Click(object sender, EventArgs e)
        {
           
            if (ViewState["quizID"] != null)
            {
                int quizID = Convert.ToInt32(ViewState["quizID"]);
                HttpCookie httpCookie = new HttpCookie("quizInformation");
                httpCookie["quizID"] = quizID.ToString();
                Response.Cookies.Add(httpCookie);
                Response.Redirect("~/CreateQuiz-Question.aspx");


            }
        }
    }
}