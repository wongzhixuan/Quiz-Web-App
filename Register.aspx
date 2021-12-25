<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quiz_Web_App.Register" %>

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
            <asp:HiddenField ID="hfUserID" runat="server" />
            <table align="center">
                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Enter Your Full Name: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFullName" runat="server"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Enter Your Email Address: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmailAddress" runat="server"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Enter Your Phone Number: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPhoneNumber" runat="server"/>
                    </td>
                </tr>

                <tr><td></td><td></td></tr>
                <tr><td></td<td></td>></tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Enter Your Card ID: <br />This Card ID will be your User ID." runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCardID" runat="server"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Enter Your Password: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Reconfirm Your Password: " runat="server"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtReconfirmPassword" runat="server" TextMode="Password"/>
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
                        <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green" />
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
