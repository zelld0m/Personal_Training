<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap/css/Custom-Cs.css" rel="stylesheet" />
    <style type="text/css">
        table tr{
            text-align:right;
        }
        table tr td{
            text-align:left;
        }
    </style>
    <div>
        <center>
           <fieldset style="width:480px">
            <legend>XML Database Demo</legend>
           <table border="1" width ="100%">
               <tr>
            
                   <th>ROll No:</th>
                   <td>
                       <asp:TextBox runat="server" ID="txtID" />
                   </td>
               </tr>
               <tr>
                   <th>First Name :</th>
                   <td>
                       <asp:TextBox runat="server" ID="txtFirstName" />

                   </td>
               </tr>
               <tr>
                   <th>Last Name :</th>
                   <td>
                      <asp:TextBox runat="server" ID="txtLastName" />
                   </td>
               </tr>
               <tr>
                   <th>City:</th>
                   <td>
                       <asp:DropDownList runat="server" ID="ddlCity" >
                           <asp:ListItem Text ="Surat" />
                           <asp:ListItem Text="Baroda" />
                           <asp:ListItem Text ="Ahembeded" />
                       </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <th>Gender: </th>
                   <td>
                       <asp:RadioButtonList runat ="server" ID ="rbGender" RepeatDirection="Horizontal">
                           <asp:ListItem Text ="Male"/>
                           <asp:ListItem Text ="Female" />
                           
                         


                       </asp:RadioButtonList>
                       
                   </td>
               </tr>
               <tr>
                   <th>Pincode :</th>
                   <td>
                       <asp:TextBox runat="server" ID="txtPincode" />
                   </td>
               </tr>
               <tr>
                   <th>Mobile No:</th>
                   <td>
                       <asp:TextBox runat="server" ID="txtMobileNo" />
                   </td>
               </tr>
               <tr>
                   <th colspan="2">
                       <center>
                   
                               <asp:Button Text ="Insert" runat="server" ID="btn_Insert" OnClick="btn_Insert_Click" />
                   </center>
                           </th>
               </tr>

           </table>
               <br />
               <asp:GridView runat="server" ID="GridView1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
                   <Columns>
                       <asp:TemplateField HeaderText="RollNo"></asp:TemplateField>
                       <asp:TemplateField HeaderText="FirstName"></asp:TemplateField>
                       <asp:TemplateField HeaderText="LastName"></asp:TemplateField>
                       <asp:TemplateField HeaderText="City"></asp:TemplateField>
                       <asp:TemplateField HeaderText="Gender"></asp:TemplateField>
                       <asp:TemplateField HeaderText="Pincode"></asp:TemplateField>
                       <asp:TemplateField HeaderText="MobileNo"></asp:TemplateField>
                   </Columns>
                   <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                   <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                   <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                   <RowStyle BackColor="White" ForeColor="#003399" />
                   <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                   <SortedAscendingCellStyle BackColor="#EDF6F6" />
                   <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                   <SortedDescendingCellStyle BackColor="#D6DFDF" />
                   <SortedDescendingHeaderStyle BackColor="#002876" />
               </asp:GridView>
           </fieldset>
          
           
          </center>
   </div>

 

</asp:Content>
