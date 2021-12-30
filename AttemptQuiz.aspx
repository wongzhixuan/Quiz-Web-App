<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="Quiz_Web_App.AttemptQuiz" CodeBehind="AttemptQuiz.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container green_container">
            <div class="content-container">
            <div class="quiz">
                <br />
                <div class="quiz_score">
                    <asp:Label ID="Score" runat="server" Text=""></asp:Label><br />
                    <br />
                </div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table class="quiz_content">
                            <tr>
                                <td class="quiz_question">
                                    <asp:Label runat="server" Text="Question"></asp:Label>
                                    <asp:Label ID="Ques_id" runat="server" Text='<%#Eval("Ques_id") %>'></asp:Label>.
                                    <asp:Label runat="server" Text="(Score: "></asp:Label>
                                    <asp:Label ID="Points" runat="server" Text='<%#Eval("Score") %>'></asp:Label>
                                    <asp:Label runat="server" Text=")"></asp:Label>
                                    <br />
                                    <asp:Label ID="Title" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                </td>
                                <td class="quiz_option">
                                    <br /><asp:RadioButton class="radio" runat="server" ID="Op1" Text='<%#Eval("Option1") %>' GroupName="Options"/><br />
                                    <br /><asp:RadioButton class="radio" runat="server" ID="Op2" Text='<%#Eval("Option2") %>' GroupName="Options"/><br />
                                    <br /><asp:RadioButton class="radio" runat="server" ID="Op3" Text='<%#Eval("Option3") %>' GroupName="Options"/><br />
                                    <br /><asp:RadioButton class="radio" runat="server" ID="Op4" Text='<%#Eval("Option4") %>' GroupName="Options"/><br />
                                    <br />
                                    <asp:Label ID="CorrectAns" runat="server" Text='<%#Eval("AnsId") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center; vertical-align: middle;">
                                    <br />
                                    <asp:Label ID="SelectedAns" runat="server" Text=""></asp:Label><br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <asp:Button CssClass="btn_submit" ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"/><br />
            </div>
            </div>
        </div>
</asp:Content>