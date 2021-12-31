<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="Quiz_Web_App.AttemptQuiz" CodeBehind="AttemptQuiz.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container green_container">
        <div class="content-container">
            <asp:Label ID="Label2" runat="server" Text="Class Name: "></asp:Label>
            <asp:DropDownList ID="ddl_class" runat="server" CssClass="btn btn-outline-primary dropdown-toggle"
                OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="-1">--classname--</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Label3" runat="server" Text="Quiz Name: "></asp:Label>
            <asp:DropDownList ID="ddl_quiz" runat="server" CssClass="btn btn-outline-primary dropdown-toggle">
                <asp:ListItem Value="-1">--quizname--</asp:ListItem>

            </asp:DropDownList>
            <div class="form-group w-50">
                <asp:Button ID="btn_getData" runat="server" Text="Submit" CssClass="btn btn-primary float-end" OnClick="btn_getData_Click" Width="77px" />
            </div>
            <br />
            <br />
            <br />
            <div class="quiz">
                <br />
                <div class="quiz_score">
                    <asp:Label ID="Score" runat="server" Text=""></asp:Label><br />
                    <br />
                </div>
                <div class="quiz_content">
                    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" CssClass="grid_quiz" AutoGenerateColumns="false" BorderColor="Black" BorderWidth="1px">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="60%">
                                <ItemTemplate>
                                    <div class="quiz_question">
                                        <asp:Label runat="server" Text="Question"></asp:Label>
                                        <asp:Label ID="Ques_id" runat="server" Text='<%#Eval("Ques_id") %>'></asp:Label>.
                                        <asp:Label runat="server" Text="(Score: "></asp:Label>
                                        <asp:Label ID="Points" runat="server" Text='<%#Eval("Score") %>'></asp:Label>
                                        <asp:Label runat="server" Text=")"></asp:Label>
                                        <br />
                                        <asp:Label ID="Title" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="40%">
                                <ItemTemplate>
                                    <div class="quiz_option">
                                        <asp:RadioButton class="radio" runat="server" ID="Op1" Text='<%#Eval("Option1") %>' GroupName="Options" /><br />
                                        <asp:RadioButton class="radio" runat="server" ID="Op2" Text='<%#Eval("Option2") %>' GroupName="Options" /><br />
                                        <asp:RadioButton class="radio" runat="server" ID="Op3" Text='<%#Eval("Option3") %>' GroupName="Options" /><br />
                                        <asp:RadioButton class="radio" runat="server" ID="Op4" Text='<%#Eval("Option4") %>' GroupName="Options" /><br />
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="SelectedAns" runat="server" Text=""></asp:Label><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <asp:Button CssClass="btn_submit" ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" /><br />
            </div>
        </div>
    </div>
</asp:Content>
