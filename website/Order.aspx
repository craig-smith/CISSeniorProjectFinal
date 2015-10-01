<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">   
   <asp:Repeater ID="rptOrderItem" runat="server">
       <HeaderTemplate>
           <div class="order-item-repeater">
       </HeaderTemplate>
       <ItemTemplate>
           <div class="order-item">
           <div class="order-item-product-name"><h3>Item Name: <%#Eval("productName")%></h3></div>
           <div class="order-item-on-hand"><p>Items On Hand: <%#Eval("productCount")%></p></div>
               <div class="order-item-description"><p><%#Eval("shortDescription")%></p></div>
               <div class="order-price"><p>Unit Price: <span><%#Eval("salePrice", "{0:c}")%></span></p></div>
           <div class="order-item-ordered">Amount Ordered: <asp:TextBox ID="txtCount" runat="server" ClientIDMode="Predictable" EnableViewState="true" ValidationGroup="submit"></asp:TextBox></div>
               <div class="error-msg">
                   <asp:RequiredFieldValidator ID="itemCountRequiredValidator" runat="server" ErrorMessage="Item Count is required." ValidationGroup="submit" ControlToValidate="txtCount"></asp:RequiredFieldValidator>
                   <asp:CompareValidator ID="itemCountCompareValidator" runat="server" ErrorMessage="You must enter a whole number." Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ControlToValidate="txtCount" ValidationGroup="submit"></asp:CompareValidator>
               </div>
           </div>
       </ItemTemplate>
       <FooterTemplate>
           </div>
       </FooterTemplate>
   </asp:Repeater>
    <h3>Select your payment method</h3>
    <p>Collet on delivery orders require a 10% down payment.</p>
    <div id="paymentMethod">
        <div>Card Number: <asp:DropDownList ID="ddlPaymentMethod" AppendDataBoundItems="true" runat="server" ClientIDMode="Static"></asp:DropDownList></div>
        <div>
            <asp:CheckBox ID="cbCollectOnDelivery" Text="Collect On Delivery" runat="server" onclick="" /><br />
            Payment Amount: <asp:TextBox ID="txtPaymentAmount" runat="server" Enabled="false"></asp:TextBox>
        </div>
            <div>
                <h2><asp:Label ID="lblMessage" runat="server"></asp:Label></h2>
                <div class="error-msg">
                <asp:RangeValidator ID="paymentAmountValidator" runat="server" ErrorMessage="Payment amount must be at least 10 percent of order cost!" ControlToValidate="txtPaymentAmount" Type="Double" ValidationGroup="submit" Display="Dynamic"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="paymentAmountRequiredValidator" runat="server" ErrorMessage="Payment amount is required!" ControlToValidate="txtPaymentAmount" ValidationGroup="submit" Display="Dynamic"></asp:RequiredFieldValidator>
       
            </div>
        </div>
        <div>
            <asp:Button ID="btnCalculateOrder" Text="Calculate Order" runat="server" OnClick="btnCalculateOrder_Click" />
            <asp:Button ID="btnSubmit" Text="Submit Order" runat="server" OnClick="btnSubmit_Click" ValidationGroup="submit"/>
        </div>
       
    </div>
    
</asp:Content>

