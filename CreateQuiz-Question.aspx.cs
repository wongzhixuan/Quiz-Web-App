using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;


namespace Quiz_Web_App
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string connection_string = @"Data Source=LAPTOP-R7G5DB4N;Initial Catalog=QuizWebsiteDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                SuccessMessage.Visible = false;
                ErrorMessage.Visible = false;
            }
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Score", typeof(string)));
            dt.Columns.Add(new DataColumn("Option1", typeof(string)));
            dt.Columns.Add(new DataColumn("Option2", typeof(string)));
            dt.Columns.Add(new DataColumn("Option3", typeof(string)));
            dt.Columns.Add(new DataColumn("Option4" , typeof(string)));
            dt.Columns.Add(new DataColumn("Answer", typeof(string)));

            dr = dt.NewRow();
            dr["Title"] = string.Empty;
            dr["Score"] = string.Empty;
            dr["Option1"] = string.Empty;
            dr["Option2"] = string.Empty;
            dr["Option3"] = string.Empty;
            dr["Option4"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the datatable in viewstate for future reference
            ViewState["CurrentTable"] = dt;

            // Bind the gridview
            question_view.DataSource = dt;
            question_view.DataBind();

            
        }

        

        protected void question_view_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("btn_remove");
                if(lb != null)
                {
                    if(dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                        
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }

            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowTOGrid();
        }

        private void AddNewRowTOGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if(dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    // add new row to datatable
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //store the current data to view state 
                    ViewState["CurrentTable"] = dtCurrentTable;
                    
                    for(int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        //extract the textbox values
                       
                        TextBox box1 = (TextBox)question_view.Rows[i].Cells[0].FindControl("txbox_title");
                        TextBox box2 = (TextBox)question_view.Rows[i].Cells[1].FindControl("txbox_score");
                        TextBox box3 = (TextBox)question_view.Rows[i].Cells[2].FindControl("txbox_op1");
                        TextBox box4 = (TextBox)question_view.Rows[i].Cells[3].FindControl("txbox_op2");
                        TextBox box5 = (TextBox)question_view.Rows[i].Cells[4].FindControl("txbox_op3");
                        TextBox box6 = (TextBox)question_view.Rows[i].Cells[5].FindControl("txbox_op4");

                        dtCurrentTable.Rows[i]["Title"] = box1.Text;
                        dtCurrentTable.Rows[i]["Score"] = box2.Text;
                        dtCurrentTable.Rows[i]["Option1"] = box3.Text;
                        dtCurrentTable.Rows[i]["Option2"] = box4.Text;
                        dtCurrentTable.Rows[i]["Option3"] = box5.Text;
                        dtCurrentTable.Rows[i]["Option4"] = box6.Text;

                        // extract DropDownList Selected Items
                        DropDownList dropDownList = (DropDownList)question_view.Rows[i].Cells[6].FindControl("dropdown_answer");

                        // Update the DataRow with the DropDownList Selected Items
                        dtCurrentTable.Rows[i]["Answer"] = dropDownList.SelectedItem.Text;

                    }
                    //Rebind the Grid with the current data to reflect changes
                    question_view.DataSource = dtCurrentTable;
                    question_view.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            // set privious data on postbacks
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            if(ViewState["CurrentTable"]!= null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if(dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        
                        TextBox box1 = (TextBox)question_view.Rows[i].Cells[0].FindControl("txbox_title");
                        TextBox box2 = (TextBox)question_view.Rows[i].Cells[1].FindControl("txbox_score");
                        TextBox box3 = (TextBox)question_view.Rows[i].Cells[2].FindControl("txbox_op1");
                        TextBox box4 = (TextBox)question_view.Rows[i].Cells[3].FindControl("txbox_op2");
                        TextBox box5 = (TextBox)question_view.Rows[i].Cells[4].FindControl("txbox_op3");
                        TextBox box6 = (TextBox)question_view.Rows[i].Cells[5].FindControl("txbox_op4");

                        
                        DropDownList dropDownList = (DropDownList)question_view.Rows[i].Cells[6].FindControl("dropdown_answer");

                        if(i < dt.Rows.Count - 1)
                        {
                            //assign value from datatable to textbox
                            box1.Text = dt.Rows[i]["Title"].ToString();
                            box2.Text = dt.Rows[i]["Score"].ToString();
                            box3.Text = dt.Rows[i]["Option1"].ToString();
                            box4.Text = dt.Rows[i]["Option2"].ToString();
                            box5.Text = dt.Rows[i]["Option3"].ToString();
                            box6.Text = dt.Rows[i]["Option4"].ToString();

                            // Set the Previous Selected Items on Each DropDownList on Postbacks
                            dropDownList.ClearSelection();
                            dropDownList.Items.FindByText(dt.Rows[i]["Answer"].ToString()).Selected = true;

                        }

                    }
                }
            }
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[gvRow.RowIndex]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                question_view.DataSource = dt;
                question_view.DataBind();
            }
            //Set Previous Data on Postbacks  
            SetPreviousData();
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            if(ViewState["CurrentTable"]!= null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if(dt.Rows.Count > 0)
                {
                    for(int i = 1; i <= dt.Rows.Count; i++ )
                    {
                        //extract TextBox Values
                        TextBox box1 = (TextBox)question_view.Rows[i].Cells[0].FindControl("txbox_title");
                        TextBox box2 = (TextBox)question_view.Rows[i].Cells[1].FindControl("txbox_score");
                        TextBox box3 = (TextBox)question_view.Rows[i].Cells[2].FindControl("txbox_op1");
                        TextBox box4 = (TextBox)question_view.Rows[i].Cells[3].FindControl("txbox_op2");
                        TextBox box5 = (TextBox)question_view.Rows[i].Cells[4].FindControl("txbox_op3");
                        TextBox box6 = (TextBox)question_view.Rows[i].Cells[5].FindControl("txbox_op4");
                        DropDownList dropDownList = (DropDownList)question_view.Rows[i].Cells[6].FindControl("dropdown_answer");

                        //getvalues from textbox and dropdownlist
                        //add to collections with a comma"," as the delimited value
                        sc.Add(string.Format("{0},{1}", box1.Text, box2.Text));
                    }
                    //call the method for executing inserts
                    InsertRecords(sc);
                }
            }
        }
        private void InsertRecords(StringCollection sc)
        {
            int count = 0;
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            int row_count = dt.Rows.Count;
            StringBuilder sb = new StringBuilder(string.Empty);
            string[] splitItems = null;
            const string sqlStatement = "INSERT INTO Quiz_question (Field1,Field2, Field3) VALUES";
            foreach (string item in sc)
            {
                if (item.Contains(","))
                {
                    splitItems = item.Split(",".ToCharArray());
                    sb.AppendFormat("{0}('{1}','{2}','{3}','{4}'); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2], splitItems[3]);
                }
            }
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                
                con.Open();
                using(SqlCommand cmd = new SqlCommand(sb.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    count = count + cmd.ExecuteNonQuery();
                    
                }
                con.Close();
            }
            if(count >= row_count)
            {
                SuccessMessage.Visible = true;
                SuccessMessage.Text = "Questions Successfully Added";
            }
            else
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Error Occurs! " + count+"/"+row_count+" inserted";
            }

        }
    }
}