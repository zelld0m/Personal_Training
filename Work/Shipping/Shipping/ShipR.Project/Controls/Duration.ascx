<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Duration.ascx.cs" inherits="Shipr.lib.Duration" %>
<fieldset>
	<h3 class="headerSteps"><asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>
	<table border="0">
		<tr>
			<td valign="top">
				Start date*:
				<asp:TextBox ID="uxStartDate" runat="server" onfocus="this.value=='MM/DD/YYYY'?this.value='':null" Width=100px MaxLength="10">MM/DD/YYYY</asp:TextBox>		
                <asp:DropDownList ID="uxStartTime" runat="server">
                    <asp:ListItem Selected="True" Value=""></asp:ListItem>
                    <asp:ListItem Value="0">12:00 AM</asp:ListItem>
                    <asp:ListItem Value="1">01:00 AM</asp:ListItem>
                    <asp:ListItem Value="2">02:00 AM</asp:ListItem>
                    <asp:ListItem Value="3">03:00 AM</asp:ListItem>
                    <asp:ListItem Value="4">04:00 AM</asp:ListItem>
                    <asp:ListItem Value="5">05:00 AM</asp:ListItem>
                    <asp:ListItem Value="6">06:00 AM</asp:ListItem>
                    <asp:ListItem Value="7">07:00 AM</asp:ListItem>
                    <asp:ListItem Value="8">08:00 AM</asp:ListItem>                    
                    <asp:ListItem Value="9">09:00 AM</asp:ListItem>
                    <asp:ListItem Value="10">10:00 AM</asp:ListItem>
                    <asp:ListItem Value="11">11:00 AM</asp:ListItem>
                    <asp:ListItem Value="12">12:00 PM</asp:ListItem>
                    <asp:ListItem Value="13">01:00 PM</asp:ListItem>
                    <asp:ListItem Value="14">02:00 PM</asp:ListItem>
                    <asp:ListItem Value="15">03:00 PM</asp:ListItem>
                    <asp:ListItem Value="16">04:00 PM</asp:ListItem>
                    <asp:ListItem Value="17">05:00 PM</asp:ListItem>
                    <asp:ListItem Value="18">06:00 PM</asp:ListItem>
                    <asp:ListItem Value="19">07:00 PM</asp:ListItem>
                    <asp:ListItem Value="20">08:00 PM</asp:ListItem>
                    <asp:ListItem Value="21">09:00 PM</asp:ListItem>
                    <asp:ListItem Value="22">10:00 PM</asp:ListItem>
                    <asp:ListItem Value="23">11:00 PM</asp:ListItem>                    
                </asp:DropDownList>
			</td>
			<td valign="top">
				End date*:
				<asp:TextBox ID="uxEndDate" runat="server" onfocus="this.value=='MM/DD/YYYY'?this.value='':null" Width=100px  MaxLength="10">MM/DD/YYYY</asp:TextBox>
				 <asp:DropDownList ID="uxEndTime" runat="server">	
				   <asp:ListItem Selected="True" Value=""></asp:ListItem>
                    <asp:ListItem Value="0">12:00 AM</asp:ListItem>
                    <asp:ListItem Value="1">01:00 AM</asp:ListItem>
                    <asp:ListItem Value="2">02:00 AM</asp:ListItem>
                    <asp:ListItem Value="3">03:00 AM</asp:ListItem>
                    <asp:ListItem Value="4">04:00 AM</asp:ListItem>
                    <asp:ListItem Value="5">05:00 AM</asp:ListItem>
                    <asp:ListItem Value="6">06:00 AM</asp:ListItem>
                    <asp:ListItem Value="7">07:00 AM</asp:ListItem>
                    <asp:ListItem Value="8">08:00 AM</asp:ListItem>
                    <asp:ListItem Value="9">09:00 AM</asp:ListItem>
                    <asp:ListItem Value="10">10:00 AM</asp:ListItem>
                    <asp:ListItem Value="11">11:00 AM</asp:ListItem>
                    <asp:ListItem Value="12">12:00 PM</asp:ListItem>
                    <asp:ListItem Value="13">01:00 PM</asp:ListItem>
                    <asp:ListItem Value="14">02:00 PM</asp:ListItem>
                    <asp:ListItem Value="15">03:00 PM</asp:ListItem>
                    <asp:ListItem Value="16">04:00 PM</asp:ListItem>
                    <asp:ListItem Value="17">05:00 PM</asp:ListItem>
                    <asp:ListItem Value="18">06:00 PM</asp:ListItem>
                    <asp:ListItem Value="19">07:00 PM</asp:ListItem>
                    <asp:ListItem Value="20">08:00 PM</asp:ListItem>
                    <asp:ListItem Value="21">09:00 PM</asp:ListItem>
                    <asp:ListItem Value="22">10:00 PM</asp:ListItem>
                    <asp:ListItem Value="23">11:00 PM</asp:ListItem>
                    
                    </asp:DropDownList>		
			</td>
		</tr>
	</table>
</fieldset>
