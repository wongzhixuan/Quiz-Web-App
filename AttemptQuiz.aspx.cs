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
        string mainconn = ConfigurationManager.ConnectionStrings["QuizWebsiteDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGrid();
        }

        public void BindGrid()
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT q.Ques_id, q.Title, q.Score, o.Option1, o.Option2, o.Option3, o.Option4, a.AnsId FROM Quiz_question q INNER JOIN Quiz_option AS o ON q.Ques_id = o.Ques_id INNER JOIN Quiz_ans AS a ON q.Ques_id = a.QuesId";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable ();
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            sqlconn.Close();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("Op1");
                Label CorrectAnswer = (Label)ri.FindControl("CorrectAns");
                if (rb1.Checked == true)
                {
                    if (rb1.ID.Equals(CorrectAnswer.Text))
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect";
                        Result.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb2 = (RadioButton)ri.FindControl("Op2");
                Label CorrectAnswer = (Label)ri.FindControl("CorrectAns");
                if (rb2.Checked == true)
                {
                    if (rb2.ID.Equals(CorrectAnswer.Text))
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect";
                        Result.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb3 = (RadioButton)ri.FindControl("Op3");
                Label CorrectAnswer = (Label)ri.FindControl("CorrectAns");
                if (rb3.Checked == true)
                {
                    if (rb3.ID.Equals(CorrectAnswer.Text))
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Correct";
                        Result.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label Result = (Label)ri.FindControl("SelectedAns");
                        Result.Text = "The Selected Option is Incorrect";
                        Result.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb4 = (RadioButton)ri.FindControl("Op4");
                Label CorrectAnswer = (Label)ri.FindControl("CorrectAns");
                if (rb4.Checked == true)
                {
                    if (rb4.ID.Equals(CorrectAnswer.Text))
                    {
                        Label Correct = (Label)ri.FindControl("SelectedAns");
                        Correct.Text = "The Selected Option is Correct";
                        Correct.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label Wrong = (Label)ri.FindControl("SelectedAns");
                        Wrong.Text = "The Selected Option is Incorrect";
                        Wrong.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("Op1");
                RadioButton rb2 = (RadioButton)ri.FindControl("Op2");
                RadioButton rb3 = (RadioButton)ri.FindControl("Op3");
                RadioButton rb4 = (RadioButton)ri.FindControl("Op4");
                if (rb1.Checked == false && rb2.Checked == false && rb3.Checked == false && rb4.Checked == false)
                {
                    Label NoSelected = (Label)ri.FindControl("SelectedAns");
                    NoSelected.Text = "No Option Was Selected";
                    NoSelected.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}