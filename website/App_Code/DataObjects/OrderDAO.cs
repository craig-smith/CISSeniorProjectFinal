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

        public int createOrder(Order order)
        {
            Int32 orderNumber = 0;
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();
                    OleDbTransaction transact = sqlconn.BeginTransaction();
                    cmd.Transaction = transact;

                    String insert = "INSERT INTO [ORDERS]([user_id], [payment_id], [validated], [completed], [payment_amount], [collect_on_delivery]) " +
                        "VALUES (@userId, @paymentId, false, false, @paymentAmount, @collectOnDelivery)";
                    cmd.CommandText = insert;
                    cmd.Parameters.Add("userId", OleDbType.Integer).Value = order.getPaymentInformation().getUser().getId();
                    cmd.Parameters.Add("paymentId", OleDbType.Integer).Value = order.getPaymentInformation().getPaymentInformationId();
                    cmd.Parameters.Add("paymentAmount", OleDbType.Double).Value = order.getPaymentAmount();
                    cmd.Parameters.Add("collectOnDelivery", OleDbType.Boolean).Value = order.getCollectOnDelivery();
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
                    orderNumber = (int)cmd.ExecuteScalar();
                    order.setOrderId(orderNumber);

                    List<OrderItem> items = order.getOrderItems();

                    foreach (OrderItem item in items)
                    {
                        cmd.Parameters.Clear();
                        String insert2 = "INSERT INTO [ORDER_ITEMS]([order_id], [product_id], [count], [sale_price]) " +
                               "VALUES(@orderId, @productId, @count, @salePrice)";
                        cmd.CommandText = insert2;
                        cmd.Parameters.Add("orderId", OleDbType.Integer).Value = item.getOrderId();
                        cmd.Parameters.Add("productId", OleDbType.Integer).Value = item.getProductId();
                        cmd.Parameters.Add("count", OleDbType.Integer).Value = item.getCount();
                        cmd.Parameters.Add("salePrice", OleDbType.Double).Value = item.getSalePrice();

                        cmd.Prepare();
                        int rows2 = cmd.ExecuteNonQuery();

                        if (rows2 != 1)
                        {
                            transact.Rollback();
                           
                        }
                    }                                   
                    
                    transact.Commit();

                    return orderNumber;
                }
                catch (OleDbException ex)
                {
                    orderNumber = -1;
                    return orderNumber;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        
    }
}