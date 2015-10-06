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
        txtUsername.Text = user.getUsername();
        txtFirstName.Text = user.getFirstName();
        txtLastName.Text = user.getLastName();
        txtAddress.Text = user.getAddress();
        txtCity.Text = user.getCity();
        txtState.Text = user.getState();
        txtZipCode.Text = user.getZipCode();

        List<AccessLevel> allAccessLevels = AccessLevelManager.getAllLevels();

        ddlAccessLevel.DataSource = allAccessLevels;
        ddlAccessLevel.DataTextField = "getLevel()";
        ddlAccessLevel.DataValueField = "getID()";
    }
}