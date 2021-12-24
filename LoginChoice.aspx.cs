using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_Web_App
{
    public partial class LoginChoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void studentLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLoginPage.aspx");
        }

        protected void teacherLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLoginPage.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}