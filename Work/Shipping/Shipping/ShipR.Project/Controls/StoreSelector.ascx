<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StoreSelector.ascx.cs" inherits="Shipr.lib.StoreSelector" %>
<fieldset>
	<h3 class="headerSteps"><asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>
	<asp:CheckBoxList ID="uxList" runat="server" RepeatColumns="5" 
		RepeatDirection="Horizontal"></asp:CheckBoxList>
</fieldset>
