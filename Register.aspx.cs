﻿using System;
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
            if (txtCardID.Text == "" || txtPassword.Text == "" || txtReconfirmPassword.Text == "" || txtFullName.Text == "" || txtEmailAddress.Text == "")
            {
                lblSuccessMessage.Text = lblErrorMessage.Text = "";
                lblErrorMessage.Text = "Mandatory Fields Are Still Empty!";
            }
            else if (txtReconfirmPassword.Text != txtPassword.Text)
            {
                lblSuccessMessage.Text = lblErrorMessage.Text = "";
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

        protected void backBtn_Click (object sender, EventArgs e)
        {
            Response.Redirect("LoginChoice.aspx");
        }

        void ClearTextBox()
        {
            hfUserID.Value = "";
            txtFullName.Text = txtEmailAddress.Text = txtPhoneNumber.Text = txtCardID.Text = txtPassword.Text = txtReconfirmPassword.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
    }
}