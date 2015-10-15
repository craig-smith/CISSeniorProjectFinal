<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="Account-Details.aspx.cs" Inherits="Account_Detials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Williams - Account Details</title>
    <script src="Scripts/collapse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:TextBox ID="collapseLastViewed" runat="server" CssClass="hide-grid-column" ClientIDMode="Static"></asp:TextBox>
    <h1>Account Details</h1>
    <p>Click on a section to edit your details.</p>
    <div id="account-details" class="collapse">
        <h2>Contact Details</h2>
        <div class="data-entry">
            <asp:Label ID="lblUserName" Text="Username: " runat="server"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Visible="true" Enabled="false"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblFirstName" Text="First Name: " runat="server"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblLastName" Text="Last Name: " runat="server"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblEmail" Text="Email: " runat="server"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblAddress" Text="Address: " runat="server"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblCity" Text="City: " runat="server"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblState" Text="State: " runat="server"></asp:Label>
            <asp:TextBox ID="txtState" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblZipCode" Text="Zip Code: " runat="server" ></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server" ValidationGroup="1"></asp:TextBox>
        </div>
        <asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" ValidationGroup="1" />
        <div>
                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblMessage" runat ="server"></asp:Label>
         </div>
    
        <div class="error-msg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is required!" ControlToValidate="txtFirstName" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is required!" ControlToValidate="txtLastName" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is required!" ControlToValidate="txtEmail" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Address is required!" ControlToValidate="txtAddress" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="City is required!" ControlToValidate="txtCity" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="State is required!" ControlToValidate="txtState" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Zip code is required!" ControlToValidate="txtZipCode" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div id="change-password" class="collapse">
        <h2>Change Password</h2>
        <div class="data-entry">
            <asp:Label ID="lblOldPassword" Text="Old Password: " runat="server"></asp:Label>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" ValidationGroup="2"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblNewPassword" Text="New Password" runat="server"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" ValidationGroup="2"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblConfirmPassword" Text="Confirm Password: " runat="server"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" ValidationGroup="2"></asp:TextBox>
        </div>
        <asp:Button ID="btnChangePassword" Text="Change Password" runat="server"  ValidationGroup="2" OnClick="btnChangePassword_Click"/>
        <div>
            <asp:Label ID="lblPassChangeMsg" runat="server"></asp:Label>
        </div>
        <div class="error-msg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Old Password Required!" ControlToValidate="txtOldPassword" ValidationGroup="2" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="New Password must have 1 number, 1 upper case letter, 1 special character, and be at least 8 characters long." ControlToValidate="txtNewPassword" ValidationGroup="2" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="New Password Required!" ControlToValidate="txtNewPassword" ValidationGroup="2" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Confirm Password Required!" ControlToValidate="txtConfirmPassword" ValidationGroup="2" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New Password and Confirm Password must be the same!" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ValidationGroup="2" Display="Dynamic"></asp:CompareValidator>
        </div>
    </div>
    
    <div id="payment-details" class="collapse">
        <h2>Payment Details</h2>
        <h3>Enter new Payment Method</h3>
        <div class="data-entry">
            <asp:Label ID="creditCardType" Text="Credit Card Type: " runat="server"></asp:Label>
            <asp:TextBox ID="txtCreditCardType" runat="server" ValidationGroup="3"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblCreditCardNumber" Text="Credit Card Number:" runat="server"></asp:Label>
            <asp:TextBox ID="txtCreditCardNumber" runat="server" ValidationGroup="3"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblcreditCardCity" Text="Credit Card City: " runat="server"></asp:Label>
            <asp:TextBox ID="txtCreditCardCity" runat="server"></asp:TextBox> 
        </div>
        <div class="data-entry">
            <asp:Label ID="lblCreditCardState" Text="Credit Card State: " runat="server"></asp:Label>
            <asp:TextBox ID="txtCreditCardState" runat="server" ValidationGroup="3"></asp:TextBox>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblCreditCardExpDate" Text="Experation Date: " runat="server"></asp:Label>
            <asp:DropDownList ID="ddlCreditCardExpDate" runat="server" ValidationGroup="3"></asp:DropDownList>
        </div>
        <div class="data-entry">
            <asp:Label ID="lblSecurityCode" Text="Security Code: " runat="server"></asp:Label>
            <asp:TextBox ID="txtSecurityCode" runat="server" ValidationGroup="3"></asp:TextBox>
        </div>
        <asp:Button ID="btnNewCreditCard" Text="Submit" runat="server" OnClick="btnNewCreditCard_Click" ValidationGroup="3" />
        <div>
            <asp:Label ID="lblCreditMsg" runat="server"></asp:Label>
        </div>
        <div class="error-msg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Credit Card Type is Required." ControlToValidate="txtCreditCardType" ValidationGroup="3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Credit Card Number is Required." ControlToValidate="txtCreditCardNumber" ValidationGroup="3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Card City is Required." ControlToValidate="txtCreditCardCity" ValidationGroup="3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Card State is Required" ControlToValidate="txtCreditCardState" ValidationGroup="3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Securiy Code is Required" ControlToValidate="txtSecurityCode" ValidationGroup="3"></asp:RequiredFieldValidator>
        </div>
        <h3>Edit Existing Payment Methods</h3>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="payment_information_id">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="payment_information_id" HeaderText="payment_information_id" InsertVisible="False" ReadOnly="True" SortExpression="payment_information_id" >
                <ControlStyle CssClass="hide-grid-column" />
                <HeaderStyle CssClass="hide-grid-column" />
                <ItemStyle CssClass="hide-grid-column" />
                </asp:BoundField>
                <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" >
                <ControlStyle CssClass="hide-grid-column" />
                <HeaderStyle CssClass="hide-grid-column" />
                <ItemStyle CssClass="hide-grid-column" />
                </asp:BoundField>
                <asp:BoundField DataField="credit_card_type" HeaderText="credit_card_type" SortExpression="credit_card_type" />
                <asp:BoundField DataField="credit_card_number" HeaderText="credit_card_number" SortExpression="credit_card_number" />
                <asp:BoundField DataField="card_city" HeaderText="card_city" SortExpression="card_city" />
                <asp:BoundField DataField="card_state" HeaderText="card_state" SortExpression="card_state" />
                <asp:BoundField DataField="card_exp_date" HeaderText="card_exp_date" SortExpression="card_exp_date" />
                <asp:BoundField DataField="security_code" HeaderText="security_code" SortExpression="security_code" />
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:CISSeniorProjectDB %>" DeleteCommand="DELETE FROM [PAYMENT_INFORMATION] WHERE [payment_information_id] = ? AND (([user_id] = ?) OR ([user_id] IS NULL AND ? IS NULL)) AND (([credit_card_type] = ?) OR ([credit_card_type] IS NULL AND ? IS NULL)) AND (([credit_card_number] = ?) OR ([credit_card_number] IS NULL AND ? IS NULL)) AND (([card_city] = ?) OR ([card_city] IS NULL AND ? IS NULL)) AND (([card_state] = ?) OR ([card_state] IS NULL AND ? IS NULL)) AND (([card_exp_date] = ?) OR ([card_exp_date] IS NULL AND ? IS NULL)) AND (([security_code] = ?) OR ([security_code] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [PAYMENT_INFORMATION] ([payment_information_id], [user_id], [credit_card_type], [credit_card_number], [card_city], [card_state], [card_exp_date], [security_code]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:CISSeniorProjectDB.ProviderName %>" SelectCommand="SELECT * FROM [PAYMENT_INFORMATION] WHERE ([user_id] = ?)" UpdateCommand="UPDATE [PAYMENT_INFORMATION] SET [user_id] = ?, [credit_card_type] = ?, [credit_card_number] = ?, [card_city] = ?, [card_state] = ?, [card_exp_date] = ?, [security_code] = ? WHERE [payment_information_id] = ? AND (([user_id] = ?) OR ([user_id] IS NULL AND ? IS NULL)) AND (([credit_card_type] = ?) OR ([credit_card_type] IS NULL AND ? IS NULL)) AND (([credit_card_number] = ?) OR ([credit_card_number] IS NULL AND ? IS NULL)) AND (([card_city] = ?) OR ([card_city] IS NULL AND ? IS NULL)) AND (([card_state] = ?) OR ([card_state] IS NULL AND ? IS NULL)) AND (([card_exp_date] = ?) OR ([card_exp_date] IS NULL AND ? IS NULL)) AND (([security_code] = ?) OR ([security_code] IS NULL AND ? IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_payment_information_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_credit_card_type" Type="String" />
                <asp:Parameter Name="original_credit_card_type" Type="String" />
                <asp:Parameter Name="original_credit_card_number" Type="String" />
                <asp:Parameter Name="original_credit_card_number" Type="String" />
                <asp:Parameter Name="original_card_city" Type="String" />
                <asp:Parameter Name="original_card_city" Type="String" />
                <asp:Parameter Name="original_card_state" Type="String" />
                <asp:Parameter Name="original_card_state" Type="String" />
                <asp:Parameter Name="original_card_exp_date" Type="DateTime" />
                <asp:Parameter Name="original_card_exp_date" Type="DateTime" />
                <asp:Parameter Name="original_security_code" Type="String" />
                <asp:Parameter Name="original_security_code" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="payment_information_id" Type="Int32" />
                <asp:Parameter Name="user_id" Type="Int32" />
                <asp:Parameter Name="credit_card_type" Type="String" />
                <asp:Parameter Name="credit_card_number" Type="String" />
                <asp:Parameter Name="card_city" Type="String" />
                <asp:Parameter Name="card_state" Type="String" />
                <asp:Parameter Name="card_exp_date" Type="DateTime" />
                <asp:Parameter Name="security_code" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter  ControlID="lblUserId" Name="user_id" Type="Int32" PropertyName="Text" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="user_id" Type="Int32" />
                <asp:Parameter Name="credit_card_type" Type="String" />
                <asp:Parameter Name="credit_card_number" Type="String" />
                <asp:Parameter Name="card_city" Type="String" />
                <asp:Parameter Name="card_state" Type="String" />
                <asp:Parameter Name="card_exp_date" Type="DateTime" />
                <asp:Parameter Name="security_code" Type="String" />
                <asp:Parameter Name="original_payment_information_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_credit_card_type" Type="String" />
                <asp:Parameter Name="original_credit_card_type" Type="String" />
                <asp:Parameter Name="original_credit_card_number" Type="String" />
                <asp:Parameter Name="original_credit_card_number" Type="String" />
                <asp:Parameter Name="original_card_city" Type="String" />
                <asp:Parameter Name="original_card_city" Type="String" />
                <asp:Parameter Name="original_card_state" Type="String" />
                <asp:Parameter Name="original_card_state" Type="String" />
                <asp:Parameter Name="original_card_exp_date" Type="DateTime" />
                <asp:Parameter Name="original_card_exp_date" Type="DateTime" />
                <asp:Parameter Name="original_security_code" Type="String" />
                <asp:Parameter Name="original_security_code" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

