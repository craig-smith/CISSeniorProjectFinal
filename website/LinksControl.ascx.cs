using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LinksControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getNavLinks();
    }

    private void getNavLinks() 
    {
        String username = Security.getUsername();

        LinksDao dataLayer = new LinksDao();

        List<Links> userLinks = dataLayer.getUserLinks(username);

        foreach (Links link in userLinks)
        {
            writeNaveLink(link);
        }
    }

    private void writeNaveLink(Links link)
    {
        String element = "<a href='" + link.getPath() + "'><div class='nav-item'>" + link.getLinkText() + "</div></a>";
        LiteralControl userLink = new LiteralControl(element);


        linksPlaceHolder.Controls.Add(userLink);
    }
}