<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginChoice.aspx.cs" Inherits="Quiz_Web_App.LoginChoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="resources/css/LoginChoice.css" />
    <title>Welcome to Quizva!</title>
</head>
<body>
    <div class="centerwindow">
        <div class="title">
            <p>Welcome to Quizva!</p>
        </div>
        <div class="titledesc">
            <p>Please log in before using our application.</p>
            <p>Don't have an account? Register for one instead!</p>
        </div>
        <form id="form1" runat="server" class="loginchoice" align="center">
           <asp:Button ID="loginBtn" runat="server" OnClick="loginBtn_Click" Text="Login Existing Account" CssClass="button"  />
           <br />               
           <asp:Button ID="registerButton" runat="server" OnClick="registerBtn_Click" Text="Register New Account" CssClass="button" />
        </form>
    </div>  
</body>
</html>
