<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quiz_Web_App.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="content-container">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="User Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="userNameText" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="User Password: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="userPasswordText" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="loginErrMsg" runat="server" Text="Wrong User Name or Password! "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
        </div>
</body>
</html>
