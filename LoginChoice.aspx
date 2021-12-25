<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginChoice.aspx.cs" Inherits="Quiz_Web_App.LoginChoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="loginBtn" runat="server" OnClick="loginBtn_Click" Text="Login" />

            <asp:Button ID="registerButton" runat="server" OnClick="registerBtn_Click" Text="Register Account" />

        </div>
    </form>
</body>
</html>
