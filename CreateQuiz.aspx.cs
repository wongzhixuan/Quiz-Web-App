using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Quiz_Web_App
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearTextBox();
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;
                setInitialClass();
            }
            
        }

        private void setInitialClass()
        {
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
                    dataTable.Rows[i][""]
                }
                    
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
                    using (SqlConnection con = new SqlConnection(connection_string))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("CreateQuiz", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QuizID", Convert.ToInt32(hfQuizID.Value == "" ? "0" : hfQuizID.Value));
                        cmd.Parameters.AddWithValue("", Session["CardID"]);
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
    }
}