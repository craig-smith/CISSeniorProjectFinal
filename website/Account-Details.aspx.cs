using cisseniorproject.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.dataobjects;
using cisseniorproject.utils;
using cisseniorproject.payment;

public partial class Account_Detials : System.Web.UI.Page
{
    private UsersManager businessLayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        businessLayer = new UsersManager();
        if (!Page.IsPostBack)
        {
            
            getUserData();
            List<DateTime> dates = DatePicker.getDatesAfterToday(1825);
            foreach (DateTime date in dates)
            {
                ddlCreditCardExpDate.Items.Add(date.ToShortDateString());               
            }
        }
    }

    private void getUserData()
    {
        String username = Security.getUsername();
        User user = businessLayer.getUserData(username);

        populatePage(user);
    }

    private void populatePage(User user)
    {
        lblUserId.Text = user.getId().ToString();
        txtUsername.Text = user.getUsername();
        txtFirstName.Text = user.getFirstName();
        txtLastName.Text = user.getLastName();
        txtEmail.Text = user.getEamil();
        txtAddress.Text = user.getAddress();
        txtCity.Text = user.getCity();
        txtState.Text = user.getState();
        txtZipCode.Text = user.getZipCode();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int userId = Convert.ToInt32(lblUserId.Text);            
            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String email = txtEmail.Text;
            String address = txtAddress.Text;
            String city = txtCity.Text;
            String state = txtState.Text;
            String zipCode = txtZipCode.Text;

            String username = Security.getUsername();

            User user = new User();
            user.setId(userId);
            user.setUsername(username);
            user.setFirstName(firstName);
            user.setLastName(lastName);
            user.setEmail(email);
            user.setAddress(address);
            user.setCity(city);
            user.setState(state);
            user.setZipCode(zipCode);
            
            Boolean success = businessLayer.updateUserDetails(user);

            if (success)
            {
                lblMessage.Text = "Details updated successfully.";
            }
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String oldPassword = txtOldPassword.Text;
            String newPassword = txtNewPassword.Text;
           Boolean succes = Security.changePassword(oldPassword, newPassword);

           if (succes)
           {
               lblPassChangeMsg.Text = "Password change Success!";
           }
           else
           {
               lblPassChangeMsg.Text = "Sorry there was an error. You may have entered you old password incorrectly.";
           }
        }
        
    }
    protected void btnNewCreditCard_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String creditCardType = txtCreditCardType.Text;
            String creditCardNumber = txtCreditCardNumber.Text;
            String creditCardCity = txtCreditCardCity.Text;
            String creditCardState = txtCreditCardState.Text;
            DateTime creditCardExpDate = DateTime.Parse(ddlCreditCardExpDate.SelectedItem.Text);
            String securitCode = txtSecurityCode.Text;

            Boolean success =  PaymentManager.addCreditCard(txtUsername.Text, creditCardType, creditCardNumber, creditCardCity, 
                creditCardState, creditCardExpDate, securitCode);

            if (success)
            {
                lblCreditMsg.Text = "Your Credit Card Information was Successfully Added.";
            }
            else
            {
                lblCreditMsg.Text = "Sorry, there was a error. Please try again.";    
            }
        }
    }
}