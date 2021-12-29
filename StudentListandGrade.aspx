<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentListandGrade.aspx.cs" Inherits="Quiz_Web_App.Student_List_Grade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student List and Grade</title>
    <style type="text/css">
        div{
            align-items: center;
        }
        ul{
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: black;
        }
        li{
            float: left;
        }
        li a{
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }
        li a:hover{
            background-color: whitesmoke;
            color: black;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <li><a>XXX Student System</a></li>
            <li><a>Student List & Grade</a></li>
            <li><a>Anouncement Quiz</a></li>
        </ul>
        <asp:Label ID="Label1" runat="server" Text="Student List" Font-Bold="True" Font-Size="Large"></asp:Label>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Class Name: "></asp:Label>
            <asp:DropDownList ID="Class" runat="server">
                <asp:ListItem>--classname--</asp:ListItem>
                <asp:ListItem>...</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="Quiz Name: "></asp:Label>
            <asp:DropDownList ID="Quiz" runat="server">
                <asp:ListItem>--quizname--</asp:ListItem>
                <asp:ListItem>...</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumn="True" AllowPaging="True" AllowSorting="True"
            DataKeyNames="StudentID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

            <Columns>
                <asp:TemplateField HeaderText="No."
                      SortExpression="No." />
                <asp:TemplateField  HeaderText="Student ID"
                      SortExpression="student_id" />
                <asp:TemplateField  HeaderText="Name"
                      SortExpression="FullName" />
                <asp:TemplateField  HeaderText="Grade"
                      SortExpression="Grade" />
                <asp:TemplateField  HeaderText="Score"
                     SortExpression="Score" />
            </Columns>
        </asp:GridView>
        <div><asp:Button ID="Button1" runat="server" Text="Download" OnClick="download"/></div>

    </form>
</body>
</html>
