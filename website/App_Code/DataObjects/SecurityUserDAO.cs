using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SecurityUserDAO
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class SecurityUserDAO
    {
        public SecurityUserDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal static bool createAccount(Credentials newUser)
        {
            Boolean created;
            String database = DatabaseConnectionManager.getDatabaseConnectionString();

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();

                    OleDbCommand cmd = sqlConn.CreateCommand();
                    OleDbTransaction transact = sqlConn.BeginTransaction();
                    cmd.Transaction = transact;

                    String insert1 = "INSERT INTO [USERS]([username], [access_level], [account_creation_date]) VALUES(@username, @accessLevel, @accountCreationDate)";
                    cmd.Parameters.Clear();
                    cmd.CommandText = insert1;
                    cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = newUser.getUsername();
                    cmd.Parameters.Add("accessLevel", OleDbType.VarChar, 255).Value = newUser.getAccessLevel();
                    cmd.Parameters.Add("accountCreationDate", OleDbType.Date).Value = System.DateTime.Now;
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    String select = "SELECT LAST([user_id]) FROM [USERS]";
                    cmd.Parameters.Clear();
                    cmd.CommandText = select;
                    cmd.Prepare();
                    int userId = (int)cmd.ExecuteScalar();

                    String insert2 = "INSERT INTO [PASSWORD]([password_id], [password], [salt]) VALUES(@passwordId, @password, @salt)";
                    cmd.Parameters.Clear();
                    cmd.CommandText = insert2;
                    cmd.Parameters.Add("passwordId", OleDbType.Integer).Value = userId;
                    cmd.Parameters.Add("password", OleDbType.VarChar, 255).Value = newUser.getPassword();
                    cmd.Parameters.Add("salt", OleDbType.VarChar, 255).Value = newUser.getSalt();
                    cmd.Prepare();



                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        created = true;
                        transact.Commit();
                    }
                    else
                    {
                        created = false;
                        transact.Rollback();
                    }
                    return created;
                }
                catch (OleDbException ex)
                {
                    created = false;
                    return created;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        internal static Credentials getUserCredentials(string username)
        {
            Credentials credentials = null;
            String database = DatabaseConnectionManager.getDatabaseConnectionString();

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();
                    OleDbCommand cmd = sqlConn.CreateCommand();

                    String select = "SELECT [USERS].user_id, [USERS].username, [USERS].access_level, [PASSWORD].password, [PASSWORD].salt FROM [USERS] " +
                    "INNER JOIN [PASSWORD] ON [PASSWORD].password_id = [USERS].user_id " +
                    "WHERE [username] = @username";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;
                    cmd.Prepare();

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = (int) reader["user_id"];
                        String user = reader["username"].ToString();
                        String password = reader["password"].ToString();
                        String salt = reader["salt"].ToString();
                        String accessLevel = reader["access_level"].ToString();
                        credentials = new Credentials(userId, user, password, salt, accessLevel);

                    }

                    return credentials;

                }
                catch (OleDbException ex)
                {
                    credentials = null;
                    return credentials;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        internal static bool changePassword(Credentials newPassword)
        {
            String database = DatabaseConnectionManager.getDatabaseConnectionString();

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();
                    String update = "UPDATE [PASSWORD] SET [password] = @password, [salt] = @salt WHERE [password_id] = @userId";

                    OleDbCommand cmd = new OleDbCommand(update, sqlConn);
                    cmd.Parameters.Add("password", OleDbType.VarChar, 255).Value = newPassword.getPassword();
                    cmd.Parameters.Add("salt", OleDbType.VarChar, 255).Value = newPassword.getSalt();
                    cmd.Parameters.Add("userId", OleDbType.Integer).Value = newPassword.getUserId();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                catch(OleDbException ex)
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