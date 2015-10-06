using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccessLevelDAO
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class AccessLevelDAO
    {
        private string database;

        public AccessLevelDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        public List<AccessLevel> getAllAccessLevels()
        {
            List<AccessLevel> allAccessLevels = new List<AccessLevel>();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [ACCESS_LEVEL]";
                    cmd.CommandText = select;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AccessLevel accessLevel = new AccessLevel();
                        accessLevel.setLevel(reader["level"].ToString());
                        accessLevel.setID((int)reader["ID"]);
                        allAccessLevels.Add(accessLevel);
                    }
                    return allAccessLevels;
                }
                catch (OleDbException ex)
                {
                    return allAccessLevels;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}