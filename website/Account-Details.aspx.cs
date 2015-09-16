using cisseniorproject.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.dataobjects;

public partial class Account_Detials : System.Web.UI.Page
{
    private UsersManager businessLayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        businessLayer = new UsersManager();
        if (!Page.IsPostBack)
        {
            
            getUserData();
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
}