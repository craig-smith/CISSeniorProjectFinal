using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cisseniorproject.dataobjects;

/// <summary>
/// Summary description for AccessLevelManager
/// </summary>
namespace cisseniorproject.accesslevel
{


    public class AccessLevelManager
    {
        public AccessLevelManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static List<AccessLevel> getAllLevels()
        {
            AccessLevelDAO datalayer = new AccessLevelDAO();
            List<AccessLevel> allAccessLevels = datalayer.getAllAccessLevels();

            return allAccessLevels;
        }
    }
}