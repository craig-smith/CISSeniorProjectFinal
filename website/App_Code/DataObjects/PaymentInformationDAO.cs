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
    }
}