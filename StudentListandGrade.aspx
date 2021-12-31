<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentListandGrade.aspx.cs" Inherits="Quiz_Web_App.Student_List_Grade" %>
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
                            <li class="animation" style="margin-top: 5px"><a href="#Student">Student Grades</a></li>

                        </ul>
                    </nav>
                </div>
            </div>

    <%-- The Main Content Container--%>
    <div class="container green_container">
    <div class="content-container">
        
        <asp:Label ID="Label1" runat="server" Text="Student List & Grade" Font-Bold="True" Font-Size="Large"></asp:Label>
        <div class="student_list">
            <asp:Label ID="Label2" runat="server" Text="Class Name: "></asp:Label>
            <asp:DropDownList ID="ddl_class" runat="server" CssClass="btn btn-outline-primary dropdown-toggle" 
                OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" AutoPostBack="True" >
                <asp:ListItem Value="-1">--classname--</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Label3" runat="server" Text="Quiz Name: " ></asp:Label>
            <asp:DropDownList ID="ddl_quiz" runat="server" CssClass="btn btn-outline-primary dropdown-toggle">
                <asp:ListItem Value="-1">--quizname--</asp:ListItem>

            </asp:DropDownList>
                
            <div class="form-group w-50">
                <asp:Button ID="btn_getData" runat="server" Text="Submit" CssClass="btn btn-primary float-end" OnClick="btn_getData_Click" Width="77px" />
            </div>
            <br />
            <br />
            <br />
            <div>
                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>
                <asp:Label ID="SuccessMessage" runat="server" Text="L" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
            </div>

            <br />
        </div>
        <asp:GridView ID="studentList_view" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" 
            DataKeyNames="student_id" CellPadding="4" ForeColor="#333333" GridLines="None"
            CssClass="table" OnSorting="class_view_Sorting" OnPageIndexChanging ="class_view_PageIndexChanging" 
            OnSelectedIndexChanging="class_view_SelectedIndexChanging" Style="width:50%; margin-left:50px; margin-right:auto">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:TemplateField HeaderText="Student ID" SortExpression="student_id">
                    <ItemTemplate>
                        <asp:Label ID="tx_studentid" runat="server" Text='<%#Bind("student_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="student_name">
                    <ItemTemplate>
                        <asp:Label ID="tx_name" runat="server" Text='<%#Bind("student_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score" SortExpression="student_score" >
                    <ItemTemplate>
                        <asp:Label ID="tx_score" runat="server" Text='<%#Bind("student_score") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Download" OnClick="download" /></div>
        </div>

        </div>
</asp:Content>
