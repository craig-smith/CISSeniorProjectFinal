<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="My-Orders.aspx.cs" Inherits="My_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>My Orders</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>View Existing Orders</h1>

    <asp:Repeater ID="ExistingOrdersHeaderRepeater" runat="server">
        <HeaderTemplate>
            
                      
        </HeaderTemplate>
        <ItemTemplate>
            <div class="my-order">
                <h3>Order Total: <%#String.Format("{0:C}",Eval("orderTotal")) %></h3>
                <h4>Order Payment Amount: <%#String.Format("{0:C}", Eval("paymentAmount")) %></h4>
                <p>Credit Card: <%#Eval("creditCardNumber") %></p>
                <p>Order ID: <%#Eval("orderId") %></p>
            <asp:Repeater ID="ExistingOrderItemRepeater" runat="server">
                <HeaderTemplate>
                    
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="my-order-item">
                        <h3>Item Name: <%#Eval("itemName") %></h3>
                        <p>Item Price: <%#String.Format("{0:C}",Eval("itemCost")) %></p>
                        <p>Count Ordered: <%#Eval("itemCount") %></p>
                        <p>Description: <%#Eval("itemShortDescription") %></p>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                   
                </FooterTemplate>
            </asp:Repeater>
                </div>
            <div class="clear"></div>
        </ItemTemplate>
        <FooterTemplate>
           
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

