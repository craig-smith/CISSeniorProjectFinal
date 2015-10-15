<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Approve-Purchase-Order.aspx.cs" Inherits="Approve_Purchase_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>Approve/Send Purchase orders</h1>
    Purchase Order: <asp:DropDownList ID="ddlPurchaseOrder" runat="server"></asp:DropDownList> <asp:Button ID="btnSelect" Text="Select" runat="server" OnClick="btnSelect_Click" /><br />
    
    <asp:Button ID="btnSend" Text="Send Purchase Order" runat="server" OnClick="btnSend_Click" /><br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <div id="repeater-purchase-order">
        <asp:XmlDataSource ID="XmlDataSource1" runat="server"></asp:XmlDataSource>
        Supplier Name: <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
        <asp:Repeater ID="PurchaseOrderRepeater" runat="server" DataSourceID="XmlDataSource1">
            <HeaderTemplate>
               <div style="font-weight: 600">Order Items</div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="purchase-order-item">
                    Item Name: <%#XPath("itemName") %><br />
                    Amount Ordered: <%#XPath("orderAmount") %><br />
                    Item Price: <%#XPath("itemPrice") %><br />
                </div>
            </ItemTemplate>
        </asp:Repeater>
       
    </div>
</asp:Content>

