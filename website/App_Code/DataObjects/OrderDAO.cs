using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDAO
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class OrderDAO
    {
        private String database;
        
        public OrderDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        public Boolean createOrder(Order order)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();
                    OleDbTransaction transact = sqlconn.BeginTransaction();

                    String insert = "INSERT INTO [ORDERS]([user_id], [payment_id], [validated], [completed]) " +
                        "VALUES (@userId, @paymentId, false, false)";
                    cmd.CommandText = insert;
                    cmd.Parameters.Add("userId", OleDbType.Integer).Value = order.getPaymentInformation().getUser().getId();
                    cmd.Parameters.Add("paymentId", OleDbType.Integer).Value = order.getPaymentInformation().getPaymentInformationId();
                    cmd.Prepare();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows != 1)
                    {
                        transact.Rollback();
                    }

                    cmd.Parameters.Clear();
                    String select = "SELECT LAST([order_id]) FROM [ORDERS]";
                    cmd.CommandText = select;
                    cmd.Prepare();
                    order.setOrderId((int)cmd.ExecuteScalar());

                    List<OrderItem> items = order.getOrderItems();

                    foreach (OrderItem item in items)
                    {
                        cmd.Parameters.Clear();
                        String insert2 = "INSERT INTO [ORDER_ITEMS]([order_id], [product_id], [count]) " +
                               "VALUES(@orderId, @productId, @count";
                        cmd.CommandText = insert2;
                        cmd.Parameters.Add("orderId", OleDbType.Integer).Value = item.getOrderId();
                        cmd.Parameters.Add("productId", OleDbType.Integer).Value = item.getProductId();
                        cmd.Parameters.Add("count", OleDbType.Integer).Value = item.getCount();

                        cmd.Prepare();
                        int rows2 = cmd.ExecuteNonQuery();

                        if (rows2 != 1)
                        {
                            transact.Rollback();
                           
                        }
                    }

                    transact.Commit();
                    return true;

                }
                catch (OleDbException ex)
                {
                    return false;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}