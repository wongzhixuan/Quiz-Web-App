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
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID", sqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userID.ToString();
                        txtFullName.Text = dtbl.Rows[0][1].ToString();
                        txtEmailAddress.Text = dtbl.Rows[0][2].ToString();
                        txtPhoneNumber.Text = dtbl.Rows[0][3].ToString();
                        txtCardID.Text = dtbl.Rows[0][4].ToString();
                        txtPassword.Text = dtbl.Rows[0][5].ToString();
                        txtPassword.Attributes.Add("value", dtbl.Rows[0][5].ToString());
                        txtReconfirmPassword.Text = dtbl.Rows[0][6].ToString();
                        txtReconfirmPassword.Attributes.Add("value", dtbl.Rows[0][6].ToString());
                        ddlUserType.Items.FindByValue(dtbl.Rows[0][7].ToString()).Selected = true;

                        
                        
                    }
                }
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text == "" || txtPassword.Text == "" || txtReconfirmPassword.Text == "" || txtFullName.Text == "" || txtEmailAddress.Text == "")
            {
                lblErrorMessage.Text = "Mandatory Fields Are Still Empty!";
            }
            else if (txtReconfirmPassword.Text != txtPassword.Text)
            {
                lblErrorMessage.Text = "Password Do Not Match!";
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
                    lblSuccessMessage.Text = "Your Request Was Submitted Successfully.";
                }
            }
            
            
            
        }

        void ClearTextBox()
        {
            hfUserID.Value = "";
            txtFullName.Text = txtEmailAddress.Text = txtPhoneNumber.Text = txtCardID.Text = txtPassword.Text = txtReconfirmPassword.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
    }
}