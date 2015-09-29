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
           <div class="order-item-ordered">Amount Ordered: <asp:TextBox ID="txtCount" runat="server" ClientIDMode="Predictable" EnableViewState="true" ></asp:TextBox></div>
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
            <asp:CheckBox ID="cbCollectOnDelivery" Text="Collect On Delivery" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnCalculateOrder" Text="Calculate Order" runat="server" OnClick="btnCalculateOrder_Click" />
            <asp:Button ID="btnSubmit" Text="Submit Order" runat="server" OnClick="btnSubmit_Click" />
        </div>
       
    </div>
    
</asp:Content>

