﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Quiz_Web_App.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- The side menu container--%>
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
                            <li class="animation" style="margin-top: 5px"><a href="#Student">Student Grades</a></li>

                        </ul>
                    </nav>
                </div>
            </div>

    <%-- The Main Content Container--%>
    <div class="container green_container">
    <div class="content-container">
        <div class="menu_studentlist">
            <ul>
                <li><a>XXX Student System</a></li>
                <li><a>Student List & Grade</a></li>
                <li><a>Anouncement Quiz</a></li>
            </ul>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Student List" Font-Bold="True" Font-Size="Large"></asp:Label>
        <div class="student_list">
            <asp:Label ID="Label2" runat="server" Text="Class Name: "></asp:Label>
            <asp:DropDownList ID="ddl_class" runat="server" CssClass="btn btn-outline-primary dropdown-toggle" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" AutoPostBack="True" >
                <asp:ListItem Value="-1">--classname--</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Label3" runat="server" Text="Quiz Name: " ></asp:Label>
            <asp:DropDownList ID="ddl_quiz" runat="server" CssClass="btn btn-outline-primary dropdown-toggle">
                <asp:ListItem Value="-1">--quizname--</asp:ListItem>

            </asp:DropDownList>
                
            <br />
            <div class="form-group w-50">
            <asp:Button ID="btn_getData" runat="server" Text="Submit" CssClass="btn btn-primary float-end" OnClick="btn_getData_Click" />
                </div>
        </div>
        <asp:GridView ID="studentList_view" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="student_id" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:TemplateField HeaderText="Student ID" SortExpression="student_id">
                    <ItemTemplate>
                        <asp:Label ID="tx_studentid" runat="server" Text='<%#Bind("student_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="student_name">
                    <ItemTemplate>
                        <asp:Label ID="tx_name" runat="server" Text='<%#Bind("student_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score" SortExpression="student_score" >
                    <ItemTemplate>
                        <asp:Label ID="tx_score" runat="server" Text='<%#Bind("student_score") %>'></asp:Label>
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
        
        <div>
            <asp:Button ID="Button1" runat="server" Text="Download" OnClick="download" /></div>
        </div>

        </div>
</asp:Content>