<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="User-Management.aspx.cs" Inherits="User_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>User Management</h1>
    Search For User (username): <asp:TextBox ID="txtSearchUser" runat="server"></asp:TextBox> <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    <div class="user-management">
        <div class="data-entry">
            <asp:Label ID="lblUsername" Text="Username: " runat="server"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblFirstName" Text="First Name: " runat="server"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblLastName" Text="Last Name: " runat="server"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblAddress" Text="Address: " runat="server"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblCity" Text="City: " runat="server"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblState" Text="State: " runat="server"></asp:Label>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblZipCode" Text="Zip Code: " runat="server"></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblAccountCreationDate" Text="Account Creation Date" runat="server"></asp:Label>
            <asp:TextBox ID="txtAccountCreationDate" runat="server"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblAccessLevel"  Text="Access Level: " runat="server"></asp:Label>
            <asp:DropDownList ID="ddlAccessLevel" runat="server"></asp:DropDownList>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblEmail" Text="Email: " runat="server"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>

    </div>
</asp:Content>

