﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeachersMenu.aspx.cs" Inherits="Quiz_Web_App.TeachersMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-container">
        <asp:Label ID="lblCardID" runat="server" />
        <asp:Button ID="profileBtn" runat="server" Text="Edit Profile" onclick="profileBtn_Click"/>
    </div>

</asp:Content>
