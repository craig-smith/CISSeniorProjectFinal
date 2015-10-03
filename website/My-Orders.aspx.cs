using cisseniorproject.order;
using cisseniorproject.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class My_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String userName = Security.getUsername();
        OrderManager orderManager = new OrderManager();

        List<UserOrder> userOrders = orderManager.getUserOrders(userName);
        ExistingOrdersHeaderRepeater.DataSource = userOrders;
        ExistingOrdersHeaderRepeater.DataBind();

       
        for (int i = 0; i < userOrders.Count; i++)
        {
            try
            {
                Repeater innerRepeater = (Repeater)ExistingOrdersHeaderRepeater.Items[i].FindControl("ExistingOrderItemRepeater");
                innerRepeater.DataSource = userOrders[i].orderItems;
                innerRepeater.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}