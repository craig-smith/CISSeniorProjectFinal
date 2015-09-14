using cisseniorproject.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    
    {
        checkLogin();
    }

    private void checkLogin()
    {
        if (Security.isLoggedIn())
        {
            userPanel.Visible = true;
            String username = Security.getUsername();
            lblMsg.Text = "Welcome back " + username + "!";
        }
        else
        {
           
            loginPanel.Visible = true;
            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Security.logIn(txtUsername.Text, txtPassword.Text);
            Boolean isLogggedIn = Security.isLoggedIn();
            if (isLogggedIn)
            {
                checkLogin();
                LinksControl control = new LinksControl();
                control.reloadLinks();
                Response.Redirect(Request.Path);
            }
        }
    }
    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Boolean created = Security.createNewUser(txtUsername.Text, txtPassword.Text);
            if (created)
            {
                lblLoginMessage.Text = "Account created, please log in.";
            }
            else
            {
                lblLoginMessage.Text = "Username already taken. Please choose another.";
            }
        }
    }
}