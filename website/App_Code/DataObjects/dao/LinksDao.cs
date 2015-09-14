using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using cisseniorproject.dataobjects.data;

/// <summary>
/// Summary description for LinksDao
/// 
/// Data Access object to pull data from the Links Table
/// </summary>
namespace cisseniorproject.dataobjects.data.dao
{


    public class LinksDao
    {
        String database;

        public LinksDao()
        {
            database = System.Configuration.ConfigurationManager.ConnectionStrings["CISSeniorProjectDB"].ConnectionString;
        }

        public List<Links> getUserLinks(String username)
        {
            List<Links> links = new List<Links>();

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {

                try
                {

                    sqlConn.Open();

                    String select = "SELECT [LINKS].path, [LINKS].link_text FROM [LINKS] INNER JOIN [USERS] ON [USERS].access_level = [LINKS].access_level WHERE username = @username";

                    OleDbCommand cmd = new OleDbCommand(select, sqlConn);

                    cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;

                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        String path = dr["path"].ToString();
                        String text = dr["link_text"].ToString();

                        Links link = new Links(path, text);
                        links.Add(link);
                    }


                }
                catch (OleDbException ex)
                {

                }
                finally
                {
                    sqlConn.Close();
                }
                return links;
            }


        }
    }
}