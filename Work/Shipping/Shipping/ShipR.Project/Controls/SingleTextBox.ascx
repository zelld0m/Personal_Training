<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleTextBox.ascx.cs" Inherits="Shipr.lib.SingleTextBox"%>
<fieldset>
	<h3 class="headerSteps"><asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>		
	<asp:PlaceHolder ID="uxSingleTextBox" runat="server" Visible="true">	
	     <asp:Label ID="uxLabel" runat="server">Promo Name: </asp:Label>*
		<asp:TextBox ID="uxValue" runat="server"  Width="300px"  MaxLength="50"></asp:TextBox>
	</asp:PlaceHolder>
</fieldset>
