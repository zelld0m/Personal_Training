<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultilineText.ascx.cs" inherits="Shipr.lib.MultilineText" %>
<fieldset>
	<h3 class="headerSteps"><asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>
	<asp:TextBox ID="uxInput" runat="server" TextMode="MultiLine"  MaxLength="500"></asp:TextBox>
</fieldset>
