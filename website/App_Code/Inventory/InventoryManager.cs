﻿using cisseniorproject.dataobjects;
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
    }
}