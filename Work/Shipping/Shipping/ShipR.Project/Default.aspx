<%@ Page Language="C#" MasterPageFile="~/ShipR.Project/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shipr._Default" %>
<asp:Content ID="DefaultContent" ContentPlaceHolderID="uxContent" runat="server">
	<h2>Welcome</h2>
	<dl>
		<dt><a href="Setup.aspx">Setup</a></dt>
		<dd>Create or update a promotion</dd>

		<dt><a href="List.aspx">List</a></dt>
		<dd>View a list of active promotions</dd>
	</dl>
</asp:Content>