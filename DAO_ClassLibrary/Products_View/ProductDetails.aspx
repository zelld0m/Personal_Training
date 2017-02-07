<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="UsingStreamReader.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="Content/Bootstrap/css/bootstrap.css" type="text/css" rel="stylesheet" />
    <script src="Content/Bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="Content/Bootstrap/js/jquery.js" type="text/javascript"></script>
    
    </head>
<body>
    <form id="form1" runat="server">
    

        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-info">
                        <div class="panel-body">

                            <div class="form-inline text-right">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>75</asp:ListItem>
                                    <asp:ListItem>100</asp:ListItem>
                                    <asp:ListItem>150</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="BtnALL" runat="server" OnClick="BtnALL_Click" Text="All" CssClass="btn btn-success" />
                                <asp:TextBox ID="TB_Search" runat="server" OnTextChanged="TB_Search_TextChanged" CssClass="form-control" placeholder="SEARCH"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Search" CssClass="btn btn-info" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class=" col-sm-3">
                    <div class="panel panel-danger">
                        <div class="panel-body">
                            <asp:Label ID="NumberFound" runat="server" Text="Found: "></asp:Label>
                            <br />
                            <asp:RadioButtonList ID="rdbtnlst_Brand" runat="server" OnSelectedIndexChanged="rdbtnlst_Brand_SelectedIndexChanged" AutoPostBack="True" Style="left: 0px; top: 0px"></asp:RadioButtonList>
                            <br />
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                        </div>
                    </div>
                </div>
                <div class=" col-sm-5">
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-success">
                        <div class="panel-body">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
