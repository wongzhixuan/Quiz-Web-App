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
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "Select O.Option1, O.Option2, O.Option3, O.Option4, A.QuesId, A.AnsId FROM Quiz_option AS O JOIN Quiz_ans  AS A ON O.Ques_id = A.QuesId";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataTable dt1 = new DataTable();
            DataColumn dc = new DataColumn("Qid", typeof(int));
            dt1.Columns.Add(dc);
            dc = new DataColumn("Aid", typeof(int));
            dt1.Columns.Add(dc);
            DataRow dr = dt1.NewRow();

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("Op1");
                RadioButton rb2 = (RadioButton)ri.FindControl("Op2");
                RadioButton rb3 = (RadioButton)ri.FindControl("Op3");
                RadioButton rb4 = (RadioButton)ri.FindControl("Op4");
                Label QuestionID = (Label)ri.FindControl("Ques_id");
                int QID = Convert.ToInt32(QuestionID.Text);
                int AID;
                if (rb1.Checked == true)
                {
                    AID = 1;
                    dt1.Rows.Add(QID, AID);
                }
                else if (rb2.Checked == true)
                {
                    AID = 2;
                    dt1.Rows.Add(QID, AID);
                }
                else if (rb3.Checked == true)
                {
                    AID = 3;
                    dt1.Rows.Add(QID, AID);
                }
                else if (rb4.Checked == true)
                {
                    AID = 4;
                    dt1.Rows.Add(QID, AID);
                }
                else
                {
                    AID = 0;
                    dt1.Rows.Add(QID, AID);
                }
                rb1.Enabled = false;
                rb2.Enabled = false;
                rb3.Enabled = false;
                rb4.Enabled = false;
            }

            DataTable dt2 = new DataTable();
            dc = new DataColumn("Qid", typeof(int));
            dt2.Columns.Add(dc);
            dc = new DataColumn("Aid", typeof(int));
            dt2.Columns.Add(dc);
            

            foreach (DataRow dr1 in dt.Rows)
            {
                int QID = Convert.ToInt32(dr1[4]);
                int AID = Convert.ToInt32(dr1[5]);
                dt2.Rows.Add(QID, AID);
            }

            int i = 0;
            int count = 0;
            int total = 0;
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                if (Equals(dt1.Rows[i][1], dt2.Rows[i][1]))
                {
                    Label Result = (Label)ri.FindControl("SelectedAns");
                    Result.Text = "The Selected Option is Correct";
                    Result.ForeColor = System.Drawing.Color.Green;
                    count++;
                }
                else if (Equals(dt1.Rows[i][1], 0))
                {
                    Label Result = (Label)ri.FindControl("SelectedAns");
                    Result.Text = "No Option Was Selected";
                    Result.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Label Result = (Label)ri.FindControl("SelectedAns");
                    Result.Text = "The Selected Option is Incorrect";
                    Result.ForeColor = System.Drawing.Color.Red;
                }
                i++;
                total++;
            }
            Score.Text = "Your Score Is " + count + " / " + total;
        }
    }
}