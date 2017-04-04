<%@ Page Language="C#" MasterPageFile="~/ShipR.Project/Default.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Shipr.List" %>
<asp:Content ID="DefaultContent" ContentPlaceHolderID="uxContent" runat="server">

	<script type="text/javascript">
            
        function Check(parentChk)        {    
        
            var elements =  document.getElementsByTagName("INPUT");

            for(i=0; i<elements.length;i++)
            {
                if(parentChk.checked == true)
                { 
                    if( IsCheckBox(elements[i]) && 
                        IsMatch(elements[i].id))
                    {
                        elements[i].checked = true;
                    }        
                }
                else 
                {
                    elements[i].checked = false;
                }      
            }   
        }
        var pattern = '^ctl00_uxContent_gridPromos';//'^ctl00$uxContent$gridPromos';//
        
        function IsMatch(id)
        {
            var regularExpresssion = new RegExp(pattern);
            // ADDED
            // return  id.match(regularExpresssion) ? true : false;

            if (id.match(regularExpresssion))
                return true;
            else
                return false;
        }
        
        function IsCheckBox(chk)
        {
            if(chk.type == 'checkbox') 
                return true;
            else
                return false;
        }
</script>

    <h2 class="style1">Active Promotions</h2>
	<table align="center" atomicselection="False">
	    <tr align="right">
			<td valign="top"  style=" text-align:right" > 
	                  <asp:CheckBox ID="chkShowAll" runat="server" AutoPostBack="True" 
                          Text="Show Inactive" oncheckedchanged="chkShowAll_CheckedChanged" />
			</td>
		</tr>
		<tr>
			<td valign="top" width="200px" class="style1">
		
					<asp:GridView ID="gridPromos" runat="server" AllowPaging="True" 
                        AllowSorting="True" OnPageIndexChanging="gridView_PageIndexChanging" 
                    OnSorting="gridView_Sorting" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False" Width="775px">
                    	<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                    
                    	<Columns>
                    	    <asp:TemplateField>
                            <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" 
                                onclick="Check(this)" disabled="<%# (!_allowedWrite) %>" />
                            </HeaderTemplate>

                            <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" Visible="<%# _allowedWrite %>" />
                            </ItemTemplate>

                    </asp:TemplateField>
             
					   <asp:HyperLinkField 
					   DataNavigateUrlFields="PromoID" DataNavigateUrlFormatString="~/ShipR.Project/Setup.aspx?promoID={0}"
					   Text="Edit" />
					     	
					     	   <asp:BoundField DataField="promoID"  HeaderText="ID" SortExpression="PromoID"  >
                    	
                            </asp:BoundField>
					 <asp:TemplateField HeaderText="Name"  ControlStyle-Width="200" SortExpression="Name">
							<ItemTemplate>
								<%# Eval("Name") %>
					        </ItemTemplate>

                        <ControlStyle Width="200px"></ControlStyle>
						</asp:TemplateField> 				
						<asp:TemplateField HeaderText="Promo Type" SortExpression="PromoTypeDesc">
							<ItemTemplate>
								<%# Eval("PromoTypeDesc") %>
							</ItemTemplate>
						</asp:TemplateField> 
						<asp:TemplateField HeaderText="Shipping Method" SortExpression="Display">
							<ItemTemplate>
								<%# Eval("Display") %>
							</ItemTemplate>
						</asp:TemplateField> 
						<asp:TemplateField HeaderText="Discount Type" SortExpression="DiscountTypeDesc">
							<ItemTemplate>
								<%# Eval("DiscountTypeDesc") %>
							</ItemTemplate>
						</asp:TemplateField> 						
						<asp:TemplateField HeaderText="Status" SortExpression="Status">
							<ItemTemplate>
								<%# Convert.ToBoolean(Eval("Status")) %>
							</ItemTemplate>
						</asp:TemplateField> 
					        <asp:CheckBoxField />
					</Columns>
					    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
					</asp:GridView>
					
			
			</td>
		</tr>
		   <tr align="right">
			<td valign="top"  style=" text-align:left" > 
	              <asp:Button runat="server" ID="btnUpdateStatusTrue" Font-Size="X-Small" Height="24px" 
                      onclick="btnUpdateStatusTrue_Click" Text="Set Active" Width="94px" 
                      Enabled="False" />
			&nbsp;<asp:Button runat="server" ID="btnUpdateStatusFalse" Font-Size="X-Small" Height="24px" 
                      onclick="btnUpdateStatusFalse_Click" Text="Set In-Active" Width="94px" />
			</td>
		</tr>
	</table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="uxHead">
	<style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
