<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PresentationLayer.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
                <td class="auto-style7">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style5">
                                <asp:Button ID="Btn_Back" BorderStyle="Outset" CssClass="alert-warning" runat="server" OnClick="Button1_Click" Text="Back" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_Logout" CssClass="alert-danger" runat="server" OnClick="Btn_Logout_Click" Text="Logout" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="GetStatus" OnClick="Button1_Click1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>ID:<asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style6">NAME:
                    <asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style4">AUTHORITY NAME :
                    <asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>ACCESS LEVEL :<asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>

        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    </asp:GridView>
                </td>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Btn_refresh" runat="server" OnClick="Btn_AuthorityName_Click" Text="Refresh" Width="28px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="_Tb_ID" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="_Tb_Name" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="_Tb_AuthorityName" runat="server" class="form-control" placeholder="AuthorityName"></asp:TextBox>
                </td>
                <td>

                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="3"></asp:ListItem>
                        <asp:ListItem Value="4"></asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Btn_Clear" runat="server" OnClick="Btn_Clear_Click" Text="Clear" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">ID</td>
                <td class="auto-style3">Name</td>
                <td>AuthorityName</td>
                <td>AccessLevel</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="_BtnAdd" runat="server" OnClick="_BtnAdd_Click" Style="height: 26px" Text="add" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="_BtnSearch" runat="server" OnClick="_BtnSearch_Click" Text="Search" />
                </td>
                <td>
                    <asp:Button ID="_BtnUpdate" runat="server" OnClick="_BtnUpdate_Click" Text="Update" />
                </td>
                <td>
                    <asp:Button ID="_btnDelete" runat="server" OnClick="_btnDelete_Click" Text="Delete" />
                </td>

            </tr>
        </table>

    </div>
</asp:Content>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 201px;
        }
        .auto-style3 {
            width: 60px;
        }
        .auto-style4 {
            width: 362px;
        }
        .auto-style5 {
            width: 157px;
        }
        .auto-style6 {
            width: 227px;
        }
        .auto-style7 {
            height: 59px;
        }
        .auto-style8 {
            width: 227px;
            height: 59px;
        }
        .auto-style9 {
            width: 362px;
            height: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    </form>
</body>
</html>--%>
