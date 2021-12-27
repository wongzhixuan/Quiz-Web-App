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
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getData();
            }
        }
        public void getData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("ViewClasses", sqlConnection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@teacher_id", Session["CardID"]);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                class_view.DataSource = dataTable;
                class_view.DataBind();
            }
        }

        protected void createClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClass.aspx");
        }

        protected void class_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            class_view.EditIndex = -1;
            getData();
        }

        protected void class_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtname = class_view.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox txtdescrip = class_view.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox txtdate = class_view.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;

            int id = Convert.ToInt16(class_view.DataKeys[e.RowIndex].Values["id"].ToString());;
            user_update(txtname.Text, txtdescrip.Text, txtdate.Text, id);
            class_view.EditIndex = -1;
            getData();
        }

        private void user_update(string text1, string text2, string text3, int id)
        {
            
        }

        protected void class_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(class_view.DataKeys[e.RowIndex].Values["class_id"].ToString());
            user_delete(id);
            getData();
        }

        protected void user_delete(int id)
        {
            
        }

        protected void class_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            class_view.EditIndex = e.NewEditIndex;
            getData();
        }
    }
}