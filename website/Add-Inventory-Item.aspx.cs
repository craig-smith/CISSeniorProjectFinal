using cisseniorproject.dataobjects;
using cisseniorproject.inventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.purchase;

public partial class Add_Inventory_Item : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Manufacturer> manufacturers = PurchaseManager.getAllManufacturers();
            ddlManufacturer.DataSource = manufacturers;
            ddlManufacturer.DataTextField = "name";
            ddlManufacturer.DataValueField = "manufacturerId";
            ddlManufacturer.DataBind();
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean success = false;
        if (IsValid)
        {
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.setProductName(txtProductName.Text);
            inventoryItem.setProductCount(Convert.ToInt32(txtProductCount.Text));
            inventoryItem.setItemsOnHold(Convert.ToInt32(txtItemsOnHold.Text));
            inventoryItem.setUnitPrice(Convert.ToDouble(txtUnitPrice.Text));
            inventoryItem.setSalePrice(Convert.ToDouble(txtSalePrice.Text));
            inventoryItem.setShortDescription(txtShortDescription.Text);
            inventoryItem.setLongDescription(txtLongDescription.Text);
            if (ImageFileUpload.PostedFile.ContentType == "image/jpeg" || ImageFileUpload.PostedFile.ContentType == "image/png")
            {
                String filename = Path.GetFileName(ImageFileUpload.FileName);
                ImageFileUpload.SaveAs(Server.MapPath("~/Graphics/" + filename));
                inventoryItem.setImageUrl(ImageFileUpload.FileName);
                success = InventoryManager.insertNewItem(inventoryItem);
            }
            else
            {
                lblMsg.Text = "There is a problem with your image. It must be .jpg or .png. Please try again.";
            }
            if (success)
            {
                InventoryPurchaseInfo purchaseInfo = new InventoryPurchaseInfo();
                InventoryItem item = InventoryManager.getItemByName(txtProductName.Text);
               
                purchaseInfo.inventoryItemId = item.getInventoryId();
                
                purchaseInfo.manufacturerId = Convert.ToInt32(ddlManufacturer.SelectedValue);
                purchaseInfo.minInventory = Convert.ToInt32(txtMinumInventory.Text);

                success = PurchaseManager.addNewInventoryPurchaseInfo(purchaseInfo);
            }
            if (success)
            {
                lblMsg.Text = "Item successfuly added.";
            }
           
        }
    }
    protected void btnAddSupplier_Click(object sender, EventArgs e)
    {
        Manufacturer manufacturer = new Manufacturer();
        manufacturer.name = txtSupplierName.Text;
        manufacturer.address = txtSupplierAddress.Text;

        bool success = PurchaseManager.addManaufacturer(manufacturer);
        if(success)
        {
            lblSupplierMsg.Text = "Supplier added successfully.";
        }
        else
        {
            lblSupplierMsg.Text = "Sorry, there was an error. Please try again.";
        }

        
    }
}