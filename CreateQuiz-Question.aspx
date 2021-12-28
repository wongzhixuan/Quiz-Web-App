<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateQuiz-Question.aspx.cs" Inherits="Quiz_Web_App.WebForm7" %>

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
                    <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students </a></li>

                </ul>
            </nav>
        </div>
    </div>
    <div class="container green_container">
        <div class="content-container">
            <div class="form-control">
                <asp:Label ID="form_header" runat="server" Text="Create new Quiz - Question" CssClass="feature-title"></asp:Label>
                <asp:HiddenField ID="hfQuizID" runat="server" />


                <center>

                    <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ID="question_view" AutoGenerateColumns="False" CssClass="table " OnRowCreated="question_view_RowCreated" ShowFooter="true">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                        <Columns>

                            <asp:TemplateField HeaderText="Title">

                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_title" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">

                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_score" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Option1">
                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_op1" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Option2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_op2" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Option3">
                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_op3" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Option4">
                                <ItemTemplate>
                                    <asp:TextBox ID="txbox_op4" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Answer">
                                <ItemTemplate>
                                    <asp:DropDownList ID="dropdown_answer" runat="server" AppendDataBoundItems="true" CssClass="btn dropdown-toggle">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Option1</asp:ListItem>
                                        <asp:ListItem Value="2">Option2</asp:ListItem>
                                        <asp:ListItem Value="3">Option3</asp:ListItem>
                                        <asp:ListItem Value="4">Option4</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" Text="+ New Row" CssClass="btn btn-primary" OnClick="ButtonAdd_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_remove" runat="server" OnClick="btn_remove_Click">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

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
                <br />
                <asp:Button ID="btn_save" runat="server" Text="Save All" OnClick="btn_save_Click" />
                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>


            </div>
        </div>
    </div>
</asp:Content>
