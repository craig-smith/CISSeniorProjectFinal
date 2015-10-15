using cisseniorproject.dataobjects;
using cisseniorproject.order;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_Processing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (QueryStringManager.getOrderId() != QueryStringManager.NOT_PRESENT)
        {
            int viewOrderId = QueryStringManager.getOrderId();
            singleOrderPanel.Visible = true;

            loadSingleOrder(viewOrderId);
        }
        else
        {
            getInValidatedOrders();
            getIncompleteOrders();
            orderLinksPanel.Visible = true;
        }
    }

    private void getIncompleteOrders()
    {
        OrderManager businessLayer = new OrderManager();
        List<OrderId> incompleteOrders = businessLayer.getAllIncompleteOrders();
        OrderValidationLinksRepeater.DataSource = incompleteOrders;
        OrderValidationLinksRepeater.DataBind();
    }

    private void getInValidatedOrders()
    {
        OrderManager businessLayer = new OrderManager();
        List<OrderId> invalidOrders = businessLayer.getAllInvalidOrders();
        OrderCompletionLinksRepeater.DataSource = invalidOrders;
        OrderCompletionLinksRepeater.DataBind();
    }

    private void loadSingleOrder(int viewOrderId)
    {
        OrderManager businessLayer = new OrderManager();
        cisseniorproject.dataobjects.Order order = businessLayer.getOrder(viewOrderId);

        lblUserId.Text = order.getUserId().ToString();
        lblUsername.Text = order.getPaymentInformation().getUser().getUsername();
        lblFirstName.Text = order.getPaymentInformation().getUser().getFirstName();
        lblLastName.Text = order.getPaymentInformation().getUser().getLastName();
        lblAddress.Text = order.getPaymentInformation().getUser().getAddress();
        lblCity.Text = order.getPaymentInformation().getUser().getCity();
        lblState.Text = order.getPaymentInformation().getUser().getState();
        lblZipCode.Text = order.getPaymentInformation().getUser().getZipCode();
        lblAccountCreationDate.Text = order.getPaymentInformation().getUser().getAccountCreationDate().ToShortDateString();
        lblEmail.Text = order.getPaymentInformation().getUser().getEamil();

        lblCreditCardType.Text = order.getPaymentInformation().getCreditCardType();
        lblCreditCardNumber.Text = order.getPaymentInformation().getCreditCardNumber();
        lblCardCity.Text = order.getPaymentInformation().getCity();
        lblCardState.Text = order.getPaymentInformation().getState();
        lblCardExpDate.Text = order.getPaymentInformation().getCardExpDate().ToShortDateString();
        lblCardSecurityCode.Text = order.getPaymentInformation().getSecurityCode();

        lblOrderId.Text = order.getOrderId().ToString();
        lblOrderUserId.Text = order.getUserId().ToString();
        cbIsValidated.Checked = order.isOrderValidated();
        cbIsCompleted.Checked = order.isOrderCompleted();
        cbIsCollectOnDelivery.Checked = order.getCollectOnDelivery();
        lblPaymentAmount.Text = String.Format("{0:C}",order.getPaymentAmount());
        lblTotalOrderAmount.Text = String.Format("{0:C}", businessLayer.getOrderTotal());
        lblAmountDue.Text = String.Format("{0:C}", businessLayer.getAmountDue());

        List<UserOrderItem> orderItems = businessLayer.getOrderItems(order);

        rptOrderItems.DataSource = orderItems;
        rptOrderItems.DataBind();

    }
    protected void btnValidateOrder_Click(object sender, EventArgs e)
    {
        OrderManager businessLayer = new OrderManager();
        businessLayer.validateOrder(Convert.ToInt32(lblOrderId.Text));
        loadSingleOrder(Convert.ToInt32(lblOrderId.Text));
        
    }
    protected void btnCompleteOrder_Click(object sender, EventArgs e)
    {
        OrderManager businessLayer = new OrderManager();
        businessLayer.completeOrder(Convert.ToInt32(lblOrderId.Text));
        loadSingleOrder(Convert.ToInt32(lblOrderId.Text));
    }
}