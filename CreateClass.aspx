<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateClass.aspx.cs" Inherits="Quiz_Web_App.WebForm3" %>

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
            <div class="form-control">
                <asp:Label ID="form_header" runat="server" Text="Create new Class" CssClass="feature-title"></asp:Label>
                <asp:HiddenField ID="hfClassID" runat="server" />
                <div class="form-group">
                    <asp:Label ID="class_name" runat="server" Text="Class Name" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="text_class_name" runat="server" CssClass="form-control" placeholder="Class Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="class_description" runat="server" Text="Class Description" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="text_class_description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" placeholder="Class Description"></asp:TextBox>
                </div>
                <div class="form-group form-add w-50">
                    <asp:Label ID="class_student" runat="server" Text="Add Students" CssClass="form-label"></asp:Label>

                    <asp:TextBox ID="student_id" runat="server" CssClass="w-75 form-control" placeholder="student ID"> </asp:TextBox>
                    <asp:Button ID="add_student" runat="server" Text="Add+" CssClass="btn btn-primary float-end " OnClick="add_student_Click" />
                </div>

                <br />
                <div class="form-group">

                    <asp:Table ID="student_added" runat="server" CssClass="w-50 table student_table table-dark">

                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Text="StudentID" CssClass="col"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="StudentName" CssClass="col"></asp:TableHeaderCell>

                        </asp:TableHeaderRow>

                        <asp:TableRow CssClass="row"></asp:TableRow>

                    </asp:Table>
                </div>
                <div class="form-group">
                    <asp:Button ID="confirm_create" runat="server" Text="Confirm" CssClass="btn btn-primary btn_details float-end" OnClick="confirm_create_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" />
                </div>
                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>

                <br />
                <br />

            </div>
        </div>
    </div>
</asp:Content>
