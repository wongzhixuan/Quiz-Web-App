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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialDDL();
            }

        }

        private void SetInitialDDL()
        {
            ArrayList classList = new ArrayList();
            
            int teacher_id = int.Parse(Session["CardID"].ToString());
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetClasses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
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

        private void GetData()
        {
            if (validateInput())
            {
                int quiz_id = int.Parse(ddl_quiz.SelectedValue);
                int class_id = int.Parse(ddl_class.SelectedValue);
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("ViewStudentResults", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@teacher_id ", int.Parse(Session["CardID"].ToString()));
                    sqlCmd.Parameters.AddWithValue("@quiz_id", quiz_id);
                    sqlCmd.Parameters.AddWithValue("@class_id", class_id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    ViewState["Paging"] = dataTable;
                    studentList_view.DataSource = dataTable;
                    studentList_view.DataBind();
                    DataTable dt = (DataTable)ViewState["Paging"];
                    sqlConnection.Close();
                }
            }
            
        }

        private bool validateInput()
        {
            // dropdownlist quiz and class cannot be null
            if (ddl_class.SelectedValue == "-1" || ddl_quiz.SelectedValue == "-1")
            {
                // can implement error message
                return false;
            }
            else
            {
                return true;
            }
        }

        /*protected void Class_Item(object sender, EventArgs e)
         {
             using (SqlConnection sqlConnection = new SqlConnection(connection_string))
             {
                 SqlCommand cmd = new SqlCommand("SELECT * from Class", sqlConnection);
                 sqlConnection.Open();
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 sda.Fill(ds);
                 Class.DataSource = ds;
                 Class.DataBind();
                 sqlConnection.Close();


             }
         }

         protected void Quiz (object sender, EventArgs e)
         {

         }
         */
        protected void download(object sender, EventArgs e)
        {
            /*
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment; filename=StudentList&Grade.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            student_list.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();*/
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_class.SelectedValue != "-1")
            {
                ArrayList quizList = new ArrayList();
                int teacher_id = int.Parse(Session["CardID"].ToString());
                int class_id = int.Parse(ddl_class.SelectedValue);
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetQuizzes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
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
            else
            {
                //error message
            }
        }

        protected void btn_getData_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}