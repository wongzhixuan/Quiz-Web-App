<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quiz_Web_App.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="resources/css/LoginRegister.css" />
</head>
<body>
    <div class="centerwindow">
        <div class="title">
            <p>Login Account</p>
        </div>
        <form id="form1" runat="server">

            <table align="center">
                <tr>
                    <td>
                        <p>Enter Your Card ID: </p>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtCardID" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="11" class="textbox" placeholder="E.g.: SWE1234567 (Max. 10 characters)"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p>Enter Your Password: </p>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="textbox" />
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p>Select Your Account Type: </p>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="dropdownlist" >
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Teacher</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
            </table>

            <div align="center">
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="loginBtn_Click" CssClass="button"/>
                <br />
                <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" CssClass="button" />
            </div>
            

    </form>

    </div>
    
</body>
</html>
