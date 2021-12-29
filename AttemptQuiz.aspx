<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="Quiz_Web_App.AttemptQuiz" CodeBehind="AttemptQuiz.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container green_container">
            <div class="content-container">
            <center>
                    <ItemTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="false" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Question" >
                                    <ItemTemplate>
                                        <tr>
                                        <hr />
                                        <asp:Label ID="Qid" runat="server" Width="10px" Text='<%#Eval("Ques_id") %>' />. 
                                        <asp:Label ID="Question" runat="server" Width="600px" Text='<%#Eval("Title") %>' />
                                        <hr />
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option1" >
                                    <ItemTemplate>
                                        <tr>
                                        <hr />
                                            <asp:RadioButton ID="Op1" runat="server" Width="100px" Text='<%#Eval("Option1") %>' GroupName="Option"/>
                                        <hr />
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option2" >
                                    <ItemTemplate>
                                        <tr>
                                        <hr />
                                            <asp:RadioButton ID="Op2" runat="server" Width="100px" Text='<%#Eval("Option2") %>' GroupName="Option"/>
                                        <hr />
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option3" >
                                    <ItemTemplate>
                                        <tr>
                                        <hr />
                                            <asp:RadioButton ID="Op3" runat="server" Width="100px" Text='<%#Eval("Option3") %>' GroupName="Option"/>
                                        <hr />
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option4" >
                                    <ItemTemplate>
                                        <tr>
                                        <hr />
                                            <asp:RadioButton ID="Op4" runat="server" Width="100px" Text='<%#Eval("Option4") %>' GroupName="Option"/>
                                        <hr />
                                        </tr>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"/>
            </center>
            </div>
        </div>
</asp:Content>