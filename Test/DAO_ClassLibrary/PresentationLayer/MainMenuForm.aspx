<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenuForm.aspx.cs" Inherits="PresentationLayer.MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 480px;
        }
        .auto-style3 {
            width: 143px;
        }
        .auto-style4 {
            width: 83px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       



        </container>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="Btn_Admin" runat="server" OnClick="Btn_Admin_Click" style="height: 26px" Text="Admin" />
                </td>
                <td>
                    <asp:Button ID="Btn_Logout"  runat="server" CssClass="auto-style4"  OnClick="Btn_Logout_Click" Text="Logout" />
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style1">
            <tr>
                <td>ID:<asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Name:
                    <asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td>AuthorityName:<asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Access Level :
                    <asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Btn_Registration" runat="server" OnClick="Btn_Registration_Click" style="height: 26px" Text="Register Form" />
                </td>
                <td>
                    <asp:Button ID="Btn_Delete" runat="server" Text="Delete Form" OnClick="Btn_Delete_Click" />
                </td>
                <td>
                    <asp:Button ID="Btn_Update" runat="server" Text="Update Form" OnClick="Btn_Update_Click" />
                </td>
                <td>
                    <asp:Button ID="Btn_Search" runat="server" OnClick="Btn_Search_Click" Text="Search Product Form" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
