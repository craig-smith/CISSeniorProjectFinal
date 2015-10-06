using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductsDAO
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class ProductsDAO
    {
        private String database;
        public ProductsDAO()
	{
        database = DatabaseConnectionManager.getDatabaseConnectionString();
	}

        public List<InventoryItem> getNextTenItems(int from)
        {
            using (OleDbConnection sqlCon = new OleDbConnection(database))
            {
                List<InventoryItem> items = new List<InventoryItem>();
                try
                {
                    sqlCon.Open();
                    String select = "SELECT TOP 10 * FROM [INVENTORY_ITEM] WHERE [inventory_id] > @from ORDER BY [inventory_id]";

                    OleDbCommand cmd = new OleDbCommand(select, sqlCon);                   
                    cmd.Parameters.Add("from", OleDbType.Integer).Value = from;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    addItemsToList(items, reader);

                    return items;
                }
                catch(OleDbException ex)
                {
                    return items;
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private  void addItemsToList(List<InventoryItem> items, OleDbDataReader reader)
        {
            while (reader.Read())
            {
                InventoryItem item = getItemFromReader(reader);
                items.Add(item);

            }
        }

        private  InventoryItem getItemFromReader(OleDbDataReader reader)
        {
            int inventoryId = (int)reader["inventory_id"];
            String productName = (String)reader["product_name"];
            int productCount = (int)reader["product_count"];
            int itemsOnHold = (int)reader["items_on_hold"];
            Double unitPrice = Double.Parse(reader["unit_price"].ToString(), NumberStyles.Currency);
            Double salePrice = Double.Parse(reader["sale_price"].ToString(), NumberStyles.Currency);
            String shortDescription = (String)reader["short_description"];
            String longDescription = (String)reader["long_description"];
            String imagePath = (String)reader["image_path"];

            InventoryItem item = new InventoryItem(inventoryId, productName, productCount, itemsOnHold, unitPrice,
                salePrice, shortDescription, longDescription, imagePath);
            return item;
        }

        public int countAllItems()
        {
            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                try
                {
                    sqlConn.Open();
                    String select = "SELECT COUNT([inventory_id]) FROM [INVENTORY_ITEM]";

                    OleDbCommand cmd = new OleDbCommand(select, sqlConn);

                    int count = (int) cmd.ExecuteScalar();

                    return count;
                }
                catch (OleDbException ex)
                {
                    return 0;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

        }

        public List<InventoryItem> selectKeyWordNextTen(String keyWord, int from)
        {
            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                 List<InventoryItem> items = new List<InventoryItem>();
                try
                {
                   

                    sqlConn.Open();
                    String select = "SELECT TOP 10 * FROM [INVENTORY_ITEM] WHERE [shrot_description] LIKE %@keyword% AND [inventory_id] > @from ORDER BY [inventory_id]";
                    
                    OleDbCommand cmd = new OleDbCommand(select, sqlConn);
                    cmd.Parameters.Add("keyword", OleDbType.VarChar, 255).Value = keyWord;
                    cmd.Parameters.Add("from", OleDbType.Integer).Value = from;

                    OleDbDataReader reader = cmd.ExecuteReader();

                    addItemsToList(items, reader);

                    return items;

                }
                catch (OleDbException ex)
                {
                    return items;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        internal InventoryItem getSingleItem(int productId)
        {
            using (OleDbConnection sqlConn = new OleDbConnection(database))
            {
                InventoryItem item = null;
                try
                {
                    sqlConn.Open();
                    String select = "SELECT * FROM [INVENTORY_ITEM] WHERE [inventory_id] = @productId";

                    OleDbCommand cmd = new OleDbCommand(select, sqlConn);
                    cmd.Parameters.Add("productId", OleDbType.Integer).Value = productId;

                    cmd.Prepare();

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        item = getItemFromReader(reader);
                    }

                    return item;
                }
                catch (OleDbException ex)
                {
                    return item;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        internal bool updateInventoryItem(InventoryItem item)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String update = "UPDATE [INVENTORY_ITEM] SET " +
                        "[product_name] = @productName, " +
                        "[product_count] = @productCount, " +
                        "[items_on_hold] = @itemsOnHold, " +
                        "[unit_price] = @unitPrice, " +
                        "[sale_price] = @salePrice, " +
                        "[short_description] = @shortDescription, " +
                        "[long_description] = @longDescription, " +
                        "[image_path] = @imagePath " +
                        "WHERE [inventory_id] = @inventoryId";

                    cmd.CommandText = update;
                    cmd.Parameters.Add("productName", OleDbType.VarChar, 255).Value = item.getProductName();
                    cmd.Parameters.Add("productCount", OleDbType.Integer).Value = item.getProductCount();
                    cmd.Parameters.Add("itemsOnHold", OleDbType.Integer).Value = item.getItemsOnHold();
                    cmd.Parameters.Add("unitPrice", OleDbType.Currency).Value = item.getUnitPrice();
                    cmd.Parameters.Add("salePrice", OleDbType.Currency).Value = item.getSalePrice();
                    cmd.Parameters.Add("shortDescription", OleDbType.VarChar, 255).Value = item.getShortDescription();
                    cmd.Parameters.Add("longDescription", OleDbType.LongVarChar).Value = item.getLongDescription();
                    cmd.Parameters.Add("imagePath", OleDbType.VarChar, 255).Value = item.getImageUrl();
                    cmd.Parameters.Add("inventoryId", OleDbType.Integer).Value = item.getInventoryId();

                    int rows = cmd.ExecuteNonQuery();
                    return true;
                    
                }
                catch(OleDbException ex)
                {
                    return false;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            
        }

        internal List<InventoryItem> getAllInventory()
        {
            List<InventoryItem> completeInventory = new List<InventoryItem>();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [INVENTORY_ITEM]";
                    cmd.CommandText = select;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        InventoryItem item = getItemFromReader(reader);
                        completeInventory.Add(item);
                    }

                    return completeInventory;
                }
                catch (OleDbException ex)
                {
                    return completeInventory;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal bool insertNewItem(InventoryItem updateItem)
        {
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    string insert = "INSERT INTO [INVENTORY_ITEM] ([product_name], [product_count], [items_on_hold], " +
                         "[unit_price], [sale_price], [short_description], [long_description], [image_path]) " +
                        "VALUES (@productName, @productCount, @itemsOnHold, @unitPrice, @salePrice, @shortDescription, @longDescription, @imagePath)";

                    cmd.CommandText = insert;
                    cmd.Parameters.Add("productName", OleDbType.VarChar, 255).Value = updateItem.getProductName();
                    cmd.Parameters.Add("productCount", OleDbType.Integer).Value = updateItem.getProductCount();
                    cmd.Parameters.Add("itemsOnHold", OleDbType.Integer).Value = updateItem.getItemsOnHold();
                    cmd.Parameters.Add("unitPrice", OleDbType.Currency).Value = updateItem.getUnitPrice();
                    cmd.Parameters.Add("salePrice", OleDbType.Currency).Value = updateItem.getSalePrice();
                    cmd.Parameters.Add("shortDescription", OleDbType.VarChar, 255).Value = updateItem.getShortDescription();
                    cmd.Parameters.Add("longDescription", OleDbType.LongVarChar).Value = updateItem.getLongDescription();
                    cmd.Parameters.Add("imagePath", OleDbType.VarChar, 255).Value = updateItem.getImageUrl();

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
                    sqlconn.Close();
                }
            }
        }
    }
}