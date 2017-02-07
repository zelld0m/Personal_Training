<%@ Page Language="C#" MasterPageFile="~/ShipR.Project/Default.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Shipr.Setup" MaintainScrollPositionOnPostback="true" %>
<%@ Register src="~/ShipR.Project/Controls/PromoType.ascx" tagname="PromoType" tagprefix="uc1" %>
<%@ Register src="~/ShipR.Project/Controls/StoreSelector.ascx" tagname="StoreSelector" tagprefix="uc2" %>
<%@ Register src="~/ShipR.Project/Controls/Duration.ascx" tagname="Duration" tagprefix="uc4" %>
<%@ Register src="~/ShipR.Project/Controls/ShipMethodSelector.ascx" tagname="ShipMethodSelector" tagprefix="uc5" %>
<%@ Register src="~/ShipR.Project/Controls/MultilineText.ascx" tagname="MultilineText" tagprefix="uc6" %>
<%@ Register src="~/ShipR.Project/Controls/SingleTextBox.ascx" tagname="SingleTextBox" tagprefix="uc7" %>
<%@ Register Src="~/ShipR.Project/Controls/ShipPromoText.ascx" TagName="ShipPromoText" TagPrefix="uc8" %>

<asp:Content ID="DefaultContent" ContentPlaceHolderID="uxContent" runat="server">


<script src="setup.js" type="text/javascript"> </script>

 

   <script  language = "javascript" type="text/javascript" > 
    
function IsNumeric(strString) // this function gets the String and check the digits input string  if it macthes its required value it will  return boolean TRUE 
{
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;
    if (strString.length == 0) return false;
    for (i = 0; i < strString.length && blnResult == true; i++)  // if i < string length and bln == true  do this
        {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1)
            {
                blnResult = false;      //Return Value
            }
        }
        return blnResult;
}

function AddSkuToListBox()
{

     // --------------------------  THIS IS A TEST 
    //var str,
    //    element = document.getElementById('ctl00_uxContent_uxPromoType_txtSku');
    //if (element != null) {
    //    str = element.value;
    //}
    //else {
    //    str = null;
    //} window.alert(str);
    // --------------------------- THIS IS A TEST
    



    //var sku = ux; // == textbox  --------------------------------------CHECK THIS -----------recomended by sir Jhosef-------create a specific id to locate txtbox for input SKU---------------------------------------------
    var sku = document.getElementById("ctl00_uxContent_uxPromoType_txtSku"); // == textbox
   // window.alert("SKU value IS =" + sku.nodeValue + ""); debugger;//cccc
    if(sku.value == (""))     // if txtbox is clear   or  sku is clear
	{
	    alert('Please enter sku in Text Box');
		sku.focus();  // tab on the txtbx
		return false;
    }


	else if(sku.value != "")        // if not Empty
	{
		var vStatus = "0";		
		var vLen =   document.getElementById("ctl00_uxContent_uxPromoType_listSkus").length; // Listbox
		var i;
		if(vLen != 0)  // if listbox  is not equal to  0  do this 
		{
			for(i=0;i< vLen;i++) // if  i is Lesssthan  Listbox
			{
			    var iSku= document.getElementById("ctl00_uxContent_uxPromoType_listSkus").options[i].value; // Listbox
				if(sku.value.toLowerCase() == iSku.toLowerCase())
				{
				    alert("Sku already exists in ListBox.");
				    vStatus = "1";						
				    return false;
				}				    
			}		
		}			
			
		if (IsNumeric(sku.value)==false || sku.value.length<=4 || sku.value.length>8)
		{
			alert("Please enter valid sku.");
			sku.focus();
			return false;
		}
			
		if(vStatus != "1")
		{
			var optn = document.createElement("OPTION");
            optn.text = sku.value;
            optn.value = sku.value;
            document.getElementById("ctl00_uxContent_uxPromoType_listSkus").options.add(optn);
            sku.value = "";
            assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenSkus','ctl00_uxContent_uxPromoType_listSkus');
            return false;
		}	
	}
}   

var varSkuList="";
function assignToHiddenTextBox(hiddenBox, listBox)
{
    varSkuList="";    
	var vLen = document.getElementById(listBox.toString()).length;
	    var i;
		if(vLen != 0)
			{
		    for(i=0;i< vLen;i++)
			   {
			        var iSku= document.getElementById(listBox.toString()).options[i].value;
				    varSkuList = varSkuList + (varSkuList.length>0? "," +  iSku : iSku);
			   }		
			}	
	    document.getElementById(hiddenBox.toString()).value=varSkuList;	
}
//-------------------------------------------------------------------------
function RemoveSkuFromListBox()
{
    if(document.getElementById("ctl00_uxContent_uxPromoType_listSkus").length <=0)   //if  LISTBOX.length <= 0  
    {
       alert("No Text Were Selected to remove.")
       document.getElementById("ctl00_uxContent_uxPromoType_listSkus").focus();
       return false;
    }
    else if(document.getElementById("ctl00_uxContent_uxPromoType_listSkus").selectedIndex < 0)
    {
      alert("Please Select sku to Remove.");
      document.getElementById("ctl00_uxContent_uxPromoType_listSkus").focus();
      return false;
    }
    else
    {
      document.getElementById("ctl00_uxContent_uxPromoType_listSkus").options[document.getElementById("ctl00_uxContent_uxPromoType_listSkus").selectedIndex] = null;
      assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenSkus','ctl00_uxContent_uxPromoType_listSkus');
      return false;
    }
}

