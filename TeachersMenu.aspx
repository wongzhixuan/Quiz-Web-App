﻿

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeachersMenu.aspx.cs" Inherits="Quiz_Web_App.TeachersMenu" %>
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
                            <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students </a></li>

                        </ul>
                    </nav>
                </div>
            </div>
    <div class="container green_container">
    <div class="content-container">
        <asp:Label ID="lblCardID" runat="server" />
        
    </div>
        </div>
        <asp:Button ID="profileBtn" runat="server" Text="Edit Profile" onclick="profileBtn_Click"/>
    </div>


</asp:Content>
