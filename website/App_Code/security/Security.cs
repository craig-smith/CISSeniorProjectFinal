using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Security
/// </summary>
public class Security
{
	public Security()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool isLoggedIn()
    {
        return false;
    }

    public static string getUsername()
    {
        String username = SessionVariableManager.getUsername();
        if ( username != String.Empty)
        {
            return username;
        }
        else
        {
            username = "anonymous";
            SessionVariableManager.setUsername(username);
            return username;
        }
    }
}