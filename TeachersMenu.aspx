<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeachersMenu.aspx.cs" Inherits="Quiz_Web_App.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-container">
        <asp:Label ID="lblCardID" runat="server" />
        <div id="main-content" class="main">
            <div class="rightcolumn">
                <div id="sticker">
                    <nav>
                        <ul id="panel" class ="panel">
                           
                            <li>
                                <h3>MENU</h3>
                            </li>
                            <li class="animation"><a href="#Dashboard">Dashboard</a></li>
                            <li class="animation"><a href="#Class">Manage Class</a></li>
                            <li class="animation"><a href="#Quiz">Manage Quiz</a></li>
                            <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students Grades</a></li>

                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