function moveManufacturerRight()
{
	var sda = document.getElementById('ctl00_uxContent_uxPromoType_uxDdlManufacturers');
	var len = sda.length;
	var sda1 = document.getElementById('ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
	for(var j=0; j<len; j++)
	{
		if(sda[j].selected==true)
		{
			var tmp = sda.options[j].text;
			var tmp1 = sda.options[j].value;
			if (tmp.length==0)
			{
			    alert("Please select manufacturer.");
			    return false;
			}
			sda.remove(j);
			j--;
			var y=document.createElement('option');
			y.text=tmp;
			y.value=tmp1;
			try
			{
			    sda1.add(y,null);
			    assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenManufacturers', 'ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
			}
			catch(ex)
			{
			    sda1.add(y);
			    assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenManufacturers', 'ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
		
			}
		}
	}
}

function moveManufacturerLeft()
{
	var sda = document.getElementById('ctl00_uxContent_uxPromoType_uxDdlManufacturers');
	var sda1 = document.getElementById('ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
	var len = sda1.length;
	for(var j=0; j<len; j++)
	{	
		if(sda1[j].selected==true)
		{	
			var tmp = sda1.options[j].text;
			var tmp1 = sda1.options[j].value;
			sda1.remove(j);
			j--;
			var y=document.createElement('option');
			y.text=tmp;
			y.value=tmp1;
			try
			{
		    	sda.add(y,null);
			    assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenManufacturers','ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
			    sortManufacturerlist();
			}
			catch(ex)
			{			 
			    sda.add(y);	
			    assignToHiddenTextBox('ctl00_uxContent_uxPromoType_hiddenManufacturers','ctl00_uxContent_uxPromoType_uxDdlManufacturersSelected');
			    sortManufacturerlist();
			}

		}
	}		
}

function sortManufacturerlist() 
{
    var lb = document.getElementById('ctl00_uxContent_uxPromoType_uxDdlManufacturers');
    arrTexts = new Array();
    arrValues = new Array();

    for(i=0; i<lb.length; i++)  {
      arrTexts[i] = lb.options[i].text;
      arrValues[i] = lb.options[i].value;
    }

    arrTexts.sort();

    for(i=0; i<lb.length; i++)  {
      lb.options[i].text = arrTexts[i];
      lb.options[i].value = arrValues[i];
    }
}


       </script>



	<h2>Setup a Promotion</h2>
	
	<div id="uxPromoSetupMessage" runat="server" visible="false" class="error">
		<asp:Literal ID="uxPromoSetupMessageContent" runat="server"></asp:Literal>
	</div>
	<div id="uxPromoInputs" runat="server">
	    <h7>Fields marked with an asterisk (*) are required fields.</h7>
	     <uc7:SingleTextBox ID="uxPromoTypeName" runat="server" Title="1. Set the promo Name" />
	
		<uc1:PromoType ID="uxPromoType" runat="server" Title="2. Set the promo type and discount type" />
		
		
		<uc2:StoreSelector ID="uxStore" runat="server" Title="3. Choose the store/s that the promo applies to" />
		<fieldset style="display: none;">
			<h3>Availability</h3>
			<asp:CheckBoxList ID="uxAvailInput" runat="server" RepeatColumns="4" 
				RepeatDirection="Horizontal">
				<asp:ListItem>Online</asp:ListItem>
				<asp:ListItem>Offline</asp:ListItem>
			</asp:CheckBoxList>
		</fieldset>
		<fieldset style="display: none;">
			<h3>Show on CAP</h3>
			<asp:CheckBox ID="uxShowOnCapInput" runat="server" />
		</fieldset>		
	
		<uc4:Duration ID="uxDuration" runat="server" Title="4. Set the promo duration" />
		<uc5:ShipMethodSelector ID="uxShipMethod" runat="server" Title="5. Choose a shipping method that the promo applies to" />
		
		<% if (uxPromoType.PromoTypeID != 6)  %>	
		<%{%>	
		<uc8:ShipPromoText ID="uxPdpShipPromoText" runat="server" Title="6. Set the merchandising text for the product detail page" />
		<!--<uc6:MultilineText ID="uxPdpMerchandisingText" runat="server" Title="6. Set the merchandising text for the product detail page" />-->
		<uc6:MultilineText ID="uxCheckoutMerchandisingText" runat="server" Title="7. Set the merchandising text for the checkout page" />
		<uc6:MultilineText ID="uxSearchMerchandisingText" runat="server"  Title="8. Set the merchandising text for the search results page" />
		
		<%}%>	
		
		<% if (uxPromoType.PromoTypeID > 3){
            this.chkIsMerchVisible.Visible = false;
            this.lblIsMerchVisible.Visible = false;
            
       }%>	 		
        
        <asp:Label ID="lblIsMerchVisible" runat="server" Visible="true">
            <h3 class="headerSteps" >9. Set PDP Text Visibility</h3></asp:Label>
        <asp:CheckBox ID="chkIsMerchVisible" runat="server" Visible="true" text="Override PDP text display rule" /> 
              
		
		</div>
		<div id="uxPromoSetupMessage2" runat="server" visible="false" class="error">
	    	<asp:Literal ID="uxPromoSetupMessageContent2" runat="server"></asp:Literal>
	    </div>
	    <br />
		<fieldset>
			<asp:Button ID="uxSubmit" runat="server" Text="Submit"  onclick="uxSubmit_Click" />
		</fieldset>

</asp:Content>