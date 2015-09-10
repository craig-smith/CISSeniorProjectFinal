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