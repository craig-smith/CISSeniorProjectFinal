<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Create-Purchase-Order.aspx.cs" Inherits="Create_Purchase_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:Repeater ID="OrderItems" runat="server">
        <HeaderTemplate>
            <div class="order-item-repeater">
            <h1>Items to order</h1>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="order-item">
                Item Name: <asp:Label ID="lblItemName" Text='<%#Eval("itemName")%>' runat="server"></asp:Label><br />
                Count On Hand: <asp:Label ID="lblCountOnHand" Text='<%#Eval("inventoryCount").ToString()%>' runat="server"></asp:Label><br />
                Suggested Minimum Count: <asp:Label ID="lblMinCount" Text='<%#Eval("minCount").ToString()%>' runat="server"></asp:Label><br />
                Supplier: <asp:Label ID="lblSupplier" Text='<%#Eval("supplier")%>' runat="server"></asp:Label><br />
                Item Cost: <asp:Label ID="lblItemCost" Text='<%#Eval("itemCost", "{0:c}")%>' runat="server"></asp:Label><br />
                Amount To Order: <asp:TextBox ID="txtAmountToOrder" runat="server" ClientIDMode="Predictable"></asp:TextBox> 
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

