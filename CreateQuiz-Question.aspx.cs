using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Web;

namespace Quiz_Web_App
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string connection_string = @"Data Source=MAIKE\SQL2019;Initial Catalog=QuizWebsiteDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie httpCookie = Request.Cookies["quizInformation"];
                if (httpCookie != null)
                {
                    ViewState["quizID"] = int.Parse(httpCookie["quizID"]);
                    ViewState["totalScore"] = int.Parse(httpCookie["totalScore"]);
                }

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
            dt.Columns.Add(new DataColumn("Option4", typeof(string)));
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("btn_remove");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
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

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    // add new row to datatable
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //store the current data to view state 
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
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
                        dtCurrentTable.Rows[i]["Answer"] = dropDownList.SelectedItem.Value;

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
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
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

                        if (i < dt.Rows.Count - 1)
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
                            dropDownList.Items.FindByValue(dt.Rows[i]["Answer"].ToString()).Selected = true;

                        }

                    }
                }
            }
            else
            {
                Response.Write("DataTable Null");
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
            ErrorMessage.Visible = false;
            int rowIndex = 0;
            int currentScore = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    // validate input before insert data
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //extract TextBox Values
                        TextBox box_title = (TextBox)question_view.Rows[i].Cells[0].FindControl("txbox_title");
                        TextBox box_score = (TextBox)question_view.Rows[i].Cells[1].FindControl("txbox_score");
                        TextBox box_op1 = (TextBox)question_view.Rows[i].Cells[2].FindControl("txbox_op1");
                        TextBox box_op2 = (TextBox)question_view.Rows[i].Cells[3].FindControl("txbox_op2");
                        TextBox box_op3 = (TextBox)question_view.Rows[i].Cells[4].FindControl("txbox_op3");
                        TextBox box_op4 = (TextBox)question_view.Rows[i].Cells[5].FindControl("txbox_op4");
                        DropDownList dropdown_ans = (DropDownList)question_view.Rows[rowIndex].Cells[6].FindControl("dropdown_answer");
                        if (validateInputs(box_title, box_score, box_op1, box_op2, box_op3, box_op4, dropdown_ans))
                        {
                            currentScore = currentScore + int.Parse(box_score.Text.ToString());
                            
                        }
                    }
                    if (ViewState["totalScore"] != null)
                    {
                        int totalScore = int.Parse(ViewState["totalScore"].ToString());
                        if(totalScore != currentScore)
                        {
                            SuccessMessage.Visible = false;
                            ErrorMessage.Text = "Error! Total score of all question must match the total score of entire quiz";
                            ErrorMessage.Visible = true;
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection(connection_string);
                            for (int i = 1; i <= dt.Rows.Count; i++)
                            {
                                int ques_id = 0;
                                //extract TextBox Values
                                TextBox box_title = (TextBox)question_view.Rows[rowIndex].Cells[0].FindControl("txbox_title");
                                TextBox box_score = (TextBox)question_view.Rows[rowIndex].Cells[1].FindControl("txbox_score");
                                TextBox box_op1 = (TextBox)question_view.Rows[rowIndex].Cells[2].FindControl("txbox_op1");
                                TextBox box_op2 = (TextBox)question_view.Rows[rowIndex].Cells[3].FindControl("txbox_op2");
                                TextBox box_op3 = (TextBox)question_view.Rows[rowIndex].Cells[4].FindControl("txbox_op3");
                                TextBox box_op4 = (TextBox)question_view.Rows[rowIndex].Cells[5].FindControl("txbox_op4");
                                DropDownList dropdown_ans = (DropDownList)question_view.Rows[rowIndex].Cells[6].FindControl("dropdown_answer");

                                SqlCommand cmd = new SqlCommand("InsertQuestions", con);
                                cmd.CommandType = CommandType.StoredProcedure;

                                if (ViewState["quizID"] == null)
                                {
                                    Response.Write("quizID is null");
                                }
                                else
                                {

                                    int quizID = int.Parse(ViewState["quizID"].ToString());
                                    cmd.Parameters.AddWithValue("@Quiz_id", quizID);
                                    cmd.Parameters.AddWithValue("@Title", box_title.Text.ToString());
                                    cmd.Parameters.AddWithValue("@Score", box_score.Text.ToString());
                                    con.Open();
                                    ques_id = int.Parse(cmd.ExecuteScalar().ToString());
                                    con.Close();

                                    if (ques_id > 0)
                                    {
                                        SqlCommand cmdOption = new SqlCommand("InsertOptions", con);
                                        cmdOption.CommandType = CommandType.StoredProcedure;
                                        cmdOption.Parameters.AddWithValue("@Ques_id", ques_id);
                                        cmdOption.Parameters.AddWithValue("@Option1", box_op1.Text.ToString());
                                        cmdOption.Parameters.AddWithValue("@Option2", box_op2.Text.ToString());
                                        cmdOption.Parameters.AddWithValue("@Option3", box_op3.Text.ToString());
                                        cmdOption.Parameters.AddWithValue("@Option4", box_op4.Text.ToString());
                                        con.Open();
                                        cmdOption.ExecuteNonQuery();
                                        con.Close();

                                        String answer = dropdown_ans.SelectedValue;
                                        SqlCommand cmdAns = new SqlCommand("InsertAnswer", con);
                                        cmdAns.CommandType = CommandType.StoredProcedure;
                                        cmdAns.Parameters.AddWithValue("@QuesId", ques_id);
                                        cmdAns.Parameters.AddWithValue("@AnsId", int.Parse(answer));
                                        con.Open();
                                        cmdAns.ExecuteNonQuery();
                                        con.Close();
                                        box_title.Enabled = false;
                                        box_score.Enabled = false;
                                        box_op1.Enabled = false;
                                        box_op2.Enabled = false;
                                        box_op3.Enabled = false;
                                        box_op4.Enabled = false;
                                        dropdown_ans.Enabled = false;

                                        
                                    }
                                }
                                rowIndex++;
                            }
                            SuccessMessage.Text = "Successfully Saved all question";
                            SuccessMessage.Visible = true;
                            ErrorMessage.Visible = false;
                            btn_save.Enabled = false;
                            
                        }
                    }
                    
                    
                }

            }

        }

        private bool validateInputs(TextBox box_title, TextBox box_score, TextBox box_op1, TextBox box_op2, TextBox box_op3, TextBox box_op4, DropDownList dropdown_ans)
        {
            SuccessMessage.Visible = false;
            if (box_title.Text == "" || box_score.Text == "" || box_op1.Text == "" || box_op2.Text == "" || box_op3.Text == "" || box_op4.Text == "" || dropdown_ans.SelectedValue == "-1")
            {

                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Please ensure to fill in every fields!";
                return false;
            }
            else if (int.Parse(box_score.Text) <= 0)
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "The score should be larger than 0";
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}