using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Links
/// 
/// Data Object used to hold information about links
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
public class Links
{
    private int linkId;
    private String path;
    private int accessLevel;
    private String linkText;

	public Links()
	{
		
	}

    public Links(int linkId, String path, int accessLevel, String linkText)
    {
        this.linkId = linkId;
        this.path = path;
        this.accessLevel = accessLevel;
        this.linkText = linkText;
    }

    public int getLinkId()
    {
        return this.linkId;
    }
    public void setLinkId(int linkId)
    {
        this.linkId = linkId;
    }

    public String getPath()
    {
        return this.path;
    }
    public void setPath(String path)
    {
        this.path = path;
    }

    public int getAccessLevel()
    {
        return this.accessLevel;
    }
    public void setAccessLevel(int accessLevel)
    {
        this.accessLevel = accessLevel;
    }

    public String getLinkText()
    {
        return this.linkText;
    }
    public void setLinkText(String linkText)
    {
        this.linkText = linkText;
    }
}