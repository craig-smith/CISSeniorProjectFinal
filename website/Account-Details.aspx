<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Account-Details.aspx.cs" Inherits="Account_Detials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Williams - Account Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <h1>Account Details</h1>
    <p>Please fill in all fields to set up your account.</p>
    <div class="data-entry">
        <asp:Label ID="lblUserName" Text="Username: " runat="server"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" Visible="true" Enabled="false"></asp:TextBox>
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
        <asp:Label ID="lblEmail" Text="Email: " runat="server"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
    <asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" />
    <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblMessage" runat ="server"></asp:Label>
    <div class="error-msg">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is required!" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is required!" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is required!" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Address is required!" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="City is required!" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="State is required!" ControlToValidate="txtState"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Zip code is required!" ControlToValidate="txtZipCode"></asp:RequiredFieldValidator>
    </div>
    <div id="change-password">
        
    </div>
</asp:Content>

