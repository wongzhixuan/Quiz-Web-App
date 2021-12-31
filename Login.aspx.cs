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
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        //string connectionString = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearTextBox();
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginChoice.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (txtCardID.Text == "" || txtPassword.Text == "")
            {
                Response.Write("<script>alert('Please Fill In " +
                    "All Mandatory Sections!');</script>");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(1) FROM UserAcc WHERE CardID=@CardID " +
                        "AND Password=@Password AND UserType=@UserType";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@CardID", txtCardID.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UserType", ddlUserType.SelectedValue);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                    if (count == 1)
                    {
                        if (ddlUserType.SelectedValue == "Student")
                        {
                            Session["CardID"] = txtCardID.Text.Trim();
                            Response.Redirect("StudentsMenu.aspx");
                        }

                        if (ddlUserType.SelectedValue == "Teacher")
                        {
                            Session["CardID"] = txtCardID.Text.Trim();
                            Response.Redirect("TeachersMenu.aspx");
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        Response.Write("<script>alert('Wrong User Credentials. " +
                            "Please Try Again!');</script>");

                    }
                }
            }



        }

        void ClearTextBox()
        {
            txtCardID.Text = txtPassword.Text = " ";
        }
    }
}