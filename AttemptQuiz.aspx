<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="AttemptQuiz.aspx.cs" Inherits="Quiz_Web_App.AttemptQuiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container green_container">
            <div class="content-container">
            <center>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <%#Eval("Ques_id") %> : <%#Eval("Title") %> (Score: <%#Eval("Score") %>)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="Op1" runat="server" Text='<%#Eval("Option1") %>' GroupName="q1"/>
                                    <asp:RadioButton ID="Op2" runat="server" Text='<%#Eval("Option2") %>' GroupName="q1"/>
                                    <asp:RadioButton ID="Op3" runat="server" Text='<%#Eval("Option3") %>' GroupName="q1"/>
                                    <asp:RadioButton ID="Op4" runat="server" Text='<%#Eval("Option4") %>' GroupName="q1"/>
                                    
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabUserSelectedOption" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"/>
            </center>
            </div>
        </div>
</asp:Content>