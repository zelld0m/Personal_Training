<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipleForm.aspx.cs" Inherits="CreatingMultipleItemUsingloop.MultipleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</form>
     </body>
</html>
