using cisseniorproject.dataobjects;
using cisseniorproject.security;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LinksManager
/// 
/// Used to manage creation of user links list to be stored in session manager.
/// 
/// Written by Craig Smith 9/13/15
/// </summary>
namespace cisseniorproject.utils
{


    public class LinksManager
    {
        public LinksManager()
        {

        }

        public static List<Links> getAllowedLinks()
        {
            List<Links> allowedLinks = SessionVariableManager.getLinks();
            if (allowedLinks != null)
            {
                return allowedLinks;

            }
            else
            {
                allowedLinks = getLinksFromDB();


            }

            return allowedLinks;
        }

        public static List<Links> getLinksFromDB()
        {
            String username = Security.getUsername();

            LinksDao dataLayer = new LinksDao();

            List<Links> userLinks = dataLayer.getUserLinks(username);
            SessionVariableManager.setLinks(userLinks);
            return userLinks;
        }
    }
}