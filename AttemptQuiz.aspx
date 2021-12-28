<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AttemptQuiz.aspx.cs" Inherits="Quiz_Web_App.AttemptQuiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
                                    <asp:RadioButtonList ID="rbl1" runat="server">
                                        <asp:ListItem Value="Op1" Text='<%#Eval("Option1") %>' GroupName="q1"/>
                                        <asp:ListItem Value="Op2" Text='<%#Eval("Option2") %>' GroupName="q1"/>
                                        <asp:ListItem Value="Op3" Text='<%#Eval("Option3") %>' GroupName="q1"/>
                                        <asp:ListItem Value="Op4" Text='<%#Eval("Option4") %>' GroupName="q1"/>
                                    </asp:RadioButtonList>
                                    
                                    <br />
                                    <asp:Label ID="LabCorrectAns" runat="server" Text='<%#Eval("AnsId") %>' Visible="false"></asp:Label>
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
</asp:Content>
