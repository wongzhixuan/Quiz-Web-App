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
            if (IsPostBack == false)
                BindGrid();
        }

        public void BindGrid()
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT q.Ques_id, q.Title, q.Score, o.Option1, o.Option2, o.Option3, o.Option4 FROM Quiz_question q INNER JOIN Quiz_option AS o ON q.Ques_id = o.Ques_id INNER JOIN Quiz_ans AS a ON q.Ques_id = a.QuesId";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable ();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            sqlconn.Close();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int quesid;
            int ansid;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (Op1.Checked)
                {
                    quesid = i + 1;
                    ansid = '1';
                }
                else if (Op2.Checked)
                {
                    quesid = i + 1;
                    ansid = '2';
                }
                else if (Op3.Checked)
                {
                    quesid = i + 1;
                    ansid = '3';
                }
                else if (Op4.Checked)
                {
                    quesid = i + 1;
                    ansid = '4';
                }
                else
                {
                    quesid = i + 1;
                    ansid = '0';
                }
                string cmd = "insert into Student_ans values(@QuesID,@AnsID)";
                using (SqlConnection sqlconn = new SqlConnection(mainconn))
                {
                    using (SqlCommand sqlcomm = new SqlCommand(cmd, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@QuesID",quesid);
                        sqlcomm.Parameters.AddWithValue("@AnsID",ansid);

                        sqlconn.Open();
                        sqlcomm.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                }
            }
        }
    }
}