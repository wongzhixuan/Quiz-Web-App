<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manage Quiz.aspx.cs" Inherits="Quiz_Web_App.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightcolumn">
                <div id="sticker">
                    <nav>
                        <ul id="panel" class ="panel">
                           
                            <li>
                                <h3>MENU</h3>
                            </li>
                            <li class="animation"><a href="TeachersMenu.aspx">Dashboard</a></li>
                            <li class="animation"><a href="Manage Class.aspx">Manage Class</a></li>
                            <li class="animation"><a href="Manage Quiz.aspx">Manage Quiz</a></li>
                            <li class="animation" style="margin-top: 5px"><a href="StudentListandGrade.aspx">Student Grades</a></li>

                        </ul>
                    </nav>
                </div>
            </div>
    <div class="container green_container">
        <div class="content-container">
            <asp:Button runat="server" Text="+ New Quiz" CssClass="btn btn-primary btn_details" ID="createQuiz" OnClick="createQuiz_Click" />
            <br />

            <div class="class-table">
                <center>
                    <asp:Label runat="server" Text="Quiz List" Font-Bold="True" Font-Size="Larger" CssClass="feature-title"></asp:Label>

                    <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ID="quiz_view" DataKeyNames="QuizID" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table " OnRowDeleting="quiz_view_RowDeleting" OnSorting="quiz_view_Sorting" OnPageIndexChanging="quiz_view_PageIndexChanging" OnRowEditing="quiz_view_RowEditing" OnRowCancelingEdit="quiz_view_RowCancelingEdit" OnRowUpdating="quiz_view_RowUpdating" OnSelectedIndexChanging="quiz_view_SelectedIndexChanging" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                        <Columns>
                            
                            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_title" runat="server" Text='<%# Bind("Title") %>' Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_descrip" runat="server" Text='<%# Bind("Description") %>' Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Description" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class" SortExpression="class_name">
                                
                                <ItemTemplate>
                                    <asp:Label ID="Class" runat="server" Text='<%# Bind("class_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score" SortExpression="Score">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_score" runat="server" Text='<%# Bind("Score") %>' Width="50px" TextMode="Number"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Score" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Start" SortExpression="StartedDate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_start" runat="server" Text='<%# Bind("StartedDate") %>' Width="150px" TextMode="DateTimeLocal"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="StartedDate" runat="server" Text='<%# Bind("StartedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Finish" SortExpression="FinishedDate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_finish" runat="server" Text='<%# Bind("FinishedDate") %>' Width="150px" TextMode="DateTimeLocal"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="FinishedDate" runat="server" Text='<%# Bind("FinishedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Button" ShowEditButton="True"  ControlStyle-CssClass="btn btn-primary" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True"  ControlStyle-CssClass="btn btn-primary">
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:CommandField>

                            <asp:ButtonField CommandName="Select" Text="Edit Questions">
                            <ControlStyle CssClass="btn btn-link" />
                            </asp:ButtonField>

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
                    
                    </center>
                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
                 <br />
                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>
                
            </div>

            </div>
        </div>
</asp:Content>
