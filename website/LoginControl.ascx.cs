using cisseniorproject.dataobjects;
using cisseniorproject.security;
using cisseniorproject.utils;
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
        bool isLoggedIn = Security.isLoggedIn();
        if (isLoggedIn)
        {
            setUpUserPanel();
            
        }
        else
        {
           
            loginPanel.Visible = true;
            
        }
    }

    private void setUpUserPanel()
    {
        userPanel.Visible = true;
        String username = Security.getUsername();
        lblMsg.Text = "Welcome back " + username + "!";
        List<InventoryItem> items = SessionVariableManager.getUserCart();
        if (items != null)
        {


            int itemCount = items.Count();
            double price = 0;

            foreach (InventoryItem i in items)
            {
                price += i.getSalePrice();
            }

            lblCartItems.Text = "You have " + itemCount + " item(s) in your cart with a total of " +string.Format("{0:C}", price) + ".";
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
            else
            {
                lblLoginMessage.Text = "Wrong Username or Password. Please Try Again.";
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
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        SessionVariableManager.logOut();
        Response.Redirect("index.aspx");

    }
}