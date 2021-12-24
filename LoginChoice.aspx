<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginChoice.aspx.cs" Inherits="Quiz_Web_App.LoginChoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="studentLoginBtn" runat="server" OnClick="studentLoginBtn_Click" Text="Login As Student" />

            <asp:Button ID="teacherLoginBtn" runat="server" OnClick="teacherLoginBtn_Click" Text="Login As Teacher / Admin" />

            <asp:Button ID="registerButton" runat="server" OnClick="registerBtn_Click" Text="Login As Teacher / Admin" />

        </div>
    </form>
</body>
</html>
