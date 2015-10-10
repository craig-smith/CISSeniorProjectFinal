<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Add-Inventory-Item.aspx.cs" Inherits="Add_Inventory_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>Add Inventory Item</h1>
    <div class="inventory-management">      
            
            Product Name: <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />
            Count in Inventory: <asp:TextBox ID="txtProductCount" runat="server"></asp:TextBox><br />
            Items Pending: <asp:TextBox ID="txtItemsOnHold" runat="server"></asp:TextBox><br />
            Unit Cost: <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox><br />
            Sale Price: <asp:TextBox ID="txtSalePrice" runat="server"></asp:TextBox><br />
            Short Description: <asp:TextBox ID="txtShortDescription" runat="server" Columns="100" TextMode="MultiLine"></asp:TextBox><br />
            Long Description: <asp:TextBox ID="txtLongDescription" runat="server" Columns="100" TextMode="MultiLine"></asp:TextBox><br />
            Image <asp:FileUpload ID="ImageFileUpload" runat="server" /><br />
            Manufacturer: <asp:DropDownList ID="ddlManufacturer" runat="server"></asp:DropDownList><br />
            Minimum Inventory Count: <asp:TextBox ID="txtMinumInventory" runat="server"></asp:TextBox> <br />
            <div class="error-msg">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Product Name is required" ControlToValidate="txtProductName" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Items Pending is required" ControlToValidate="txtItemsOnHold" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Inventory Count is required" ControlToValidate="txtProductCount" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Unit Price is required" ControlToValidate="txtUnitPrice" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Sale Price is required" ControlToValidate="txtSalePrice" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Short Description is required" ControlToValidate="txtShortDescription" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Long Description is required" ControlToValidate="txtLongDescription" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Minimum Inventory is required" ControlToValidate="txtMinumInventory" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Items Pending must be a whole number" ControlToValidate="txtItemsOnHold" Operator="DataTypeCheck" Display="Dynamic" Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtProductCount" Display="Dynamic" ErrorMessage="Product Count must be a whole number" Operator="DataTypeCheck" Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Unit Price must be a number" ControlToValidate="txtUnitPrice" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ValidationGroup="submit"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Sale Price must be a number" ControlToValidate="txtSalePrice" Operator="DataTypeCheck" Type="Double" ValidationGroup="submit"></asp:CompareValidator>
                
            </div>
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="submit"/>
    </div>
    <div class="add-supplier">
        <h2>Add new supplier</h2>
        Name: <asp:TextBox ID="txtSupplierName" runat="server" ></asp:TextBox><br />
        Address: <asp:TextBox ID="txtSupplierAddress" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAddSupplier" Text="Add Supplier" runat="server" OnClick="btnAddSupplier_Click" ValidationGroup="supplier" />
        <div class="error-msg">
            <asp:Label ID="lblSupplierMsg" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Supplier Name is required" ControlToValidate="txtSupplierName" ValidationGroup="supplier"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Supplier Address is required" ControlToValidate="txtSupplierAddress" ValidationGroup="supplier"></asp:RequiredFieldValidator>
        </div>
        
    </div>
</asp:Content>

