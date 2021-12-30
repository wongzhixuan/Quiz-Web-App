using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Text;

namespace Student_List_Grade_Quiz
{
    public partial class Student_List_Grade : System.Web.UI.Page
    {
        string connection_string = @"Data Source=MAIKE\SQL2019; Initial Catalog=QuizApp;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!Page.IsPostBack)
            {
                ViewState["GridView1"] = null;
            }

            else
            {
                DataTable dt = new DataTable();
                var table = new DataTable();
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT ClassId, Score FROM Quiz", sqlConnection);
                    sqlConnection.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(table);
                    sqlConnection.Close();
                    sda.Dispose();
                }
                dt = table;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["Data"] = dt;
            }*/

        }

        /*protected void Class_Item(object sender, EventArgs e)
         {
             using (SqlConnection sqlConnection = new SqlConnection(connection_string))
             {
                 SqlCommand cmd = new SqlCommand("SELECT * from Class", sqlConnection);
                 sqlConnection.Open();
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 sda.Fill(ds);
                 Class.DataSource = ds;
                 Class.DataBind();
                 sqlConnection.Close();


             }
         }

         protected void Quiz (object sender, EventArgs e)
         {

         }
         */
        protected void download(object sender, EventArgs e)
        {
            /*
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment; filename=StudentList&Grade.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            student_list.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();*/
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}