using cisseniorproject.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryManager
/// </summary>
namespace cisseniorproject.inventory
{


    public class InventoryManager
    {
        public InventoryManager()
        {
            
        }

        public static List<InventoryItem> getNext10Products(int from)
        {
            ProductsDAO datalayer = new ProductsDAO();
            List<InventoryItem> items = datalayer.getNextTenItems(from);

            return items;
        }

        public static InventoryItem getSingleItem(int viewItem)
        {
            ProductsDAO datalayer = new ProductsDAO();
            InventoryItem item = datalayer.getSingleItem(viewItem);

            return item;
        }

        public static bool updateInventoryItem(InventoryItem item)
        {
            ProductsDAO datalayer = new ProductsDAO();
           bool success = datalayer.updateInventoryItem(item);
           return success;
        }

        public static List<InventoryItem> getAllItems()
        {
            ProductsDAO datalayer = new ProductsDAO();
            List<InventoryItem> completeInventory = datalayer.getAllInventory();
            return completeInventory;
        }

        public static bool insertNewItem(InventoryItem updateItem)
        {
            ProductsDAO datalayer = new ProductsDAO();
            bool success = datalayer.insertNewItem(updateItem);
            return success;
        }

        public static InventoryItem getItemByName(string name)
        {
            ProductsDAO datalayer = new ProductsDAO();
            return datalayer.getProductByName(name);
        }

        public static List<int> getTotalItems()
        {
            ProductsDAO datalayer = new ProductsDAO();
            return datalayer.getAllProductIds();
        }
    }
}