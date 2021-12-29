<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="Quiz_Web_App.AttemptQuiz" CodeBehind="AttemptQuiz.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container green_container">
            <div class="content-container">
            <center>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="quiz" style="font-family:Arial">
                        <table>
                            <tr>
                                <td Width="600px">
                                    <hr />
                                    <%#Eval("Ques_id") %>. <%#Eval("Title") %>
                                    <br />
                                </td>
                                <td>
                                    <hr />
                                    <asp:RadioButton class="radio" runat="server" ID="Op1" Text='<%#Eval("Option1") %>' GroupName="Options"/>
                                    <asp:RadioButton class="radio" runat="server" ID="Op2" Text='<%#Eval("Option2") %>' GroupName="Options"/>
                                    <asp:RadioButton class="radio" runat="server" ID="Op3" Text='<%#Eval("Option3") %>' GroupName="Options"/>
                                    <asp:RadioButton class="radio" runat="server" ID="Op4" Text='<%#Eval("Option4") %>' GroupName="Options"/>
                                    <br />
                                    <asp:Label ID="CorrectAns" runat="server" Text='<%#Eval("AnsId") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center; vertical-align: middle;">
                                    <br />
                                    <asp:Label ID="SelectedAns" runat="server" Text=""></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"/>
            </center>
            </div>
        </div>
</asp:Content>