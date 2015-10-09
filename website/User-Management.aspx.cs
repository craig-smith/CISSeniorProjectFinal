using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.users;
using cisseniorproject.dataobjects;
using cisseniorproject.accesslevel;

public partial class User_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        UsersManager businesslayer = new UsersManager();
        
        User user = businesslayer.getUserData(txtSearchUser.Text);
        hidUserID.Value = user.getId().ToString();
        txtUsername.Text = user.getUsername();
        txtFirstName.Text = user.getFirstName();
        txtLastName.Text = user.getLastName();
        txtAddress.Text = user.getAddress();
        txtCity.Text = user.getCity();
        txtAccountCreationDate.Text = user.getAccountCreationDate().ToShortDateString();
        txtState.Text = user.getState();
        txtZipCode.Text = user.getZipCode();
        txtEmail.Text = user.getEamil();

        List<AccessLevel> allAccessLevels = AccessLevelManager.getAllLevels();

        ddlAccessLevel.DataSource = allAccessLevels;
        ddlAccessLevel.DataTextField = "level";
        ddlAccessLevel.DataValueField = "ID";
        ddlAccessLevel.DataBind();
        int accessLevel = businesslayer.getUserAccessLevel(user.getId());
        ddlAccessLevel.SelectedValue = accessLevel.ToString();
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        User user = new User();
        user.setId(Convert.ToInt32(hidUserID.Value));
        user.setUsername(txtUsername.Text);
        user.setFirstName(txtFirstName.Text);
        user.setLastName(txtLastName.Text);
        user.setAddress(txtAddress.Text);
        user.setCity(txtCity.Text);
        user.setState(txtState.Text);
        user.setZipCode(txtZipCode.Text);
        user.setEmail(txtEmail.Text);
        user.setAccountCreationDate(DateTime.Parse(txtAccountCreationDate.Text));

        UsersManager businesslayer = new UsersManager();
        Boolean userUpdated = businesslayer.updateUserDetails(user);
        ddlAccessLevel.ClearSelection();
        Boolean accessLevelUpdated = businesslayer.updateUserAccessLevel(Convert.ToInt32(hidUserID.Value), Convert.ToInt32(ddlAccessLevel.SelectedValue));

        if (userUpdated && accessLevelUpdated)
        {
            lblMsg.Text = "User updated successfuly!";
        }
        else
        {
            lblMsg.Text = "Sorry, there was an error, please try again";
        }
        
        
    }
}