using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAO
/// 
/// Used for interaction with the user table
/// </summary>
namespace cisseniorproject.dataobjects
{
    

    public class UserDAO
    {
        private String database;
        public UserDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        public User getUserDetails(String username)
        {
            User user = null;

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();

                    String select = "SELECT * FROM [USERS] WHERE [username] = @username";

                    OleDbCommand cmd = new OleDbCommand(select, sqlConn);

                    cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;

                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int userId = (int) dr["user_id"];
                        String userName = dr["username"].ToString();
                        String firstName = dr["first_name"].ToString();
                        String lastName = dr["last_name"].ToString();
                        String address = dr["address"].ToString();
                        String city = dr["city"].ToString();
                        String state = dr["state"].ToString();
                        String zipCode = dr["zip_code"].ToString();                      
                        DateTime accountCreationDate = (DateTime)dr["account_creation_date"];                                               
                        int accessLevel = (int) dr["access_level"];
                        String email = dr["email"].ToString();

                        user = new User(userId, userName, firstName, lastName, address, city, state, zipCode, accountCreationDate, email);

                    }
                    
                }
                catch (OleDbException ex)
                {

                }
                finally
                {
                    sqlConn.Close();
                }

                return user;
            }
        }

        internal bool updateUser(User user)
        {
            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();
                    String insert = "UPDATE [USERS] " +
                        "SET [first_name] = @firstName," +
                        "[last_name] = @lastName," +
                        "[address] = @address," +
                        "[city] = @city," +
                        "[state] = @state," +
                        "[zip_code] = @zipCode," +
                        "[email] = @email " +
                        "WHERE ([user_id] = @userId)";

                    OleDbCommand cmd = new OleDbCommand(insert, sqlConn);

                    cmd.Parameters.Add("firstName", OleDbType.VarChar, 255).Value = user.getFirstName();
                    cmd.Parameters.Add("lastName", OleDbType.VarChar, 255).Value = user.getLastName();
                    cmd.Parameters.Add("address", OleDbType.VarChar, 255).Value = user.getAddress();
                    cmd.Parameters.Add("city", OleDbType.VarChar, 255).Value = user.getCity();
                    cmd.Parameters.Add("state", OleDbType.VarChar, 255).Value = user.getState();
                    cmd.Parameters.Add("zipCode", OleDbType.VarChar, 255).Value = user.getZipCode();
                    cmd.Parameters.Add("email", OleDbType.VarChar, 255).Value = user.getEamil();
                    cmd.Parameters.Add("userId", OleDbType.Integer).Value = user.getId();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (OleDbException ex)
                {
                    return false;
                }
                finally
                {
                    sqlConn.Close();
                }

            }
           
        }
    }
}