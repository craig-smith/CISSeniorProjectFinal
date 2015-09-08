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
public class Order
{
    private int orderId;   
    private PaymentInformation paymentInformation;
    private List<InventoryItem> orderItems;
    private Boolean validated;
    private Boolean completed;

	public Order()
	{
		
	}

    public Order(int orderId, PaymentInformation paymentInformation, List<InventoryItem> orderItems, Boolean validated, Boolean completed)
    {
        this.orderId = orderId;
        this.paymentInformation = paymentInformation;
        this.orderItems = orderItems;
        this.validated = validated;
        this.completed = completed;
    }

    public int getOrderId(){
        return this.orderId;
    }
    public void setOrderId(int orderId)
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

    public List<InventoryItem> getOrderItems()
    {
        return this.orderItems;
    }
    public void setOrderItems(List<InventoryItem> orderItems)
    {
        this.orderItems = orderItems;
    }

    public int addOrderItem(InventoryItem orderItem)
    {
        orderItems.Add(orderItem);
        return this.getOrderItemsCount();
    }

    public int removeOrderItem(InventoryItem orderItem)
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
}