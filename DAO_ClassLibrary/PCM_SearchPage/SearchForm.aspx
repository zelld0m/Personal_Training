<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchForm.aspx.cs" Inherits="PCM_SearchPage.SearchForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/bootstrap-3.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/checkbox.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/site.css" rel="stylesheet" type="text/css" />
    <script src="Content/js/jquery-3.1.1.js" type="text/javascript"></script>
    <script src="Content/js/tether.js" type="text/javascript"></script>
    <script src="Content/js/bootstrap.js" type="text/javascript"></script>
    <link href="Content/css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <br />
        <br />
        <div class="container">
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class=" text-center">
                                <asp:LinkButton ID="lnkbtn_ClearFilter" runat="server" CssClass="btn btn-danger" Font-Size="Small" OnClick="lnkbtn_ClearFilter_Click"><i class="fa fa-times"></i> Clear Filter</asp:LinkButton>
                            </div>
                            <asp:RadioButtonList ID="rdbtnlst_Brand" runat="server" CssClass="radio radio-info" AutoPostBack="True" Font-Size="Small" Font-Overline="False" CellPadding="-1" CellSpacing="1" OnSelectedIndexChanged="rdbtnlst_Brand_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class="form-inline">
                                <div class="pull-left">
                                      <asp:Label CssClass="control-label" ID="lbl_Min" runat="server" Text="Min"></asp:Label>
                                   &nbsp;
                                    <asp:Label CssClass="control-label" ID="labelnone" runat="server" Text="To"> </asp:Label>
                                    &nbsp;
                                   
                                    <asp:Label CssClass="control-label" ID="lbl_MAX" runat="server" Text="MAX"> </asp:Label>
                                     &nbsp;
                                     
                                    <label style="font-size: small" class="control-label">Product Found:</label>
                                    <asp:Label CssClass="control-label" ID="lbl_NumFound" runat="server" Text='' Font-Size="Small">0</asp:Label>
                                </div>
                                <div class="pull-right">
                                    
                                  
                                    <label style="font-size: small" class="control-label">View: </label>
                                  
                                    <asp:DropDownList ID="drpdwnlst_View" runat="server" CssClass="form-control" AutoPostBack="true" Font-Size="Small" OnSelectedIndexChanged="drpdwnlst_View_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="Btn_PagePrevious" runat="server" CssClass=" btn btn-info" OnClick="Btn_PagePrevious_Click"><</asp:LinkButton>
                                        </span>
                                        <asp:Label ID="lbl_PageNumber" runat="server" CssClass=" form-control">1</asp:Label>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="btn_PageNext" runat="server" CssClass=" btn btn-info" OnClick="btn_PageNext_Click">></asp:LinkButton>
                                        </span>
                                    </div>
                                    <div class="input-group">
                                        <asp:TextBox ID="txt_Search" runat="server" CssClass=" form-control" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnbtn_Search" runat="server" CssClass=" btn btn-success" OnClick="lnbtn_Search_Click">Search</asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                              
                            </div>
                        </div>
                    </div>
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <label style="font-size: small">Search Keyword:</label>
                            <asp:Label CssClass="form-control-label" ID="lbl_KeyWordSearch" runat="server" Text='' Font-Size="Small">None</asp:Label>
                        </div>
                    </div>
                    <!--CONTROLS DETAILS-->
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            
                            <div class="col-sm-8" style="text-align: left">
                               <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>
                           
                           
                        </div>
                    </div>
                    <hr />
                    <!--END CONTROLS DETAILS-->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
