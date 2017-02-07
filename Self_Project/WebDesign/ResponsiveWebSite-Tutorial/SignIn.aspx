<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ResponsiveWebSite_Tutorial.SignIn" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!--------------SIGN IN START----------->
        <div>
            <div class="container">
                <div class="form-horizontal">
                    <h2>Log In</h2>
                    <hr />
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Tb_UserName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" cssclass="text-danger" ErrorMessage="The Username Field is Required" ControlToValidate="Tb_UserName"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Tb_Password" runat="server" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" cssclass="text-danger" ErrorMessage="The Password Field is Required" ControlToValidate="Tb_Password"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Label ID="Label3" runat="server" CssClass=" control-label" Text="Remember me ?"></asp:Label>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-default" />
                        </div>
                    </div>


                </div>
            </div>
        </div>
        <!------------- SIGN IN END -------------->
</asp:Content>





