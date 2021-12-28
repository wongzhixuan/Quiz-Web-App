<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manage Class.aspx.cs" Inherits="Quiz_Web_App.WebForm2" %>

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
                    <li class="animation"><a href="#Quiz">Manage Quiz</a></li>
                    <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students Grades</a></li>

                </ul>
            </nav>
        </div>
    </div>
    <div class="container green_container">
        <div class="content-container">
            <asp:Button runat="server" Text="+ New Class" CssClass="btn btn-primary btn_details" ID="createClass" OnClick="createClass_Click" />
            <br />

            <div class="class-table">
                <center>
                    <asp:Label runat="server" Text="Class List" Font-Bold="True" Font-Size="Larger"></asp:Label>

                    <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ID="class_view" DataKeyNames="class_id" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table " OnRowCancelingEdit="class_view_RowCancelingEdit" OnRowUpdating="class_view_RowUpdating"  OnRowDeleting="class_view_RowDeleting" OnRowEditing="class_view_RowEditing" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                        <Columns>
                            <%--
                            <asp:TemplateField HeaderText="Name" SortExpression="name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="city">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("city") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("city") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="class_name" HeaderText="Name" SortExpression="class_name" />
                            <asp:BoundField DataField="class_description" HeaderText="Description" SortExpression="class_description" />
                            <asp:BoundField DataField="created_date" HeaderText="Created" SortExpression="created_date" />
                            <asp:CommandField ButtonType="Button" ShowEditButton="True"  ControlStyle-CssClass="btn btn-primary">
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True"  ControlStyle-CssClass="btn btn-primary">
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                            </asp:CommandField>
                        </Columns>

                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    
                    </center>
            </div>


        </div>
    </div>
</asp:Content>
