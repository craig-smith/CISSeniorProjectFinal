using cisseniorproject.dataobjects;
using cisseniorproject.utils;
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
        List<Links> allowedLinks = LinksManager.getAllowedLinks();
        sendLinksToWrite(allowedLinks);
        
    }    

    private void sendLinksToWrite(List<Links> userLinks)
    {
        foreach (Links link in userLinks)
        {
            if (link.getLinkText() != String.Empty)
            {
                writeNaveLink(link);
            }
        }
    }

    private void writeNaveLink(Links link)
    {
        String element = "<a href='" + link.getPath() + "'><div class='nav-item'>" + link.getLinkText() + "</div></a>";
        LiteralControl userLink = new LiteralControl(element);


        linksPlaceHolder.Controls.Add(userLink);
    }

    public void reloadLinks()
    {
        LinksManager.getLinksFromDB();  
        
    }
}