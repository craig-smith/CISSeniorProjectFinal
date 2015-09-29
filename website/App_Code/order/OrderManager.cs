using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cisseniorproject.dataobjects;

/// <summary>
/// Summary description for OrderManager
/// </summary>
namespace cisseniorproject.order
{


    public class OrderManager
    {
        private List<InventoryItem> inventoryItems;
        private List<OrderItem> orderItems;
        private PaymentInformation paymentInformation;
        private Order order;

        public OrderManager()
        {
            inventoryItems = new List<InventoryItem>();
            orderItems = new List<OrderItem>();
            order = new Order();
        }

        public Boolean addItemToOrder(InventoryItem inventoryItem, int count)
        {
            if (count < inventoryItem.getProductCount())
            {
                OrderItem orderItem = new OrderItem();
                orderItem.setProductId(inventoryItem.getInventoryId());
                orderItem.setCount(count);

                orderItems.Add(orderItem);

                inventoryItem.orderItem(count);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addPaymentInfo(PaymentInformation paymentInformation)
        {
            this.paymentInformation = paymentInformation;
        }
    }
}