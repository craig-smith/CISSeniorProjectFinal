<%@ Page Title="" Language="VB" MasterPageFile="~/CISSeniorProjectFinal/website/CISSeniorProjectMasterPage.master" AutoEventWireup="false" CodeFile="AccountDetails.aspx.vb" Inherits="CISSeniorProjectFinal_website_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <%-- label should display username --%>
    <asp:Label ID="lblUsername" Text="Username:" runat="server"></asp:Label>
        <asp:Label ID="txtUsername" Text="Your username here" runat="server"></asp:Label><br />
    
    <%-- Prompt to change password --%>
    <asp:Label ID="lblOldPassword" Text="Old Password:" runat="server"></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server" Text="Please enter old password"></asp:TextBox><br /><br />
    <asp:Label ID="lblnewPassword1" Text="New Password:" runat="server"></asp:Label>
        <asp:TextBox ID="txtNewPassword1" runat="server" Text="Please enter new password"></asp:TextBox><br />
     <asp:Label ID="lblnewPassword2" Text="New Password:" runat="server"></asp:Label>
        <asp:TextBox ID="txtNewPassword2" runat="server" Text="Please re-enter new password"></asp:TextBox><br />
    <%-- Button will update password --%>
     <asp:Button ID="btnPasswordChange" Text="Submit" runat="server" OnClick="btnPasswordChange_Click" /><br /><br />
    
    <%-- Other personal information to be edited --%>
    <asp:Label ID="lblFirstName" Text="First Name:" runat="server"></asp:Label>
        <asp:TextBox ID="txtFirstName" Text="First name" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblLastName" Text="Last Name:" runat="server"></asp:Label>
        <asp:TextBox ID="txtLastName" Text="Last name" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblCity" Text="City:" runat="server"></asp:Label>
        <asp:TextBox ID="txtCity" Text="City" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblState" Text="State:" runat="server"></asp:Label>
        <asp:TextBox ID="txtState" Text="State" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblZipcode" Text="Zipcode:" runat="server"></asp:Label>
        <asp:TextBox ID="txtZipcode" Text="Zipcode" runat="server"></asp:TextBox><br />

     <asp:Button ID="btnUpdate" Text="Update Details" runat="server" OnClick="btnUpdate_Click" ValidationGroup="1" />
</asp:Content>

