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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string mainconn = ConfigurationManager.ConnectionStrings["QuizWebsiteDBConnectionString"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "SELECT q.Ques_id, q.Title, q.Score, o.Option1, o.Option2, o.Option3, o.Option4, a.AnsId " +
                                  "FROM Quiz_question q " +
                                  "INNER JOIN Quiz_option AS o ON q.Ques_id = o.Ques_id " +
                                  "INNER JOIN Quiz_ans AS a ON q.Ques_id = a.QuesId";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                sqlconn.Close();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string selected = string.Empty;
            if (rbl1.SelectedIndex > 0)
            {
                if (rbl1.SelectedValue == "Op1")
                {
                    selected = "1";
                }
            }
            else
            {
                selected = "0";
            }
            string constr = ConfigurationManager.ConnectionStrings["QuizWebsiteDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Student_ans(AnsId) VALUES(@AnsId)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@AnsId", selected);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}