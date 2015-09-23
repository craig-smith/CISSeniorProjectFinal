using cisseniorproject.dataobjects;
using cisseniorproject.inventory;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int lastItemNumber = QueryStringManager.getLastItem();
        int viewItem = QueryStringManager.getViewItem();
        if(lastItemNumber != QueryStringManager.NOT_PRESENT)
        {
            List<InventoryItem> items = InventoryManager.getNext10Products(lastItemNumber);
            printAllItems(items);
        }
        else if(viewItem != QueryStringManager.NOT_PRESENT)
        {
            InventoryItem item = InventoryManager.getSingleItem(viewItem);
            printViewItem(item);
        }
    }

    private void printAllItems(List<InventoryItem> items)
    {
        foreach(InventoryItem item in items)
        {
            InventoryHtmlPrinter printer = new InventoryHtmlPrinter(item);
            String itemHtml = printer.getMultiItemHtml();

            LiteralControl control = new LiteralControl(itemHtml);
            productsPlaceHolder.Controls.Add(control);

        }
      
    }

    private void printViewItem(InventoryItem item)
    {
        InventoryHtmlPrinter printer = new InventoryHtmlPrinter(item);
        String itemHtml = printer.getViewItemHtml(item);

        LiteralControl control = new LiteralControl(itemHtml);
        productsPlaceHolder.Controls.Add(control);
    }

   

   
}