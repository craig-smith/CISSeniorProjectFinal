using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderItem
/// </summary>
namespace cisseniorproject.purchase
{
    

    public class PurchaseOrderItem
    {
        public String itemName { get; set; }
        public int orderAmount { get; set; }
        public Double itemPrice { get; set; }

        public PurchaseOrderItem()
        {

        }
    }
}