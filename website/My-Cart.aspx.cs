using cisseniorproject.dataobjects;
using cisseniorproject.inventory;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class My_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadCartItems();
    }

    private void loadCartItems()
    {
        
        List<InventoryItem> items = SessionVariableManager.getUserCart();
        if (items != null)
        {
            printItemsToPlaceHolder(items);
        }
        else
        {

        }
       
    }
    private void printItemsToPlaceHolder(List<InventoryItem> items)
    {
        
        foreach (InventoryItem item in items)
        {
            InventoryItem i = InventoryManager.getSingleItem(item.getInventoryId()); //price could have changed since the last time user viewed this item      
            InventoryHtmlPrinter printer = new InventoryHtmlPrinter(i);
            String html = printer.getCartItemHtml();

            LiteralControl control = new LiteralControl(html);
            cartItemsPlaceholder.Controls.Add(control);
        }
    }
    protected void btnOrderNow_Click(object sender, EventArgs e)
    {
        String orderedItems = checkBoxValues.Value;
        char[] deliminator = { ',' };
        String[] items = orderedItems.Split(deliminator);
        SessionVariableManager.setOrderItems(items);
        Server.Transfer("~/Order.aspx");
    }

    
    protected void btnRemoveItend_Click(object sender, EventArgs e)
    {
       

        
        String orderedItems = checkBoxValues.Value;
        char[] deliminator = { ',' };
        String[] items = orderedItems.Split(deliminator);

        foreach (String item in items)
        {
            if (item != "")
            {
                SessionVariableManager.removeItemFromCart(Convert.ToInt32(item));
            }

            Server.Transfer("/My-Cart.aspx");
        }
    }
}