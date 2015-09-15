using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderItem
/// 
/// Data Object used to hold information about order items.
/// 
/// Written by Craig Smith 9/9/15
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class OrderItem
    {
        private int orderId;
        private int productId;
        private int count;

        public OrderItem()
        {

        }

        public OrderItem(int orderId, int productId, int count)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.count = count;
        }

        public int getOrderId()
        {
            return this.orderId;
        }
        public void setOrderId(int orderId)
        {
            this.orderId = orderId;
        }

        public int getProductId()
        {
            return this.productId;
        }
        public void setProductId(int productId)
        {
            this.productId = productId;
        }

        public int getCount()
        {
            return this.count;
        }
        public void setCount(int count)
        {
            this.count = count;
        }
    }
}