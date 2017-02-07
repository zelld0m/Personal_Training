<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateForm.aspx.cs" Inherits="PresentationLayer.UpdateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 190px;
        }
        .auto-style4 {
            width: 124px;
        }
        .auto-style5 {
            width: 186px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Btn_Back" runat="server" OnClick="Button1_Click" Text="Back" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:Button ID="Btn_Logout" runat="server" OnClick="Btn_Logout_Click" Text="Logout" />
                            </td>
            </tr>
            <tr>
                <td class="auto-style4">ID: <asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5">NAME:
                    <asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style2">AUTHORITY NAME : <asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>ACCESS LEVEL:
                    <asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:TextBox ID="_Tb_ID" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="_Tb_Name" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="_Tb_AuthorityName" runat="server"></asp:TextBox>
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
            </tr>
            <tr>
                <td>ID</td>
                <td>NAME</td>
                <td>AUTHORITYNAME</td>
                <td>ACCESSLEVEL</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="_BtnUpdate" runat="server" OnClick="_BtnUpdate_Click" Text="Update" />
                </td>
                <td>
                    <asp:Button ID="Btn_Clear" runat="server" OnClick="Btn_Clear_Click" Text="Clear" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
