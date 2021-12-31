<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageClassStudent.aspx.cs" Inherits="Quiz_Web_App.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightcolumn">
        <div id="sticker">
            <nav>
                <ul id="panel" class="panel">

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
    <div class="container green_container">
        <div class="content-container">

            <asp:Label ID="form_header" runat="server" Text="Class Students" CssClass="feature-title"></asp:Label>

            <asp:GridView ID="student_view" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="student_id" ShowFooter="True" CssClass="table " OnRowDeleting="student_view_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" OnSorting="student_view_Sorting" OnPageIndexChanging="student_view_PageIndexChanging">
                <Columns>

                    <asp:TemplateField HeaderText="ID">

                        <ItemTemplate>
                            <asp:Label ID="student_id" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                        </ItemTemplate>
                        <InsertItemTemplate>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">

                        <ItemTemplate>
                            <asp:Label ID="student_name" runat="server" Text='<%# Bind("student_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">

                        <ItemTemplate>
                            <asp:Label ID="student_email" runat="server" Text='<%# Bind("student_email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" />

                </Columns>
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

            <br />
            <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
        <br />
            <br />
        <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>
            <br />
            <br />
        <br />
            <hr />
            <div class="form-group  w-50">
                <asp:Label ID="class_student" runat="server" Text="Add Students" CssClass="form-label"></asp:Label>

                <asp:TextBox ID="tx_student_id" runat="server" CssClass="w-75 form-control" placeholder="student ID"> </asp:TextBox>
            </div>
            <div class="form-group w-50">
                <asp:Button ID="add_student" runat="server" Text="Add +" UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" OnClick="add_student_Click" CssClass="btn float-end btn-success ms-2 ps-2" Enabled="false" />
                <asp:Button ID="btn_checkStudent" runat="server" Text="Search" OnClick="btn_checkStudent_Click" CssClass="btn btn-outline-primary float-end me-2 " UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" />
            </div>
        
        <div class="form-group">

            <asp:DataList ID="student_data_list" runat="server" CellPadding="4" ForeColor="#333333" RepeatLayout="Table" CellSpacing="3" RepeatColumns="3">
                <ItemTemplate>
                    <table class="table table_custom ">
                        <tr>
                            <th colspan="4" class="col">
                                <b>
                                    <%#Eval("student_name") %>
                                </b>
                            </th>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Student Id: " Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            <td>
                                <%#Eval("student_id") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Email Address: " Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            <td>
                                <%#Eval("student_email")%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#E3EAEB" />
                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
        </div>

        </div>
    </div>
</asp:Content>
