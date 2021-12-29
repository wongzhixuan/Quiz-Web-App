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
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizApp;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearTextBox();
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            bool UserExist;
            UserExist = this.CheckUserExist();

            if (UserExist == false)
            {
                if (txtCardID.Text == "" || txtPassword.Text == "" || txtReconfirmPassword.Text == "" || txtFullName.Text == "" || txtEmailAddress.Text == "")
                {
                    Response.Write("<script>alert('Please Fill In All Mandatory Sections!');</script>");
                }
                else if (txtReconfirmPassword.Text != txtPassword.Text)
                {
                    Response.Write("<script>alert('Password Do Not Match!');</script>");
                    txtPassword.Text = txtReconfirmPassword.Text = "";
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                        sqlCmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@CardID", txtCardID.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@UserType", ddlUserType.SelectedValue);

                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                        ClearTextBox();
                        Response.Write("<script>alert('Your Registration Was Submitted Successfully!');</script>");
                    }
                }
            }
            else
            {
                ClearTextBox();
                Response.Write("<script>alert('Register Failed. This Card ID was registered!');</script>");
            }

            
        }

        protected void backBtn_Click (object sender, EventArgs e)
        {
            Response.Redirect("LoginChoice.aspx");
        }

        void ClearTextBox()
        {
            hfUserID.Value = "";
            txtFullName.Text = txtEmailAddress.Text = txtPhoneNumber.Text = txtCardID.Text = txtPassword.Text = txtReconfirmPassword.Text = "";
        }

        private bool CheckUserExist()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UserAcc WHERE CardID=@CardID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CardID", txtCardID.Text.Trim());
                SqlDataReader rdr;
                rdr = sqlCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
                sqlCon.Close();
            }

            
        }
    }
}