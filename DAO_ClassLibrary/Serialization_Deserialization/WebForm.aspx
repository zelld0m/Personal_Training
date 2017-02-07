<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="Serialization_Deserialization.WebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    PRODUCT INFORMATION<br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    ID:<asp:TextBox ID="TB_ID" runat="server"></asp:TextBox>
    <br />
    NAME:<asp:TextBox ID="TB_Name" runat="server"></asp:TextBox>
    <br />
    CATEGORY NAME:
    <asp:TextBox ID="TB_CategoryName" runat="server"></asp:TextBox>
    <br />
    PRICE:<asp:TextBox ID="TB_Price" runat="server" Width="128px"></asp:TextBox>
    <br />
    VALUE:
    <asp:TextBox ID="TB_Value" runat="server"></asp:TextBox>
    <br />
    UNIT:<asp:TextBox ID="TB_Unit" runat="server"></asp:TextBox>
    <br />
    Description<asp:TextBox ID="TB_Description" runat="server"></asp:TextBox>
    <br />
    Color<asp:TextBox ID="TB_Color" runat="server"></asp:TextBox>
    <br />
    Size<asp:TextBox ID="TB_Size" runat="server"></asp:TextBox>
    <br />
    Weight<asp:TextBox ID="TB_Weight" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
