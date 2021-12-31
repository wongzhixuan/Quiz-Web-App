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

namespace Quiz_Web_App
{
    public partial class AttemptQuiz : System.Web.UI.Page
    {
        string mainconn = @"Data Source=localhost;Initial Catalog=QuizDB;Integrated Security=True";
        int attemptid = 0;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie quizcookie = Request.Cookies["quizInfo"];
                if (quizcookie != null)
                {
                    ViewState["quizID"] = int.Parse(quizcookie["quizID"].ToString());
                }
                BindGrid();
            }
        }

        public void BindGrid()
        {
            int quizID = int.Parse(ViewState["quizID"].ToString());
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand("ViewQuizDetails", sqlconn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Quiz_id", quizID);
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
            int quizID = int.Parse(ViewState["quizID"].ToString());
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
            var arlist1 = new ArrayList();
            var arlist2 = new ArrayList();

            foreach(GridViewRow gr in GridView1.Rows)
            {
                RadioButton rb1 = (RadioButton)gr.FindControl("Op1");
                RadioButton rb2 = (RadioButton)gr.FindControl("Op2");
                RadioButton rb3 = (RadioButton)gr.FindControl("Op3");
                RadioButton rb4 = (RadioButton)gr.FindControl("Op4");
                int qid = Convert.ToInt32(dt.Rows[i]["Ques_id"]);
                int ansid = 0;
                if(rb1 != null)
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
                if (rb2 != null)
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
                if (rb3 != null)
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
                if (rb4 != null)
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
                arlist1.Add(qid);
                arlist2.Add(ansid);
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
                attemptid = int.Parse(sqlCommand.ExecuteScalar().ToString());
                sqlCommand.ExecuteNonQuery();
                sqlconn1.Close();
            }

            Score.Text = "Your Score Is " + count;
            storeAttempt(arlist1, arlist2);
        }

        public void storeAttempt(ArrayList list1, ArrayList list2)
        {
            using (SqlConnection sqlconn = new SqlConnection(mainconn))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateAttempt", sqlconn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@attemptid", attemptid);
                
                foreach(int qid in list1)
                {
                    sqlCommand.Parameters.AddWithValue("@quesid", qid);
                }
                
                foreach(int ansid in list2)
                {
                    sqlCommand.Parameters.AddWithValue("@option", ansid);
                }

                sqlconn.Open();
                sqlCommand.ExecuteNonQuery();
                sqlconn.Close();
            }

        }
    }
}