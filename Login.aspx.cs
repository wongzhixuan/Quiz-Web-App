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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginErrMsg.Visible = false;
        }

        protected void btnLogin_Click (object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(local);initial Catalog=user;interated Security=True;"))
            {
                string query = "SELECT COUNT(1) FROM userAccountTable WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", userNameText.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", userPasswordText.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count==1)
                {
                    Session["username"] = userNameText.Text.Trim();
                    Response.Redirect("Menu");
                }
                else
                {
                    loginErrMsg.Visible = true;
                }
            }
        }
    }
}