using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionVariableManager
/// </summary>
public class SessionVariableManager
{
    private const String USERNAME = "username";
    private const String LINKS = "links";
	public SessionVariableManager()
	{
		
	}

    public static String getUsername()
    {
        if (isNotNull(HttpContext.Current.Session[USERNAME]))
        {
            return HttpContext.Current.Session[USERNAME].ToString();
        }
        else return String.Empty;
    }

    
    public static void setUsername(string username)
    {
        HttpContext.Current.Session[USERNAME] = username;
    }

    public static List<Links> getLinks()
    {
        return (List<Links>) HttpContext.Current.Session[LINKS];
    }

    public static void setLinks(List<Links> links)
    {
        HttpContext.Current.Session[LINKS] = links;
    }

    private static Boolean isNotNull(object sessionVarialbe)
    {
        if (sessionVarialbe != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}