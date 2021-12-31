using System;
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
            string cardid = Convert.ToString(Session["CardID"]);
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
            ViewState["Paging"] = dt;

            int i = 0;
            int count = 0;
            foreach(GridViewRow gr in GridView1.Rows)
            {
                RadioButton rb1 = (RadioButton)gr.FindControl("Op1");
                RadioButton rb2 = (RadioButton)gr.FindControl("Op2");
                RadioButton rb3 = (RadioButton)gr.FindControl("Op3");
                RadioButton rb4 = (RadioButton)gr.FindControl("Op4");

                if(rb1 != null)
                {
                    int ansid = 1;
                    if(ansid == Convert.ToInt32(dt.Rows[i][8]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count++;
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i][8]);
                        string corrAns = Convert.ToString(dt.Rows[i][z]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                if (rb2 != null)
                {
                    int ansid = 2;
                    if (ansid == Convert.ToInt32(dt.Rows[i][8]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count++;
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i][8]);
                        string corrAns = Convert.ToString(dt.Rows[i][z]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                if (rb3 != null)
                {
                    int ansid = 3;
                    if (ansid == Convert.ToInt32(dt.Rows[i][8]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count++;
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i][8]);
                        string corrAns = Convert.ToString(dt.Rows[i][z]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
                if (rb4 != null)
                {
                    int ansid = 4;
                    if (ansid == Convert.ToInt32(dt.Rows[i][8]))
                    {
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                        count++;
                    }
                    else
                    {
                        int z = Convert.ToInt32(dt.Rows[i][8]);
                        string corrAns = Convert.ToString(dt.Rows[i][z]);
                        Label Result = (Label)gr.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect. The Correct Answer is " + corrAns;
                    }
                }
            }

            Score.Text = "Your Score Is " + count;
        }
    }
}