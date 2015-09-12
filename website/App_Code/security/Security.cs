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
        String username = getUsername();
        if (username != "anonymous")
        {
            return true;
        }
        else
        {
            return false;
        }
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

    public static void logIn(String username, String password)
    {
        PasswordManager passManager = new PasswordManager(username, password);
        Boolean login = passManager.checkPassword();

        if (login)
        {
            SessionVariableManager.setUsername(username);
        }
    }

    public static bool createNewUser(string username, string password)
    {
        PasswordManager passManager = new PasswordManager(username, password);

        bool created = passManager.createNewAccount();

        return created;
    }
}