using cisseniorproject.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsersManager
/// </summary>
public class UsersManager
{
    UserDAO dataLayer;
	public UsersManager()
	{
        dataLayer = new UserDAO();
	}

    public User getUserData(String username)
    {
       
        User user = dataLayer.getUserDetails(username);

        return user;
    }

    public Boolean updateUserDetails(User user)
    {
        Boolean updated = dataLayer.updateUser(user);

        return updated;
    }
}