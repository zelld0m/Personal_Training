<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PromoType.ascx.cs" Inherits="Shipr.lib.PromoType" %>
<fieldset>
    <h3 class="headerSteps">
        <asp:Literal ID="uxTitle" runat="server"></asp:Literal></h3>

    Promo Type*:
    <asp:DropDownList ID="uxType" runat="server" AutoPostBack="True"
        OnSelectedIndexChanged="uxType_SelectedIndexChanged">
    </asp:DropDownList>&nbsp;&nbsp;
	
    <asp:CheckBox ID="chkExactPromo" Checked="true" runat="server" />
    Exact Promo/Full Order
		
	

    <hr />

    <asp:PlaceHolder ID="uxOrderLevel" runat="server" Visible="false">
        <table border="1" cellpadding="0">
            <tr>
                <td>
                    <div runat="server" id="divDollarMin">
                        Orders From* $<asp:TextBox ID="uxDollarMin" MaxLength="8" runat="server" Width="70">0</asp:TextBox>
                        To* $<asp:TextBox ID="uxDollarMax" MaxLength="8" runat="server" Width="70">50000</asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="divWeightMax">
                        Weight From lbs.*<asp:TextBox ID="uxWeightMin" MaxLength="7" runat="server" Width="70">0</asp:TextBox>
                        To lbs.*<asp:TextBox ID="uxWeightMax" MaxLength="7" runat="server" Width="70">200</asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="divIncreasePercent" visible="false">
                        <table border="1" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="drpIncreaseBox" runat="server"
                                        OnSelectedIndexChanged="drpIncreaseBox_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="0"> Increase By Percent </asp:ListItem>
                                        <asp:ListItem Value="1"> Increase by Dollar </asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="uxIncreasePercent" MaxLength="4" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="uxIncreaseDollar" MaxLength="4" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Threshold Weight:*</td>
                                <td>
                                    <asp:TextBox ID="uxIncreaseWeightThreshold" MaxLength="7" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Threshold Dollar:*</td>
                                <td>
                                    <asp:TextBox ID="uxIncreaseDollarThreshold" MaxLength="7" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <hr />
    </asp:PlaceHolder>
    <!--Discount Type-->
    <asp:PlaceHolder ID="uxDiscountType" runat="server">
        <table border="1" cellpadding="0">
            <tr>
                <td>Discount Type*:<asp:DropDownList ID="ddlDiscountType" runat="server"
                    OnSelectedIndexChanged="uxDiscountType_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="uxDiscountLabel" runat="server">Discount Value*:</asp:Label>
                    <asp:TextBox ID="uxDiscountValue" runat="server" MaxLength="7" Width="70"></asp:TextBox>
                </td>
            </tr>
        </table>
        <hr />
    </asp:PlaceHolder>
    <!--Skus-->
    <asp:PlaceHolder ID="uxDetails" runat="server" Visible="false">
        <table border="1" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="uxLabel" runat="server">Sku*:</asp:Label>
                    <asp:TextBox ID="txtSku" runat="server" Width="60" MaxLength="8"></asp:TextBox>

                </td>
                <td>
                    <input id='btnAddSku' type='button' value='Add' width: "70" onclick="javascript:AddSkuToListBox();" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox CausesValidation="true" ID="listSkus" runat="server" Width="100" Height="150"></asp:ListBox>
                    <input type='hidden' id='hiddenSkus' runat="server" />
                </td>
                <td valign='top'>
                    <input id='btnRemoveSku' runat="server" type='button' value='Remove' onclick="javascript:RemoveSkuFromListBox();" />
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>

    <!--Category Codes-->
    <asp:PlaceHolder ID="uxCategoryCodes" runat="server" Visible="false">
        <table border="0" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="uxLabelCategorycodes" runat="server">Category Codes:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="uxLabelSelectedCategory" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="uxLabelCategory" runat="server">Category*</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="uxDrpCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="uxCategoryCodes_SelectedIndexChanged" Width="300"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="uxLabelSubMajor" runat="server" Visible="false">SubMajor</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="uxDrpSubMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="uxSubMajor_SelectedIndexChanged" Visible="false" Width="300"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="uxLabelMinor" runat="server" Visible="false">Minor</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="uxDrpMinor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="uxMinor_SelectedIndexChanged" Visible="false" Width="300"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="uxLabelSubMinor" runat="server" Visible="false">SubMinor</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="uxDrpSubMinor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="uxSubMinor_SelectedIndexChanged" Visible="false" Width="300"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    <!--Manufacturers-->
    <asp:PlaceHolder ID="uxManufacturers" runat="server" Visible="false">
        <table border="1" cellpadding="1">
            <tr>
                <td colspan="3">
                    <asp:Label ID="uxLabelManufacturers" runat="server">Manufacturer*:</asp:Label>
                    <asp:Label ID="uxLabelSelectedManufacturer" runat="server" Font-Bold="true" Visible="false"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="uxDdlManufacturers" runat="server" SelectionMode="Multiple" Height="300px" Width="180px"></asp:ListBox>
                    <input type='hidden' id='hiddenManufacturers' runat="server" />
                </td>
                <td>
                    <input type='button' value=">>" onclick='moveManufacturerRight()'>
                    <br />
                    <input type='button' value="<<" onclick='moveManufacturerLeft()'>
                </td>
                <td>
                    <asp:ListBox ID="uxDdlManufacturersSelected" runat="server" SelectionMode="Multiple" Height="300px" Width="180px"></asp:ListBox>
                </td>

            </tr>
            <tr>
                <td style="font-size: x-small" colspan="3">Tip:Hold down CTRL key to select/unselect 
                    <br />
                    multiple manufacturers
			    </td>
            </tr>
        </table>
        <br />
    </asp:PlaceHolder>
    <!--Payment-->
    <asp:PlaceHolder ID="uxPaymentMethod" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:Label ID="uxLabelPaymentMethod" runat="server">Payment Method*:</asp:Label><asp:Label ID="uxLabelSelectedPayment" runat="server" Font-Bold="true"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="uxDdlPaymentMethod" runat="server" SelectionMode="Multiple" Height="180" Width="250px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-small">Tip:Hold down CTRL key to select/unselect 
                    <br />
                    multiple payment methods
				</td>
            </tr>
        </table>
        <br />
    </asp:PlaceHolder>

</fieldset>
