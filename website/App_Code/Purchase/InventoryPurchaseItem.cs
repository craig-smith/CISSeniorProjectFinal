using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryPurchaseItem
/// </summary>
namespace cisseniorproject.purchase
{


    public class InventoryPurchaseItem
    {
        public String itemName { get; set; }
        public int inventoryCount { get; set; }
        public String supplier { get; set; }
        public int minCount { get; set; }
        public Double itemCost { get; set; }

        public InventoryPurchaseItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}