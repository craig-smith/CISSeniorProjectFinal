<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs" Inherits="LoginControl" %>
<%@ Reference VirtualPath="~/LinksControl.ascx" %>

<asp:Panel ID="loginPanel" runat="server" Visible="false">
    <div id="username">
        <asp:Label ID="lblUsername" Text="Username" runat="server"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>
    <div id="password" class="clear">
        <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div id="login-buttons" class="clear">
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
        <asp:Button ID="btnCreateAccount" Text="Create Account" runat="server" OnClick="btnCreateAccount_Click" />
    </div>
    <div class="clear">
        <asp:Label ID="lblLoginMessage" runat="server"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is Required!" Display="Static" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Username is Required!" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
    </div>
</asp:Panel>
<asp:Panel ID="userPanel" runat="server" Visible="false">
    <asp:Label ID="lblMsg" Text="User is logged in!" runat="server"></asp:Label>
</asp:Panel>
