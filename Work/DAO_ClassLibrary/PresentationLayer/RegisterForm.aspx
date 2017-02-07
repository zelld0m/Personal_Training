<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="PresentationLayer.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 144px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>ID:<asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style2">Name:<asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td>AurthorityName:<asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>AccessLevel:<asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnLogout" runat="server" Text="LogOut" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label class ="col-xs-11">Name</label>
                    <asp:TextBox ID="_Tb_Name" runat="server" Class ="form-control" placeholder ="Name"></asp:TextBox>
                </td>
                <td>
                    <label class ="col-xs-11">AuthorityName</label>
                    <asp:TextBox ID="_Tb_AuthorityName" runat="server" Class ="form-control" placeholder ="Name"></asp:TextBox>
                </td>
                <td><label class ="col-xs-11">AccessLevel</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="93px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Btn_Clear" runat="server" Text="Clear" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Btn_Save" runat="server" OnClick="Btn_Save_Click" Text="Save" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
