using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace Quiz_Web_App
{
    public partial class AttemptQuiz : System.Web.UI.Page
    {
        //string mainconn = @"Data Source=localhost;Initial Catalog=QuizDB;Integrated Security=True";
        string mainconn = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        int attemptid = 0;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialDDL();

            }
            
        }

        private void SetInitialDDL()
        {
            ArrayList classList = new ArrayList();
            if (Session["CardID"] != null)
            {
                using (SqlConnection con = new SqlConnection(mainconn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetStudentClass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@student_id", Session["CardID"]);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        classList.Add(new ListItem(dataTable.Rows[i]["class_name"].ToString(), dataTable.Rows[i]["class_id"].ToString()));
                    }
                }
                foreach (ListItem item in classList)
                {
                    ddl_class.Items.Add(item);
                }
            }
        }

        public void BindGrid()
        {
            int quiz_id = int.Parse(ddl_quiz.SelectedValue);
            int class_id = int.Parse(ddl_class.SelectedValue);
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand("ViewQuizDetails", sqlconn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Quiz_id", quiz_id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable ();
            sqlDataAdapter.Fill(dt);
            ViewState["Paging"] = dt;

            GridView1.DataSource = dt;
            GridView1.DataBind();

            sqlconn.Close();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int quizID = int.Parse(ddl_quiz.SelectedValue);
            string cardid = Convert.ToString(Session["CardID"]);
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand("ViewQuizDetails", sqlconn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Quiz_id", quizID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            int i = 0;
            int count = 0;
            ArrayList arlist1 = new ArrayList();

            foreach(GridViewRow gr in GridView1.Rows)
            {
                RadioButton rb1 = (RadioButton)gr.FindControl("Op1");
                RadioButton rb2 = (RadioButton)gr.FindControl("Op2");
                RadioButton rb3 = (RadioButton)gr.FindControl("Op3");
                RadioButton rb4 = (RadioButton)gr.FindControl("Op4");
                int qid = Convert.ToInt32(dt.Rows[i]["Ques_id"]);
                int ansid = 0;
                if(rb1.Checked == true)
                {
                    ansid = 1;
                    if(ansid == Convert.ToInt32(dt.Rows[i]["AnsId"]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count += Convert.ToInt32(dt.Rows[i]["Score"]);
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i]["AnsId"]);
                        string corrAns = Convert.ToString(dt.Rows[i][z+3]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                else if (rb2.Checked == true)
                {
                    ansid = 2;
                    if (ansid == Convert.ToInt32(dt.Rows[i]["AnsId"]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count += Convert.ToInt32(dt.Rows[i]["Score"]);
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i]["AnsId"]);
                        string corrAns = Convert.ToString(dt.Rows[i][z+3]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                else if (rb3.Checked == true)
                {
                    ansid = 3;
                    if (ansid == Convert.ToInt32(dt.Rows[i]["AnsId"]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count += Convert.ToInt32(dt.Rows[i]["Score"]);
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i]["AnsId"]);
                        string corrAns = Convert.ToString(dt.Rows[i][z+3]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                else if (rb4.Checked == true)
                {
                    ansid = 4;
                    if (ansid == Convert.ToInt32(dt.Rows[i]["AnsId"]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count += Convert.ToInt32(dt.Rows[i]["Score"]);
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i]["AnsId"]);
                        string corrAns = Convert.ToString(dt.Rows[i][z+3]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                ListItem item = new ListItem(qid.ToString(), ansid.ToString());
                arlist1.Add(item);
                i++;
            }

            using (SqlConnection sqlconn1 = new SqlConnection(mainconn))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateScore", sqlconn1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@quizid", quizID);
                sqlCommand.Parameters.AddWithValue("@userid", cardid);
                sqlCommand.Parameters.AddWithValue("@status", 1);
                sqlCommand.Parameters.AddWithValue("@score", count);
                sqlconn1.Open();
                ViewState["attemptid"] = int.Parse(sqlCommand.ExecuteScalar().ToString());
                sqlconn1.Close();
            }

            Score.Text = "Your Score Is " + count;
            storeAttempt(arlist1);
        }

        private void storeAttempt(ArrayList list1)
        {
            if (ViewState["attemptid"] != null)
            {
                int attemptid = int.Parse(ViewState["attemptid"].ToString());
                
                using (SqlConnection sqlconn = new SqlConnection(mainconn))
                {
                    foreach (ListItem item in list1)
                    {
                        SqlCommand sqlCommand = new SqlCommand("UpdateAttempt", sqlconn);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@attemptid", attemptid);
                        sqlCommand.Parameters.AddWithValue("@quesid", item.Text);
                        sqlCommand.Parameters.AddWithValue("@option", item.Value);
                        
                        sqlconn.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                }
            }

        }

        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_class.SelectedValue != "-1")
            {
                ArrayList quizList = new ArrayList();
                int class_id = int.Parse(ddl_class.SelectedValue);
                using (SqlConnection con = new SqlConnection(mainconn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetStudentQuiz", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        quizList.Add(new ListItem(dataTable.Rows[i]["quiz_title"].ToString(), dataTable.Rows[i]["quiz_id"].ToString()));
                    }

                }
                foreach (ListItem item in quizList)
                {
                    ddl_quiz.Items.Add(item);
                }
            }
        }

        protected void btn_getData_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                BindGrid();
            }
        }

        private bool validateInput()
        {
            // dropdownlist quiz and class cannot be null
            if (ddl_class.SelectedValue == "-1" || ddl_quiz.SelectedValue == "-1")
            {
                //ErrorMessage.Visible = true;
                //SuccessMessage.Visible = false;
                //ErrorMessage.Text = "Class or Quiz is not selected. Please select your choice.";
                // can implement error message
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}