using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_Web_App
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string quizID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie quizcookie = Request.Cookies["quizInfo"];
                if(quizcookie != null)
                {
                    ViewState["quizID"] = quizcookie["quizID"].ToString();
                }
                
            }
        }
    }
}