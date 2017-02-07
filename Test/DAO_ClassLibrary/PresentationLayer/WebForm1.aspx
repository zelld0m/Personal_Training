<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PresentationLayer.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container">
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class=" text-right">
                                <div class="panel-body">
                                    <asp:Button ID="Button1" runat="server" CssClass="alert-warning" OnClick="Btn_Back_Click" Style="width: 46px" Text="Back" />
                                    <asp:Button ID="Button2" runat="server" CssClass="label-danger" OnClick="Btn_Logout_Click" Text="Logout" />
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class=" text-center">
                                    <div class="auto-style15">&nbsp;</div>
                                    <label style="font-size: small"  class="control-label">ID:</label>
                                    <asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
                                   <label style="font-size: small" class="control-label">Name:</label>
                                    <asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
                                    <label style="font-size: small" class="control-label">Authority Level:</label>
                                    <asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
                                    <label style="font-size: small" class="control-label">Access Level:</label>
                                    <asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
