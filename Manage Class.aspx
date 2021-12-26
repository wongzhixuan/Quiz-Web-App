<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manage Class.aspx.cs" Inherits="Quiz_Web_App.WebForm2" %>

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
                    <li class="animation"><a href="#Quiz">Manage Quiz</a></li>
                    <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students Grades</a></li>

                </ul>
            </nav>
        </div>
    </div>
    <div class="container green_container">
        <div class="content-container">
            <asp:Button runat="server" Text="+ New Class" CssClass="btn btn-primary btn_details" />
            <br />
            
                <div class="class-table">
                    <center>
                    <asp:Label runat="server" Text="Class List" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </center>
                    <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" ID="class_view" AutoGenerateColumns="False" DataKeyNames="class_id" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
                        <alternatingrowstyle backcolor="White" forecolor="#284775" />

                        <columns>
                            <asp:BoundField DataField="class_id" HeaderText="class_id" ReadOnly="True" SortExpression="class_id" />
                            <asp:BoundField DataField="class_name" HeaderText="class_name" SortExpression="class_name" />
                            <asp:BoundField DataField="class_description" HeaderText="class_description" SortExpression="class_description" />
                            <asp:BoundField DataField="teacher_id" HeaderText="teacher_id" SortExpression="teacher_id" />
                            <asp:BoundField DataField="created_date" HeaderText="created_date" SortExpression="created_date" />
                            <asp:CommandField ButtonType="Button" ShowEditButton="True">
                                <controlstyle cssclass="btn btn-primary btn_details" />
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                                <controlstyle cssclass="btn btn-primary btn_details" />
                            </asp:CommandField>
                        </columns>

                        <editrowstyle backcolor="#999999" />
                        <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                        <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                        <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                        <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                        <sortedascendingcellstyle backcolor="#E9E7E2" />
                        <sortedascendingheaderstyle backcolor="#506C8C" />
                        <sorteddescendingcellstyle backcolor="#FFFDF8" />
                        <sorteddescendingheaderstyle backcolor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:QuizWebsiteDBConnectionString2 %>" SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                </div>
            

        </div>
    </div>
</asp:Content>
