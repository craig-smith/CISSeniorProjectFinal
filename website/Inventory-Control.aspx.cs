using cisseniorproject.dataobjects;
using cisseniorproject.inventory;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_Control : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (QueryStringManager.getItemId() > 0)
            {
                loadInventoryItem(QueryStringManager.getItemId());
                EditInventoryPanel.Visible = true;
            }
            else
            {
                List<InventoryItem> productList = InventoryManager.getAllItems();
                InventoryLinksRepeater.DataSource = productList;
                InventoryLinksRepeater.DataBind();
                InventoryLinksPanel.Visible = true;
            }
        }
    }

    private void loadInventoryItem(int item)
    {
        InventoryItem updateItem = InventoryManager.getSingleItem(item);
        hidInventoryId.Value = updateItem.getInventoryId().ToString();
        txtProductName.Text = updateItem.getProductName();
        txtProductCount.Text = updateItem.getProductCount().ToString();
        txtItemsOnHold.Text = updateItem.getItemsOnHold().ToString();
        txtUnitPrice.Text = updateItem.getUnitPrice().ToString();
        txtSalePrice.Text = updateItem.getSalePrice().ToString();
        txtShortDescription.Text = updateItem.getShortDescription();
        txtLongDescription.Text = updateItem.getLongDescription();
        hidImagePath.Value = updateItem.getImageUrl();
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InventoryItem updateItem = new InventoryItem();
        updateItem.setInventoryId(Convert.ToInt32(hidInventoryId.Value));
        updateItem.setProductName(txtProductName.Text);
        updateItem.setProductCount(Convert.ToInt32(txtProductCount.Text));
        updateItem.setItemsOnHold(Convert.ToInt32(txtItemsOnHold.Text));
        updateItem.setUnitPrice(Convert.ToDouble(txtUnitPrice.Text));
        updateItem.setSalePrice(Convert.ToDouble(txtSalePrice.Text));
        updateItem.setShortDescription(txtShortDescription.Text);
        updateItem.setLongDescription(txtLongDescription.Text);

        if (ImageFileUpload.HasFile)
        {
            if (ImageFileUpload.PostedFile.ContentType == "image/jpeg" || ImageFileUpload.PostedFile.ContentType == "image/png")
            {
                String filename = Path.GetFileName(ImageFileUpload.FileName);
                ImageFileUpload.SaveAs(Server.MapPath("~/Graphics/" + filename));
                updateItem.setImageUrl(ImageFileUpload.FileName);
            }
        }
        else
        {
            updateItem.setImageUrl(hidImagePath.Value);
        }
       bool success = InventoryManager.updateInventoryItem(updateItem);
       if (success)
       {
           lblMsg.Text = "Item Updated Successfuly.";
       }
       else
       {
           lblMsg.Text = "Sorry there was an error. Please try again.";
       }
    }
}