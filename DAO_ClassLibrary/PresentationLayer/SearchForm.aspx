<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchForm.aspx.cs" Inherits="PresentationLayer.SearchForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 215px;
        }
        .auto-style6 {
            width: 136px;
        }
        .auto-style7 {
            width: 215px;
            height: 137px;
        }
        .auto-style9 {
            height: 137px;
        }
        .auto-style11 {
            width: 352px;
        }
        .auto-style12 {
            width: 215px;
            height: 23px;
        }
        .auto-style13 {
            width: 136px;
            height: 23px;
        }
        .auto-style14 {
            height: 23px;
        }
        .auto-style15 {
            width: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:Button ID="Btn_Back" runat="server" OnClick="Btn_Back_Click" style="width: 46px" Text="Back" />
                </td>
                <td>
                    <asp:Button ID="Btn_Logout" runat="server" OnClick="Btn_Logout_Click" Text="Logout" />
                </td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td>ID : <asp:Label ID="Lbl_Id" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style11">NAME: <asp:Label ID="Lbl_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Authority Level: <asp:Label ID="Lbl_AuthorityName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Access Level : <asp:Label ID="Lbl_AccessLevel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">Search By AccessLevel</td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_1" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_1_CheckedChanged" Text="Dell" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_2" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_2_CheckedChanged" Text="Acer" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_3" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_3_CheckedChanged" Text="Asus" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_4" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_4_CheckedChanged" Text="HP" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_5" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_5_CheckedChanged" Text="Apple" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb_ALL" runat="server" AutoPostBack="True" GroupName="Brand" OnCheckedChanged="rb_ALL_CheckedChanged" Text="ALL" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td colspan="3" rowspan="2">
                 
 
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
                            
                            <AlternatingRowStyle BackColor="White" />
                            
                            <EditRowStyle BorderStyle="Double" BackColor="#2461BF" />

                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />

                        </asp:GridView>
                 
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
