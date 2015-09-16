using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConnectionManager
/// 
/// Utility class to maintine database connection strings
/// </summary>
namespace cisseniorproject.dataobjects 
{
    public class DatabaseConnectionManager
    {
	    public DatabaseConnectionManager()
	    {
		
	    }

        public static String getDatabaseConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["CISSeniorProjectDB"].ConnectionString;
        }
    }
}