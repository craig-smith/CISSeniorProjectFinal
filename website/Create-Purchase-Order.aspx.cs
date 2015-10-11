using cisseniorproject.purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Create_Purchase_Order : System.Web.UI.Page
{
    private List<InventoryPurchaseItem> itemsToOrder;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            itemsToOrder = PurchaseManager.getPurchaseOrderItems();

            OrderItems.DataSource = itemsToOrder;
            OrderItems.DataBind();
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();
        

        foreach (RepeaterItem rptItem in OrderItems.Items)
        {
            
            TextBox orderItemTextBox = (TextBox)rptItem.FindControl("txtAmountToOrder");
            Label itemName = (Label)rptItem.FindControl("lblItemName");
            Label itemPrice = (Label)rptItem.FindControl("lblItemCost");
            
            PurchaseOrderItem orderItem = new PurchaseOrderItem();
            orderItem.itemName = itemName.Text;
            orderItem.itemPrice = Double.Parse(itemPrice.Text, NumberStyles.Currency);
            orderItem.orderAmount = Convert.ToInt32(orderItemTextBox.Text);

            Label supplier = (Label)rptItem.FindControl("lblSupplier");

            if (purchaseOrders.Count == 0)
            {
                PurchaseOrder newOrder = new PurchaseOrder();
                
                newOrder.manufacturer.name = supplier.Text;
                newOrder.addItemToOrder(orderItem);

                purchaseOrders.Add(newOrder);
            }
            else
            {
                foreach (PurchaseOrder order in purchaseOrders.ToList())
                {
                    if (order.manufacturer.name == supplier.Text)
                    {
                        order.addItemToOrder(orderItem);
                    }
                    else
                    {
                        PurchaseOrder newOrder = new PurchaseOrder();
                       
                        newOrder.manufacturer.name = supplier.Text;
                        newOrder.addItemToOrder(orderItem);

                        purchaseOrders.Add(newOrder);
                    }
                }
            }

           
            
            
        }

        Boolean success = PurchaseManager.processOrder(purchaseOrders);
        if (success)
        {
            lblMsg.Text = "Purchase orders successfully created.";
        }
        else
        {
            lblMsg.Text = "Sorry, there was an error. Please try again.";
        }
    }
}