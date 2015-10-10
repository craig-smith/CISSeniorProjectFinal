<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Inventory-Control.aspx.cs" Inherits="Inventory_Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>Inventory Control</h1>
    <p>Use this page to edit existing inventory.</p>
    <p>Keep in mind, editing amount on hold could impact application perfomance.</p>
    <asp:Panel ID="InventoryLinksPanel" runat="server" Visible="false">
        <asp:Repeater ID="InventoryLinksRepeater" runat="server" >
            <HeaderTemplate>
                <h2>Choose an item to edit</h2>
                <div class="inventory-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="nav-item"><a href="Inventory-Control.aspx?itemId=<%#Eval("inventoryId")%>"><%#Eval("productName")%></a></div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        
    </asp:Panel>
    <asp:Panel ID="EditInventoryPanel" runat="server" Visible="false">
        <h2>Edit Existing or Add New Item</h2>
        <div class="edit-inventory-item">
            <asp:HiddenField ID="hidInventoryId" runat="server" />
            <asp:HiddenField ID="hidImagePath" runat="server" />
            Product Name: <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />
            Count in Inventory: <asp:TextBox ID="txtProductCount" runat="server"></asp:TextBox><br />
            Items Pending: <asp:TextBox ID="txtItemsOnHold" runat="server"></asp:TextBox><br />
            Unit Cost: <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox><br />
            Sale Price: <asp:TextBox ID="txtSalePrice" runat="server"></asp:TextBox><br />
            Short Description: <asp:TextBox ID="txtShortDescription" runat="server" Columns="100" TextMode="MultiLine"></asp:TextBox><br />
            Long Description: <asp:TextBox ID="txtLongDescription" runat="server" Columns="100" TextMode="MultiLine"></asp:TextBox><br />
            Image <span style="color: red;">(leave blank if you don't want to change)</span>: <asp:FileUpload ID="ImageFileUpload" runat="server" /><br />
            <div class="error-msg">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Product Name is required" ControlToValidate="txtProductName" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Items Pending is required" ControlToValidate="txtItemsOnHold" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Inventory Count is required" ControlToValidate="txtProductCount" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Unit Price is required" ControlToValidate="txtUnitPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Sale Price is required" ControlToValidate="txtSalePrice" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Short Description is required" ControlToValidate="txtShortDescription" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Long Description is required" ControlToValidate="txtLongDescription" Display="Dynamic"></asp:RequiredFieldValidator>
                
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Items Pending must be a whole number" ControlToValidate="txtItemsOnHold" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtProductCount" Display="Dynamic" ErrorMessage="Product Count must be a whole number" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Unit Price must be a number" ControlToValidate="txtUnitPrice" Operator="DataTypeCheck" Type="Double" Display="Dynamic"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Sale Price must be a number" ControlToValidate="txtSalePrice" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
            </div>
            <asp:Button ID="btnSubmit" Text="Update Item" runat="server" OnClick="btnSubmit_Click" />
        </div>
    </asp:Panel>
</asp:Content>

