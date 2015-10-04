using cisseniorproject.order;
using cisseniorproject.payment;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
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



        internal List<Order> getUserOrders(String username)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                List<Order> userOrders = new List<Order>();
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [ORDERS] INNER JOIN [USERS] ON [USERS].user_id = [ORDERS].user_id WHERE [USERS].username = @username";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Order userOrder = new Order();
                        userOrder.setOrderIdForOrderOnly((int)reader["order_id"]);
                        userOrder.setUserId((int)reader["Orders.user_id"]);
                        userOrder.setValidated((bool)reader["validated"]);
                        userOrder.setIsCollctOnDelivery((bool)reader["collect_on_delivery"]);
                        userOrder.setCompleted((bool)reader["completed"]);
                        userOrder.setPaymentAmount(Double.Parse(reader["payment_amount"].ToString(), NumberStyles.Currency));
                        
                        userOrder.setPaymentInformation(PaymentManager.getUserCreditCard((int)reader["payment_id"]));
                       
                        userOrder.setOrderItems(getOrderItems(userOrder.getOrderId()));

                        userOrders.Add(userOrder);
                    }

                    return userOrders;
                }
                catch (OleDbException ex)
                {
                    userOrders = null;
                    return userOrders;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        private List<OrderItem> getOrderItems(int orderId)
        {
            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                try
                {
                    sqlConn.Open();
                    OleDbCommand cmd = sqlConn.CreateCommand();

                    String select = "SELECT * FROM [ORDER_ITEMS] WHERE [order_id] = @orderId";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("orderId", OleDbType.Integer).Value = orderId;

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.setOrderId((int)reader["order_id"]);
                        orderItem.setProductId((int)reader["product_id"]);
                        orderItem.setCount((int)reader["count"]);
                        orderItem.setSalePrice(Double.Parse(reader["sale_price"].ToString(), NumberStyles.Currency));

                        orderItems.Add(orderItem);
                    }

                    return orderItems;
                }
                catch (OleDbException ex)
                {
                    orderItems = null;
                    return orderItems;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }



        internal Order getSingleOrder(int orderId)
        {
            Order order = new Order();

            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();
                    OleDbCommand cmd = sqlConn.CreateCommand();

                    String select = "SELECT * FROM [ORDERS] WHERE [order_id] = @orderId";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("orderId", OleDbType.Integer).Value = orderId;

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        order.setOrderIdForOrderOnly((int)reader["order_id"]);
                        order.setUserId((int)reader["user_id"]);
                        order.setValidated((bool)reader["validated"]);
                        order.setCompleted((bool)reader["completed"]);
                        order.setPaymentAmount(Double.Parse(reader["payment_amount"].ToString(), NumberStyles.Currency));
                        order.setIsCollctOnDelivery((bool)reader["collect_on_delivery"]);
                        order.setPaymentInformation(getPaymentInformation((int)reader["payment_id"]));
                        order.setOrderItems(getOrderItems((int)reader["order_id"]));
                    }

                    return order;
                }
                catch(OleDbException ex)
                {
                    return order;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        private PaymentInformation getPaymentInformation(int paymentMethodId)
        {
           PaymentInformation paymentMethod =  PaymentManager.getUserCreditCard(paymentMethodId);
           return paymentMethod;
        }

        internal void validateOrder(int orderNumber)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();
                    String update = "UPDATE [ORDERS] SET [validated] = TRUE WHERE [order_id] = @orderId";
                    cmd.CommandText = update;
                    cmd.Parameters.Add("orderId", OleDbType.Integer).Value = orderNumber;

                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {

                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal void completeOrder(int orderNumber)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();
                    String update = "UPDATE [ORDERS] SET [completed] = TRUE WHERE [order_id] = @orderId";
                    cmd.CommandText = update;
                    cmd.Parameters.Add("orderId", OleDbType.Integer).Value = orderNumber;

                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {

                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal List<OrderId> getAllIncompleteOrders()
        {
            List<OrderId> orderNumbers = new List<OrderId>();

            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT [order_id] FROM [ORDERS] WHERE [validated] = FALSE";
                    cmd.CommandText = select;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderId orderId = new OrderId();
                        orderId.orderId = (int)reader["order_id"];
                        orderNumbers.Add(orderId);
                    }
                    return orderNumbers;
                }
                catch (OleDbException ex)
                {
                    return orderNumbers;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal List<OrderId> getAllInvalidOrders()
        {
            List<OrderId> orderNumbers = new List<OrderId>();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT [order_id] FROM [ORDERS] WHERE [validated] = TRUE AND [completed] = FALSE";
                    cmd.CommandText = select;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderId orderId = new OrderId();
                        orderId.orderId = (int)reader["order_id"];
                        orderNumbers.Add(orderId);
                    }
                    return orderNumbers;
                }
                catch(OleDbException ex)
                {
                    return orderNumbers;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}