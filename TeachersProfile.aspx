<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachersProfile.aspx.cs" Inherits="Quiz_Web_App.TeachersProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 251px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Your Full Name: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:Label Text="Your Full Name: " runat="server" ID="lblFullName"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Edit Your Email Address: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:Label Text="Your Email Address: " runat="server" ID="lblEmailAddress"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Edit Your Phone Number: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:Label Text="Your Phone Number: " runat="server" ID="lblPhoneNumber"/>
                    </td>
                </tr>
            </table>

            <asp:Button ID="logoutBtn" runat="server" Text="Log Out" OnClick="logoutBtn_Click" />
        </div>
    </form>
</body>
</html>