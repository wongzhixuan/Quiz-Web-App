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
    public partial class StudentsProfile : System.Web.UI.Page
    {
        string connectionString = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizApp;Integrated Security=True";
            
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewUserByID", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlDa.SelectCommand.Parameters.AddWithValue("@CardID", Session["CardID"]);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();

                lblFullName.Text = dtbl.Rows[0]["FullName"].ToString();
                lblEmailAddress.Text = dtbl.Rows[0]["EmailAddress"].ToString();
                lblPhoneNumber.Text = dtbl.Rows[0]["PhoneNumber"].ToString();


            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}