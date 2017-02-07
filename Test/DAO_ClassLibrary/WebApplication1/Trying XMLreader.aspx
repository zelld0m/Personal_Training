<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trying XMLreader.aspx.cs" Inherits="WebApplication1.Trying_XMLreader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ShowLines="True">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="lst" Target="responseHeader" Text="responseHeader" />
                <asp:TreeNodeBinding DataMember="int" Target="status" />
                <asp:TreeNodeBinding DataMember="int" Target="QTime" />
                <asp:TreeNodeBinding DataMember="int" Text="status" Value="status" />
                <asp:TreeNodeBinding DataMember="lst" Text="params" Value="params" />
                <asp:TreeNodeBinding DataMember="type" />
                <asp:TreeNodeBinding DataMember="int" Text="EDP" Value="EDP" />
            </DataBindings>
        </asp:TreeView>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/DataFiles/Price.xml" XPath="/price/*"></asp:XmlDataSource>
        <asp:TreeView ID="TreeView2" runat="server" DataSourceID="XmlDataSource2" ImageSet="BulletedList2" OnSelectedNodeChanged="TreeView2_SelectedNodeChanged" ShowExpandCollapse="False">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/DataFiles/Brand_XML.xml" XPath="/response/*"></asp:XmlDataSource>
    </form>
</body>
</html>
