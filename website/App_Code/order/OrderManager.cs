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
            if (count <= inventoryItem.getProductCount())
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

        public List<UserOrder> getUserOrders(string userName)
        {
            OrderDAO dataLayer = new OrderDAO();
            List<Order> orders = dataLayer.getUserOrders(userName);
            List<UserOrder> userOrders = new List<UserOrder>();

            foreach (Order order in orders)
            {
                UserOrder userOrder = new UserOrder();
                userOrder.orderId = order.getOrderId();
                userOrder.orderTotal = getOrderTotal(order);

                userOrder.orderItems = getUserOrderItems(order);
                userOrder.paymentAmount = order.getPaymentAmount();
                userOrder.creditCardNumber = order.getPaymentInformation().getCreditCardNumber();
                userOrders.Add(userOrder);
            }

            return userOrders;

        }

        private double getOrderTotal(Order order)
        {
            double orderTotal = 0;
            foreach (OrderItem orderItem in order.getOrderItems())
            {
                orderTotal += orderItem.getSalePrice() * orderItem.getCount();
            }

            return orderTotal;
        }

        private List<UserOrderItem> getUserOrderItems(Order order)
        {
            List<UserOrderItem> userOrderItems = new List<UserOrderItem>();
            foreach (OrderItem orderItem in order.getOrderItems())
            {
                UserOrderItem item = new UserOrderItem();
                item.itemCost = orderItem.getSalePrice();
                item.itemCount = orderItem.getCount();
                
                InventoryItem inventoryItem = InventoryManager.getSingleItem(orderItem.getProductId());
                item.itemName = inventoryItem.getProductName();

                item.itemShortDescription = inventoryItem.getShortDescription();

                userOrderItems.Add(item);
            }

            return userOrderItems;
        }

        public Order getOrder(int orderId)
        {
            OrderDAO dataLayer = new OrderDAO();
            Order singleOrder = dataLayer.getSingleOrder(orderId);
            this.order = singleOrder;
            return singleOrder;
        }

        public double getOrderTotal()
        {
            double total = 0;
            foreach (OrderItem item in order.getOrderItems())
            {
                total += item.getCount() * item.getSalePrice();
            }
            return total;
        }

        public double getAmountDue()
        {
            double amountDue = 0;
            double orderTotal = getOrderTotal();

            amountDue = orderTotal - order.getPaymentAmount();

            return amountDue;
        }

        public void validateOrder(int orderNumber)
        {
            OrderDAO datalayer = new OrderDAO();
            datalayer.validateOrder(orderNumber);
        }

        public void completeOrder(int orderNumber)
        {
            OrderDAO datalayer = new OrderDAO();
            this.order = getOrder(orderNumber);
            datalayer.completeOrder(orderNumber);
            updateInventory();
            
        }
        private void getInventoryItems(List<OrderItem> orderItems)
        {
            foreach (OrderItem orderItem in orderItems)
            {
                inventoryItems.Add(InventoryManager.getSingleItem(orderItem.getProductId()));
            }
            
        }

        private void removeOnHoldItems(List<OrderItem> orderItems)
        {
            for (int i = 0; i < inventoryItems.Count; i++ )
            {
                inventoryItems[i].removeOnHold(orderItems[i].getCount());
            }
        }

        private void updateInventory()
        {
            getInventoryItems(order.getOrderItems());
            removeOnHoldItems(order.getOrderItems());
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                InventoryManager.updateInventoryItem(inventoryItem);
            }
        }

        public List<OrderId> getAllIncompleteOrders()
        {
            OrderDAO datalayer = new OrderDAO();
            List<OrderId> orderNumbers = datalayer.getAllIncompleteOrders();
            return orderNumbers;
        }

        public List<OrderId> getAllInvalidOrders()
        {
            OrderDAO datalayer = new OrderDAO();
            List<OrderId> orderNumbers = datalayer.getAllInvalidOrders();
            return orderNumbers;
        }
    }
}