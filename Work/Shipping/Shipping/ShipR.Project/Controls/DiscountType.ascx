<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiscountType.ascx.cs" Inherits="Shipr.lib.DiscountType"%>


<fieldset>
	<h3><asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>
	<asp:DropDownList ID="uxType" runat="server" 
		onselectedindexchanged ="uxType_SelectedIndexChanged" 
		AutoPostBack="True"></asp:DropDownList>
	<asp:PlaceHolder ID="uxExtra" runat="server" Visible="false">
		Discount value
		<asp:TextBox ID="uxValue" runat="server"  MaxLength="7"></asp:TextBox>
	</asp:PlaceHolder>
</fieldset>
