using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentInformationDAO
/// 
/// Written By Craig Smith 19/17/15
/// 
/// DataLayer for Payment Information Table
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class PaymentInformationDAO
    {
        String database;
        public PaymentInformationDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        internal bool addNewCreditCard(PaymentInformation newCreditCard)
        {
            using (OleDbConnection sqlCon = new OleDbConnection(database))
            {
                try
                {


                    sqlCon.Open();

                    String insert = "INSERT INTO [PAYMENT_INFORMATION] ([user_id], [credit_card_type], [credit_card_number], [card_city], [card_state], [card_exp_date], [security_code]) " +
                        "VALUES(@userId, @creditCardType, @creditCardNumber, @cardCity, @cardState, @expDate, @securityCode)";
                    OleDbCommand cmd = new OleDbCommand(insert, sqlCon);

                    cmd.Parameters.Add("userId", OleDbType.VarChar, 255).Value = newCreditCard.getUser().getId();
                    cmd.Parameters.Add("creditCardType", OleDbType.VarChar, 255).Value = newCreditCard.getCreditCardType();
                    cmd.Parameters.Add("creditCardNumber", OleDbType.VarChar, 255).Value = newCreditCard.getCreditCardNumber();
                    cmd.Parameters.Add("cardCity", OleDbType.VarChar, 255).Value = newCreditCard.getCity();
                    cmd.Parameters.Add("cardState", OleDbType.VarChar, 255).Value = newCreditCard.getState();
                    cmd.Parameters.Add("expDate", OleDbType.VarChar, 255).Value = newCreditCard.getCardExpDate();
                    cmd.Parameters.Add("securityCode", OleDbType.VarChar, 255).Value = newCreditCard.getSecurityCode();

                    cmd.Prepare();
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
                    sqlCon.Close();
                }
            }
        }

        internal List<PaymentInformation> getUserPaymentInfo(User user)
        {
            List<PaymentInformation> userPaymentInfo = new List<PaymentInformation>();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    String select = "SELECT * FROM [PAYMENT_INFORMATION] WHERE [user_id] = @userId";
                    OleDbCommand cmd = new OleDbCommand(select, sqlconn);

                    cmd.Parameters.Add("userId", OleDbType.Integer).Value = user.getId();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int paymentInformationId = (int) reader["payment_information_id"];
                        int userId = (int)reader["user_id"];
                        String creditCartType = reader["credit_card_type"].ToString();
                        String creditCardNumber = reader["credit_card_number"].ToString();
                        String cardCity = reader["card_city"].ToString();
                        String cardState = reader["card_state"].ToString();
                        DateTime cardExpDate = DateTime.Parse(reader["card_exp_date"].ToString());
                        String securityCode = reader["security_code"].ToString();

                        PaymentInformation paymentInfo = new PaymentInformation(paymentInformationId, user, creditCartType, 
                            creditCardNumber, cardCity, cardState, cardExpDate, securityCode);
                        userPaymentInfo.Add(paymentInfo);
                    }
                    return userPaymentInfo;
                }
                catch(OleDbException ex)
                {
                    userPaymentInfo = null;
                    return userPaymentInfo;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal PaymentInformation getUserCreditCard(int paymentInfoId)
        {
            PaymentInformation userCreditCard = new PaymentInformation();
            User user = new User();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT [PAYMENT_INFORMATION].payment_information_id, [PAYMENT_INFORMATION].credit_card_type, [PAYMENT_INFORMATION].credit_card_number, [PAYMENT_INFORMATION].card_city, [PAYMENT_INFORMATION].card_state, " +
                        "[PAYMENT_INFORMATION].card_exp_date, [PAYMENT_INFORMATION].security_code, [USERS].user_id, [USERS].username, [USERS].first_name, [USERS].last_name, [USERS].address, " +
                        "[USERS].city, [USERS].state, [USERS].zip_code, [USERS].account_creation_date, [USERS].access_level, [USERS].email FROM [PAYMENT_INFORMATION] " +
                        "INNER JOIN [USERS] ON [USERS].user_id = [PAYMENT_INFORMATION].user_id " +
                        "WHERE [PAYMENT_INFORMATION].payment_information_id = @paymentInfoId";
                    cmd.CommandText = select;

                    cmd.Parameters.Add("paymentInfoId", OleDbType.Integer).Value = paymentInfoId;
                    cmd.Prepare();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        user.setId((int) reader["user_id"]);
                        user.setUsername(reader["username"].ToString());
                        user.setFirstName(reader["first_name"].ToString());
                        user.setLastName(reader["last_name"].ToString());
                        user.setAddress(reader["address"].ToString());
                        user.setCity(reader["city"].ToString());
                        user.setState(reader["state"].ToString());
                        user.setZipCode(reader["zip_code"].ToString());
                        user.setAccountCreationDate(DateTime.Parse(reader["account_creation_date"].ToString()));
                        user.setEmail(reader["email"].ToString());

                        userCreditCard.setUser(user);

                        userCreditCard.setPaymentInformationId((int) reader["payment_information_id"]);
                        userCreditCard.setCreditCardType(reader["credit_card_type"].ToString());
                        userCreditCard.setCreditCardNumber(reader["credit_card_number"].ToString());
                        userCreditCard.setCity(reader["card_city"].ToString());
                        userCreditCard.setState(reader["card_state"].ToString());
                        userCreditCard.setCardExpDated(DateTime.Parse(reader["card_exp_date"].ToString()));
                        userCreditCard.setSecurityCode(reader["security_code"].ToString());
                    }
                    return userCreditCard;
                }
                catch (OleDbException ex)
                {
                    userCreditCard = null;
                    return userCreditCard;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}