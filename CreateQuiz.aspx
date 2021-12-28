<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateQuiz.aspx.cs" Inherits="Quiz_Web_App.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <li class="animation" style="margin-top: 5px"><a href="#Student">Manage Students </a></li>

                        </ul>
                    </nav>
                </div>
            </div>
    <div class="container green_container">
        <div class="content-container">
            <div class="form-control">
                <asp:Label ID="form_header" runat="server" Text="Create new Quiz" CssClass="feature-title"></asp:Label>
                <asp:HiddenField ID="hfQuizID" runat="server" />
                <div class="form-group">

                    <asp:Label ID="lb_title" runat="server" Text="Title" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txt_title" runat="server" placeholder="Quiz Title" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="This will be the title of the quiz." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lb_descrip" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txt_description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Description"></asp:TextBox>
                </div>
                <div class="form-group w-50">
                    <asp:Label ID="lb_Class" runat="server" Text="Class" CssClass="form-label"></asp:Label>
                    <div class="dropdown">
                    <asp:DropDownList ID="dropdown_class" runat="server" CssClass=" btn btn-primary dropdown-toggle"  AppendDataBoundItems="true"  >
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                    </asp:DropDownList>
                        
                        </div>
                    <asp:Label ID="Label5" runat="server" Text="Which class the quiz is created for." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group w-50">
                    <asp:Label ID="lb_Score" runat="server" Text="Score" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txt_score" runat="server" placeholder="Total Score" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Please specify the total score of the quiz in number." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group w-50">
                    <asp:Label ID="lb_Start" runat="server" Text="Start Date" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txt_startDate" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Please select the start time for the quiz." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group w-50">
                    <asp:Label ID="lb_End" runat="server" Text="Finish Date" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txt_endDate" runat="server"  CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Please select the date and time for the quiz to end." CssClass="form-text text-muted"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="add_ques" runat="server" Text="Add Questions >" CssClass="btn btn-primary btn_details float-end" OnClick="add_ques_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" Enabled="False" />
                    <asp:Button ID="create_quiz" runat="server" Text="Create Quiz" CssClass="btn btn-primary btn_details float-end" OnClick="create_quiz_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true' ; this.value= 'Please Wait..'" />
                    
                </div>
                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="alert alert-success alert-dismissible fade show" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="alert alert-danger alert-dismissible fade show" Visible="false"></asp:Label>

                <br />
                <br />

            
            <br />
            

            
                </div>
            </div>
        </div>
</asp:Content>
