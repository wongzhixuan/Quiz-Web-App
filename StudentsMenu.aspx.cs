using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_Web_App
{
    public partial class StudentsMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCardID.Text = "Your Card ID is: " + Session["CardID"];
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentsProfile.aspx");
        }
    }
}