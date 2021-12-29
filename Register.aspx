<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quiz_Web_App.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="resources/css/LoginRegister.css" />
</head>
<body>
    <div class="centerwindowregister">
        <div class="title">
            <p>Register New Account</p>
        </div>

        <form id="form1" runat="server">
            <asp:HiddenField ID="hfUserID" runat="server" />
            <table align="center">
                <tr>
                    <td>
                        <p>Enter Your Full Name:</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" onkeyup="this.value=this.value.toUpperCase()" class="textbox" placeholder="E.g.: LAI GUANG PEI"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Enter Your Email Address:</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmailAddress" runat="server" TextMode="Email" class="textbox" placeholder="E.g.: abc@xmu.edu.my"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Enter Your Phone Number:</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" class="textbox" placeholder="E.g.: 0184536723"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Enter Your Card ID (You will use this ID to login your account):</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCardID" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="10" class="textbox" placeholder="E.g.: SWE1234567 (Max. 10 characters)"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Enter Your Password:</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="textbox"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Reconfirm Your Password:</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtReconfirmPassword" runat="server" TextMode="Password" class="textbox"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Select Your User Type:</p>
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
                <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" CssClass="button" />
                <br />
                <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" CssClass="button" />
            </div>
        </form>


    </div>

</body>
</html>
