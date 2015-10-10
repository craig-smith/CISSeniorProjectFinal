using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryPurchaseInfoDAO
/// </summary>

namespace cisseniorproject.dataobjects
{


    public class InventoryPurchaseInfoDAO
    {
        private String database;
        public InventoryPurchaseInfoDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        public InventoryPurchaseInfo getSingleInventoryPurchaseInfo(int inventoryId)
        {
            InventoryPurchaseInfo inventoryPurchaseInfo = new InventoryPurchaseInfo();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [INVENTORY_PURCHASE_INFO] WHERE [inventory_id] = @inventoryId";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("inventoryId", OleDbType.Integer).Value = inventoryId;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        inventoryPurchaseInfo.inventoryItemId = (int)reader["inventory_item_id"];
                        inventoryPurchaseInfo.manufacturerId = (int)reader["manufacturer_id"];
                        inventoryPurchaseInfo.minInventory = (int)reader["min_inventory"];
                    }
                    return inventoryPurchaseInfo;
                }
                catch (OleDbException ex)
                {
                    return inventoryPurchaseInfo;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        public List<InventoryPurchaseInfo> getAllInventoryPurchaseInfo()
        {
            List<InventoryPurchaseInfo> allInventoryPurchaseInfo = new List<InventoryPurchaseInfo>();
            using(OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT [inventory_item_id] FROM [INVENTORY_PURCHASE_INFO]";
                    cmd.CommandText = select;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InventoryPurchaseInfo purchaseInfo = getSingleInventoryPurchaseInfo((int)reader["inventory_item_id"]);

                        allInventoryPurchaseInfo.Add(purchaseInfo);
                    }
                    return allInventoryPurchaseInfo;
                }
                catch (OleDbException ex)
                {
                    return allInventoryPurchaseInfo;
                }
                finally
                {
                    sqlconn.Close();
                }
            } 
        }

        public Boolean updateInventoryPurchaseInfo(InventoryPurchaseInfo inventoryPurchaseInfo)
        {
            Boolean success = false;
            using(OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String update = "UPDATE [INVENTORY_PURCHASE_INFO] SET [manufacturer_id] = @manufacturerId, [min_inventory] = @minInventory WHERE [inventory_id] = @inventoryId";
                    cmd.CommandText = update;
                    cmd.Parameters.Add("manufacturerId", OleDbType.Integer).Value = inventoryPurchaseInfo.manufacturerId;
                    cmd.Parameters.Add("minInventory", OleDbType.Integer).Value = inventoryPurchaseInfo.minInventory;
                    cmd.Parameters.Add("inventoryId", OleDbType.Integer).Value = inventoryPurchaseInfo.inventoryItemId;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        success = true;
                    }
                    return success;
                }
                catch (OleDbException ex)
                {
                    return success;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        public Boolean addNewInventoryPurchaseInfo(InventoryPurchaseInfo purchaseInfo)
        {
            Boolean success = false;
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String insert = "INSERT INTO [INVENTORY_PURCHASE_INFO] ([inventory_item_id], [manufacturer_id], [min_inventory]) VALUES " +
                        "(@inventoryItemId, @manufacturerId, @minInventory)";

                    cmd.CommandText = insert;
                    cmd.Parameters.Add("inventoryItemId", OleDbType.Integer).Value = purchaseInfo.inventoryItemId;
                    cmd.Parameters.Add("manufacturerId", OleDbType.Integer).Value = purchaseInfo.manufacturerId;
                    cmd.Parameters.Add("minInventory", OleDbType.Integer).Value = purchaseInfo.minInventory;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        success = true;
                    }
                    return success;
                }
                catch (OleDbException ex)
                {
                    return success;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}