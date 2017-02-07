<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="PCM_SearchPage.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="Bootstrap/css/bootstrap.css" type="text/css" rel="stylesheet" />
    <script src="Bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="Bootstrap/js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-info">
                        <div class="panel-body">
                          
                            <asp:Label ID="Lbl_SearchFound" runat="server" Text="NumFound"></asp:Label>
                              <div class="form-inline text-right">
                                <asp:Label ID="Lbl_View" runat="server" Text="View:"></asp:Label>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                      <asp:ListItem Selected="True">5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>75</asp:ListItem>
                                    <asp:ListItem>100</asp:ListItem>
                                   
                                </asp:DropDownList>

                                  
                                  <asp:Label ID="lbl_Page" runat="server" Text="Page #"></asp:Label>
                                  <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">0</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                  </asp:DropDownList>


                                <asp:Button ID="Btn_search" runat="server" Text="Search" OnClick="Btn_search_Click"  />
    
                                <asp:TextBox ID="TB_Search" runat="server"></asp:TextBox>
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
                            <asp:Button ID="BtnClearFilter" runat="server" Text="ClearFilter" OnClick="BtnClearFilter_Click" />
                            <br />
                           <br />
                       </div>
                    </div>
                </div>
            </div>
             <div class=" col-sm-5">
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-success">
                        <div class="panel-body">
                            Showing Results for keyword:
                            <asp:Label ID="Lbl_KeySearch" runat="server" Text="SearchSelected"></asp:Label>
                            <br />
                            <br />
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>
                    </asp:Panel>
                </div>
            </div>
      
      </form>
</body>
</html>
