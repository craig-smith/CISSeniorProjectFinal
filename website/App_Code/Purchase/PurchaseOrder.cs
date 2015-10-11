using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrder
/// </summary>
namespace cisseniorproject.purchase
{


    public class PurchaseOrder
    {
        public Manufacturer manufacturer { get; set; }
        public List<PurchaseOrderItem> items { get; set; }
        public PurchaseOrder()
        {
            manufacturer = new Manufacturer();
            items = new List<PurchaseOrderItem>();
        }

        public void addItemToOrder(PurchaseOrderItem item)
        {
            items.Add(item);
        }
    }
}