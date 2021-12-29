<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditQuiz.aspx.cs" Inherits="Quiz_Web_App.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightcolumn">
        <div id="sticker">
            <nav>
                <ul id="panel" class="panel">

                    <li>
                        <h3>MENU</h3>
                    </li>
                    <li class="animation"><a href="TeachersMenu.aspx">Dashboard</a></li>
                    <li class="animation"><a href="Manage Class.aspx">Manage Class</a></li>
                    <li class="animation"><a href="Manage Quiz.aspx">Manage Quiz</a></li>
                    <li class="animation" style="margin-top: 5px"><a href="#Student">Student Grades</a></li>

                </ul>
            </nav>
        </div>
    </div>
    <div class="container green_container">
        <div class="content-container">
            <asp:Label ID="form_header" runat="server" Text="Edit Questions" CssClass="feature-title"></asp:Label>
            <asp:HiddenField ID="hfQuizID" runat="server" />
            
            <br />
            <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ID="question_view" DataKeyNames="Ques_id" AutoGenerateColumns="False" CssClass="table " OnRowDeleting="question_view_RowDeleting" OnRowEditing="question_view_RowEditing" OnRowUpdating="question_view_RowUpdating" OnRowCancelingEdit="question_view_RowCancelingEdit" ShowFooter="True" AllowPaging="True" AllowSorting="True" OnSorting="question_view_Sorting" OnPageIndexChanging="question_view_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>

                    <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_title" runat="server" Width="150px" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <InsertItemTemplate>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_score" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("Score") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Score" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Option1">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_op1" runat="server" Width="150px" Text='<%# Bind("Option1") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Option1" runat="server" Text='<%# Bind("Option1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Option2">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_op2" runat="server" Width="150px" Text='<%# Bind("Option2") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Option2" runat="server" Text='<%# Bind("Option2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Option3">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_op3" runat="server" Width="150px" Text='<%# Bind("Option3") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Option3" runat="server" Text='<%# Bind("Option3") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Option4">
                        <EditItemTemplate>
                            <asp:TextBox ID="txbox_op4" runat="server" Width="150px" Text='<%# Bind("Option4") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Option4" runat="server" Text='<%# Bind("Option4") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Answer">
                        <EditItemTemplate>
                            <asp:DropDownList ID="dropdown_answer" runat="server" AppendDataBoundItems="true" CssClass=" btn btn-outline-primary dropdown-toggle" DataValueField='<%# Bind("AnsId") %>'>
                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                <asp:ListItem Value="1">Option1</asp:ListItem>
                                <asp:ListItem Value="2">Option2</asp:ListItem>
                                <asp:ListItem Value="3">Option3</asp:ListItem>
                                <asp:ListItem Value="4">Option4</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Option"></asp:Label><asp:Label ID="Answer" runat="server" Text='<%# Bind("AnsId") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterStyle HorizontalAlign="Right" />

                    </asp:TemplateField>


                    <asp:CommandField ButtonType="Button" ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" />

                </Columns>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>
            <br />
            <br />
            <hr />
            <div class="form-control">
                <asp:Label ID="title_add_question" runat="server" Text="Add new Question" CssClass="feature-title"></asp:Label>
                <div class="form-group">
                    <asp:Label ID="lb_title" runat="server" Text="Title" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_title" runat="server" placeholder="Question Title" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="This will be the title of the question." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lb_score" runat="server" Text="Score" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_score" runat="server" placeholder="Score" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="This will be the score of the question." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lb_option1" runat="server" Text="Option1" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_op1" runat="server" placeholder="Option1" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="First answer option of the question" CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Option2" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_op2" runat="server" placeholder="Option2" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Second answer option of the question" CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Option3" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_op3" runat="server" placeholder="Option3" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="Third answer option of the question" CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Option4" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="add_op4" runat="server" placeholder="Option4" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Text="Last answer option of the question" CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Answer" CssClass="form-label"></asp:Label>
                    <br />
                    <asp:DropDownList ID="add_answer" runat="server" AppendDataBoundItems="true" CssClass=" btn btn-outline-primary dropdown-toggle">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem Value="1">Option1</asp:ListItem>
                        <asp:ListItem Value="2">Option2</asp:ListItem>
                        <asp:ListItem Value="3">Option3</asp:ListItem>
                        <asp:ListItem Value="4">Option4</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Please select the correct answer" CssClass="form-text text-muted"></asp:Label>

                </div>
                <div class="form-group">
                    <asp:Button ID="btn_save" runat="server" Text="+ Add Question" OnClick="btn_save_Click" CssClass="btn btn-primary float-end " UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" />
                </div>
                <br />
                <br />
            </div>




        </div>
    </div>
</asp:Content>
