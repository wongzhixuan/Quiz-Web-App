<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeachersMenu.aspx.cs" Inherits="Quiz_Web_App.TeachersMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- The side menu container--%>
    <div class="rightcolumn">
                <div id="sticker">
                    <nav>
                        <ul id="panel" class ="panel">
                           
                            <li>
                                <h3>MENU</h3>
                            </li>
                            <li class="animation"><a href="TeachersMenu.aspx">Dashboard</a></li>
                            <li class="animation"><a href="Manage Class.aspx">Manage Class</a></li>
                            <li class="animation"><a href="Manage Quiz.aspx">Manage Quiz</a></li>
                            <li class="animation" style="margin-top: 5px"><a href="StudentListandGrade.aspx">Student Grades</a></li>

                        </ul>
                    </nav>
                </div>
            </div>

    <%-- The Main Content Container--%>
    <div class="container green_container">
    <div class="content-container">
        <asp:Label ID="lblCardID" runat="server" />
        
        <div class="form-control w-100 ">
            <table align="center">
                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Your Full Name: " runat="server" CssClass="col-sm-2 col-form-label"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox Text=" " runat="server" ID="lblFullName" CssClass="form-control-plaintext "/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Your Email Address: " runat="server" CssClass="col-sm-2 col-form-label"/>
                    </td>
                    <td colspan="2">
                        <asp:Label Text=" " runat="server" ID="lblEmailAddress" CssClass="form-control-plaintext "/>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="Your Phone Number: " runat="server" CssClass="col-sm-2 col-form-label"/>
                    </td>
                    <td colspan="2">
                        <asp:Label Text=" " runat="server" ID="lblPhoneNumber" CssClass="form-control-plaintext "/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />
                        <br />
                        <asp:Button ID="logoutBtn" runat="server" Text="Log Out" OnClick="logoutBtn_Click" CssClass="btn btn-danger float-end" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    
    </div>
        </div>
        


</asp:Content>
