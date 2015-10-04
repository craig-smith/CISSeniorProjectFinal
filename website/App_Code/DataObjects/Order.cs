using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// 
/// Data Object used to hold information about a customer order
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class Order
    {
        public int orderId { get; set; }
        private int userId;
        private PaymentInformation paymentInformation;
        private List<OrderItem> orderItems;
        private Boolean validated;
        private Boolean completed;
        private double paymentAmount;
        private Boolean collectOnDelivery;

        public Order()
        {

        }

        public Order(int orderId, int userId, PaymentInformation paymentInformation, List<OrderItem> orderItems, Boolean validated, Boolean completed, double paymentAmount, Boolean collectOnDelivery)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.paymentInformation = paymentInformation;
            this.orderItems = orderItems;
            this.validated = validated;
            this.completed = completed;
            this.paymentAmount = paymentAmount;
            this.collectOnDelivery = collectOnDelivery;
        }

        public int getOrderId()
        {
            return this.orderId;
        }
        public void setOrderId(int orderId)
        {
            this.orderId = orderId;
            foreach (OrderItem item in orderItems)
            {
                item.setOrderId(orderId);
            }
        }
        public void setOrderIdForOrderOnly(int orderId)
        {
            this.orderId = orderId;
        }

        public PaymentInformation getPaymentInformation()
        {
            return this.paymentInformation;
        }
        public void setPaymentInformation(PaymentInformation paymentInformation)
        {
            this.paymentInformation = paymentInformation;
        }

        public List<OrderItem> getOrderItems()
        {
            return this.orderItems;
        }
        public void setOrderItems(List<OrderItem> orderItems)
        {
            this.orderItems = orderItems;
        }

        public int addOrderItem(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
            return this.getOrderItemsCount();
        }

        public int removeOrderItem(OrderItem orderItem)
        {
            orderItems.Remove(orderItem);
            return this.getOrderItemsCount();
        }
        public int getOrderItemsCount()
        {
            return orderItems.Count;
        }

        public Boolean isOrderValidated()
        {
            return this.validated;
        }
        public void setValidated(Boolean validated)
        {
            this.validated = validated;
        }

        public Boolean isOrderCompleted()
        {
            return completed;
        }
        public void setCompleted(Boolean completed)
        {
            this.completed = completed;
        }

        public double getPaymentAmount()
        {
            return this.paymentAmount;
        }
        public void setPaymentAmount(double paymentAmount)
        {
            this.paymentAmount = paymentAmount;
        }
        public Boolean getCollectOnDelivery()
        {
            return this.collectOnDelivery;
        }
        public void setIsCollctOnDelivery(Boolean collectOnDelivery)
        {
            this.collectOnDelivery = collectOnDelivery;
        }
        public void setUserId(int userId)
        {
            this.userId = userId;
        }
        public int getUserId()
        {
            return this.userId;
        }
    }
}