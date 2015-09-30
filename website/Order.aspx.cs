using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.inventory;
using cisseniorproject.dataobjects;
using cisseniorproject.utils;
using System.Web.UI.HtmlControls;
using cisseniorproject.payment;
using cisseniorproject.order;
using cisseniorproject.security;

public partial class Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String[] items = SessionVariableManager.getOrderItems();
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (String item in items)
            {
                if (item != "")
                {
                    inventoryItems.Add(InventoryManager.getSingleItem(Convert.ToInt32(item)));
                }

                rptOrderItem.DataSource = inventoryItems;
                rptOrderItem.DataBind();
            }

            List<PaymentInformation> paymentInformation = PaymentManager.getUserCreditCards(Security.getUsername());
            if (paymentInformation != null && paymentInformation.Count >= 1)
            {
                ddlPaymentMethod.DataTextField = "creditCardNumber";
                ddlPaymentMethod.DataValueField = "paymentInformationId";
                ddlPaymentMethod.DataSource = paymentInformation;
                ddlPaymentMethod.DataBind();
            }
            else
            {
                lblMessage.Text = "Sorry, We are unable to process your order at this time. You are either not signed in or you have not added any payment methods.";
                btnCalculateOrder.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }
    }       
           
    protected void btnCalculateOrder_Click(object sender, EventArgs e)
    {
        double totalCost = 0;
        String[] items = SessionVariableManager.getOrderItems();
        List<InventoryItem> inventoryItems = new List<InventoryItem>();
        List<Double> orderedAmount = new List<Double>();

        foreach (String item in items)
        {
            if (item != "")
            {
                inventoryItems.Add(InventoryManager.getSingleItem(Convert.ToInt32(item)));
            }
        }

        foreach (RepeaterItem rptItem in rptOrderItem.Items)
        {
            TextBox orderItemTextBox = (TextBox)rptItem.FindControl("txtCount");
            String amountOrdered = orderItemTextBox.Text;
            orderedAmount.Add(Convert.ToDouble(amountOrdered));
        }
        for (int i = 0; i < inventoryItems.Count; i++)
        {

            OrderManager orderManager = new OrderManager();
            totalCost = orderManager.getTotalOrderCost(inventoryItems, orderedAmount);
        }

        lblMessage.Text = "Your total is: " + string.Format("{0:C}", totalCost);

        if (cbCollectOnDelivery.Checked)
        {
            txtPaymentAmount.Text = (totalCost * .1).ToString();
            txtPaymentAmount.Enabled = true;
            paymentAmountValidator.MinimumValue = (totalCost * .1).ToString();
            paymentAmountValidator.MaximumValue = totalCost.ToString();
        }
        else
        {
            txtPaymentAmount.Text = totalCost.ToString();
            txtPaymentAmount.Enabled = false;
        }
        TotalCostHiddenField.Value = totalCost.ToString();
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String[] items = SessionVariableManager.getOrderItems();
        List<InventoryItem> orderInventory = new List<InventoryItem>();
        List<TextBox> textboxes = new List<TextBox>();

        OrderManager orderManager = new OrderManager();

        foreach (String item in items)
        {
            if (item != "")
            {
                orderInventory.Add(InventoryManager.getSingleItem(Convert.ToInt32(item)));
            }
        }
        foreach (RepeaterItem rptItem in rptOrderItem.Items)
        {
            textboxes.Add((TextBox)rptItem.FindControl("txtCount"));
        }

        if (orderInventory.Count == textboxes.Count)
        {
            
            for (int i = 0; i < orderInventory.Count; i++)
            {
                orderManager.addItemToOrder(orderInventory[i], Convert.ToInt32(textboxes[i].Text));
            }

        }
        PaymentInformation userCreditCard = PaymentManager.getUserCreditCard(Convert.ToInt32(ddlPaymentMethod.SelectedValue));
        orderManager.addPaymentInfo(userCreditCard);
        orderManager.setIsCollectOnDelivery(cbCollectOnDelivery.Checked);
        orderManager.setPaymentAmount(Convert.ToDouble(txtPaymentAmount.Text));

        int orderNumber = orderManager.submitOrder();
        if (orderNumber > 0)
        {
            lblMessage.Text = "Thank you for your order. Your order number is " + orderNumber + ". Keep this number for reference.";
            btnCalculateOrder.Enabled = false;
            btnSubmit.Enabled = false;
            paymentAmountValidator.Enabled = false;
            paymentAmountRequiredValidator.Enabled = false;

            foreach (InventoryItem item in orderInventory)
            {
                SessionVariableManager.removeItemFromCart(item.getInventoryId());
                
            }
        }
        else
        {
            lblMessage.Text = "Sorry, there was an error with your order. Please review your selection and try again.";
        }
        
    }
}