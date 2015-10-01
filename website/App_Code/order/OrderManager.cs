using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cisseniorproject.dataobjects;
using cisseniorproject.inventory;

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
        private double paymentAmount;
        private bool isCollectOnDelivery;
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
                orderItem.setSalePrice(inventoryItem.getSalePrice());

                orderItems.Add(orderItem);

                inventoryItem.orderItem(count);
                inventoryItems.Add(inventoryItem);
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

        public void setIsCollectOnDelivery(bool isCollectOnDelivery)
        {
            this.isCollectOnDelivery = isCollectOnDelivery;
        }
        public void setPaymentAmount(double paymentAmount)
        {
            this.paymentAmount = paymentAmount;
        }

        public int submitOrder()
        {
            int orderNumber = -1;
            if (paymentInformation != null && orderItems.Count() >= 1)
            {
                order.setPaymentInformation(paymentInformation);
                order.setOrderItems(orderItems);

                double orderTotal = getTotalOrderCost();

                if (isCollectOnDelivery)
                {
                    if (paymentAmount >= (Math.Round((orderTotal *.1), 2, MidpointRounding.AwayFromZero)))
                    {
                        order.setPaymentAmount(paymentAmount);
                        order.setIsCollctOnDelivery(isCollectOnDelivery);
                        OrderDAO datalayer = new OrderDAO();
                        orderNumber = datalayer.createOrder(order);
                    }
                    else
                    {
                        return orderNumber;
                    }
                }
                else if (paymentAmount == getTotalOrderCost())
                {
                    order.setPaymentAmount(paymentAmount);
                    order.setIsCollctOnDelivery(isCollectOnDelivery);
                    OrderDAO datalayer = new OrderDAO();
                    orderNumber = datalayer.createOrder(order);
                }
                
               
            }
            updateInventory(inventoryItems);
            return orderNumber;
        }

        private void updateInventory(List<InventoryItem> inventoryItems)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                InventoryManager.updateInventoryItem(item);
            }
            
        }

        public double getTotalOrderCost(List<InventoryItem> items, List<Double> itemCount)
        {
            double totalCost = 0;
            for (int i = 0; i < items.Count(); i++ )
            {
                double itemPrice = items[i].getSalePrice() * itemCount[i];
                totalCost += itemPrice;
            }

            return totalCost;
            
        }

        private double getTotalOrderCost()
        {
            double totalCost = 0;
            for (int i = 0; i < order.getOrderItems().Count(); i++)
            {
                totalCost += order.getOrderItems()[i].getCount() * order.getOrderItems()[i].getSalePrice();
            }

            return totalCost;
        }
    }
}