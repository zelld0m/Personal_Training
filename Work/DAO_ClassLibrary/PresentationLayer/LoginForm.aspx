<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PresentationLayer.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Bootstrap/css/Custom-Cs.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 232px;
        }
        .auto-style3 {
            width: 232px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    
    </div>
     
 
        <!-- Textbox and Label-->
         <div class="center-page">
             <asp:GridView ID="GridView1" runat="server">
             </asp:GridView>
                <div class="col-xs-11">
                    <label class ="col-xs-11">Name</label>
                    <asp:TextBox ID="Tb_Name" runat="server" class="form-control" placeholder ="Name"></asp:TextBox>
                </div>
                    <div class="col-xs-11">
                        <label class="col-xs-11">AuthorityName</label>
                        <asp:TextBox ID="Tb_AuthorityName" runat="server" class="form-control" placeholder="AuthoritikkkyName"></asp:TextBox>
                          
                 </div>
             <div class="col-xs-11 space-vert"></div> 
             <asp:Button ID="Btn_Login" runat="server" OnClick="Btn_Login_Click" Text="Login" />
    
                    <asp:Button ID="Btn_Out" runat="server" OnClick="Btn_Out_Click" Text="Check" />
          </div>
            
                  
            <!-- Textbox ,Label,Buttons-->
      
    </form>
</body>
</html>
