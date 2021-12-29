using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
namespace Quiz_Web_App
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ViewState["student_table"] = null;
                ClearTextBox();
                ErrorMessage.Visible = false;
                SuccessMessage.Visible = false;

            }
        }
        protected void confirm_create_Click(object sender, EventArgs e) 
        {
            
            DateTime now = DateTime.Now;

            ArrayList arrayList = (ArrayList)ViewState["student_table"];
            if (text_class_name.Text.Trim() == "")
            {
                SuccessMessage.Visible = false;
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "The class name should not be empty";

            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("CreateClass", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@class_id", Convert.ToInt32(hfClassID.Value == "" ? "0" : hfClassID.Value));
                    sqlCmd.Parameters.AddWithValue("@class_name", text_class_name.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@class_description", text_class_description.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@teacher_id", Session["CardID"]);
                    sqlCmd.Parameters.AddWithValue("@created_date", now);

                    int class_id = 0;
                    class_id = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    int student_count = 0;
                    int arrayList_count = 0;
                    if (arrayList == null)
                    {
                        student_count = 0;
                        arrayList_count = 0;
                    }
                    else
                    {
                        foreach (String student_id in arrayList)
                        {
                            SqlCommand sqlCmd2 = new SqlCommand("LinkStudentToClass", sqlConnection);
                            sqlCmd2.CommandType = CommandType.StoredProcedure;
                            sqlCmd2.Parameters.AddWithValue("@class_id", class_id);
                            sqlCmd2.Parameters.AddWithValue("@student_id", student_id);
                            student_count = student_count + sqlCmd2.ExecuteNonQuery();
                        }
                        arrayList_count = arrayList.Count;

                    }


                    sqlConnection.Close();
                    ClearTextBox();
                    if (class_id > 0)
                    {
                        ErrorMessage.Visible = false;
                        SuccessMessage.Text = "Your Class is Created Successfully. Class Id :" + class_id + ", " + student_count + "/" + arrayList_count + " students added.";
                        SuccessMessage.Visible = true;
                    }
                    else
                    {
                        SuccessMessage.Visible = false;
                        ErrorMessage.Text = "Class Create Failed.";
                        ErrorMessage.Visible = true;
                    }

                }
                confirm_create.Click -= confirm_create_Click;
            }
        }

        protected void add_student_Click(object sender, EventArgs e)
        {
            
            ArrayList arrayList = (ArrayList)ViewState["student_table"];
            
            if (arrayList == null)
            {
                arrayList = new ArrayList();
                ViewState["student_table"] = arrayList;
            }

            if (student_id.Text.Trim() == "" || student_id.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student ID cannot be empty')", true);
            }
            else
            {
                
                ArrayList updatedArrayList = new ArrayList();
                String studentID = student_id.Text.Trim();
                String studentName = "";
                Boolean isDuplicated = CheckDuplicate(studentID);
                if (!isDuplicated)
                {
                    arrayList.Add(studentID);
                }
                
                
                foreach (String student in arrayList)
                {
                    
                    studentName = ReadStudentName(student);
                    if(studentName != "")
                    {
                        
                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        cell.Text = student;
                        row.Cells.Add(cell);
                        TableCell cell2 = new TableCell();
                        cell2.Text = studentName;
                        row.Cells.Add(cell2);
                        student_added.Rows.Add(row);
                        updatedArrayList.Add(student);
                    }
                     
                }
                ViewState["student_table"] = updatedArrayList;
                
            }


        }

        private bool CheckDuplicate(string studentID)
        {
            ArrayList anotherArray = (ArrayList)ViewState["student_table"];
            if (anotherArray == null)
            {
                return false;
            }
            else
            {
                foreach (String student in anotherArray)
                {
                    if (studentID == student)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        private string ReadStudentName(string student)
        {
            SqlConnection sqlCon = new SqlConnection(connection_string);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ViewNameByCardID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@CardID", student);
            sqlCmd.Parameters.AddWithValue("@UserType", "Student");
            using (SqlDataReader dataReader = sqlCmd.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    return dataReader["FullName"].ToString();
                }
                else
                {
                    return "";
                }
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