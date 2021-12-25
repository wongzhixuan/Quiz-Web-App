<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quiz_Web_App.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label Text="Enter Your Card ID" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCardID" runat="server"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Enter Your Password" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Select Your User Type: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUserType" runat="server">
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Teacher</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">

                    </td>
                    <td colspan="2">
                        <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" />
                        <asp:Button ID="loginBtn" runat="server" Text="Register" OnClick="loginBtn_Click" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>




        </div>
    </form>
</body>
</html>
