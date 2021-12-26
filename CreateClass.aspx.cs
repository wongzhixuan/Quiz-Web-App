using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Quiz_Web_App
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearTextBox();

            }
        }

        protected void confirm_create_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("CreateClass", sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@class_id", Convert.ToInt32(hfClassID.Value == "" ? "0" : hfClassID.Value));
                sqlCmd.Parameters.AddWithValue("@class_name", text_class_name.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@class_description", text_class_description.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@teacher_id", Session["CardID"]);
                sqlCmd.Parameters.AddWithValue("@created_date", now);
                int count = sqlCmd.ExecuteNonQuery();
                sqlConnection.Close();
                ClearTextBox();
                if (count > 0)
                {
                    SuccessMessage.Text = "Your Class is Created Successfully.";
                }
                else
                {
                    ErrorMessage.Text = "Class Create Failed.";
                }
                
                
                
            }
        }
        
        protected void add_student_Click(object sender, EventArgs e)
        {
            

                if (student_id.Text.Trim() == "" || student_id.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student ID cannot be empty')", true);
                }
                else
                {
                String studentID = student_id.Text.Trim();
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("CreateClass", sqlConnection);
                }
                    
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = studentID;
                    row.Cells.Add(cell);
                    student_added.Rows.Add(row);
                }
            
            
        }
        void ClearTextBox()
        {
            hfClassID.Value = "";
            text_class_description.Text = "";
            text_class_name.Text = "";
        }
    }
}