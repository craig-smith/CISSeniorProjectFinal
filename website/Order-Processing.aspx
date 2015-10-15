<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Order-Processing.aspx.cs" Inherits="Order_Processing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Scripts/collapse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>Order Processing</h1>
    
    <asp:Panel ID="orderLinksPanel" runat="server" Visible="false">
        
        <asp:Repeater ID="OrderValidationLinksRepeater" runat="server">
            <HeaderTemplate>
                <h2>Orders Requiring Validation</h2>
            </HeaderTemplate>
            <ItemTemplate>
                <a href="Order-Processing.aspx?OrderId=<%#Eval("orderId") %>"><%#Eval("orderId") %></a><br />
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="OrderCompletionLinksRepeater" runat="server">
            <HeaderTemplate>
                <h2>Orders Requiring Completion</h2>
            </HeaderTemplate>
            <ItemTemplate>
                <a href="Order-Processing.aspx?OrderId=<%#Eval("orderId") %>"><%#Eval("orderId") %></a><br />
            </ItemTemplate>
        </asp:Repeater>
        
        
    </asp:Panel>

    <asp:Panel ID="singleOrderPanel" runat="server" Visible="false">
        <div id="order-processing">
            <div class="user-info collapse">
                <h2>User Info</h2>
                <div>UserId: <asp:Label ID="lblUserId" runat="server"></asp:Label></div>
                <div>Username: <asp:Label ID="lblUsername" runat="server"></asp:Label></div>
                <div>First Name: <asp:Label ID="lblFirstName" runat="server"></asp:Label></div>
                <div>Last Name: <asp:Label ID="lblLastName" runat="server"></asp:Label></div>
                <div>Address: <asp:Label ID="lblAddress" runat="server"></asp:Label></div>
                <div>City: <asp:Label ID="lblCity" runat="server"></asp:Label></div>
                <div>State: <asp:Label ID="lblState" runat="server"></asp:Label></div>
                <div>Zip Code: <asp:Label ID="lblZipCode" runat="server"></asp:Label></div>
                <div>Account Creation Date: <asp:Label ID="lblAccountCreationDate" runat="server"></asp:Label></div>
                <div>Email: <asp:Label ID="lblEmail" runat="server"></asp:Label></div>
            </div>
            <div class="payment-information collapse">
                <h2>Payment Info</h2>
                <div>Credit Card Type: <asp:Label ID="lblCreditCardType" runat="server"></asp:Label></div>
                <div>Credit Card Number: <asp:Label ID="lblCreditCardNumber" runat="server"></asp:Label></div>
                <div>City: <asp:Label ID="lblCardCity" runat="server"></asp:Label></div>
                <div>State: <asp:Label ID="lblCardState" runat="server"></asp:Label></div>
                <div>Experation Date: <asp:Label ID="lblCardExpDate" runat="server"></asp:Label></div>
                <div>Security Code: <asp:Label ID="lblCardSecurityCode" runat="server"></asp:Label></div>
            </div> 
            <div class="order-info collapse">
                <h2>Order Info</h2>
                <div>Order Number: <asp:Label ID="lblOrderId" runat="server"></asp:Label></div>
                <div>Created by User ID: <asp:Label ID="lblOrderUserId" runat="server"></asp:Label></div>
                <div>Is Validated: <asp:CheckBox ID="cbIsValidated" runat="server" Enabled="false"/></div>
                <div>Is Completed: <asp:CheckBox ID="cbIsCompleted" runat="server" Enabled="false"/></div>
                <div>Is Collect On Delivery: <asp:CheckBox ID="cbIsCollectOnDelivery" runat="server" Enabled="false"/></div>
                <div>Total Order Amount: <asp:Label ID="lblTotalOrderAmount" runat="server"></asp:Label></div>
                <div>Payment Amount: <asp:Label ID="lblPaymentAmount" runat="server"></asp:Label></div>
                <div>Amount Due: <asp:Label ID="lblAmountDue" runat="server"></asp:Label></div>
            </div>
            <div>
                <asp:Repeater ID="rptOrderItems" runat="server">
                    <HeaderTemplate>
                        <div class="order-item-repeater collapse">
                        <h2>Order Items</h2>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="order-items">
                            Item name: <%#Eval("itemName") %><br />
                            Item Sale Price: <%#Eval("itemCost") %><br />
                            Item Count: <%#Eval("itemCount") %>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="data-entry">
                <asp:Button ID="btnValidateOrder" Text="Validate Order" runat="server" OnClick="btnValidateOrder_Click" />
                <asp:Button ID="btnCompleteOrder" Text="Complete Order" runat="server" OnClick="btnCompleteOrder_Click" />
            </div>
        </div>
    </asp:Panel>
    
</asp:Content>

