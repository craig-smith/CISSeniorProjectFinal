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
    }
}