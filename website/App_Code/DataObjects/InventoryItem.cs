using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryItem 
/// 
/// Data Object to hold a single Inventory Item
/// 
/// Written by Craig Smith 9/8/15
/// 
/// </summary>
namespace cisseniorproject.dataobjects
{

    public class InventoryItem
    {
        private int inventoryId;
        public String productName { get; set; }
        public int productCount { get; set; }
        private int itemsOnHold;
        public Double unitPrice { get; set; }
        public Double salePrice { get; set; }
        public String shortDescription { get; set; }
        private String longDescription;
        private String imageUrl;

        public InventoryItem()
        {

        }

        public InventoryItem(int inventoryId, String productName, int productCount,
            int itemsOnHold, Double unitPrice, Double salePrice, String shortDescription, String longDescription, String imageUrl)
        {
            this.inventoryId = inventoryId;
            this.productName = productName;
            this.productCount = productCount;
            this.itemsOnHold = itemsOnHold;
            this.unitPrice = unitPrice;
            this.salePrice = salePrice;
            this.shortDescription = shortDescription;
            this.longDescription = longDescription;
            this.imageUrl = imageUrl;
        }

        public int getInventoryId()
        {
            return this.inventoryId;
        }
        public void setInventoryId(int inventoryId)
        {
            this.inventoryId = inventoryId;
        }

        public String getProductName()
        {
            return this.productName;
        }
        public void setProductName(String productName)
        {
            this.productName = productName;
        }

        public int getProductCount()
        {
            return this.productCount;
        }
        public void setProductCount(int productCount)
        {
            this.productCount = productCount;
        }

        public int getItemsOnHold()
        {
            return this.itemsOnHold;
        }
        public void setItemsOnHold(int itemsOnHold)
        {
            this.itemsOnHold = itemsOnHold;
        }

        public Double getUnitPrice()
        {
            return this.unitPrice;
        }
        public void setUnitPrice(Double unitPrice)
        {
            this.unitPrice = unitPrice;
        }

        public Double getSalePrice()
        {
            return this.salePrice;
        }
        public void setSalePrice(Double salePrice)
        {
            this.salePrice = salePrice;
        }

        public String getShortDescription()
        {
            return this.shortDescription;
        }
        public void setShortDescription(String shortDescription)
        {
            this.shortDescription = shortDescription;
        }

        public String getLongDescription()
        {
            return this.longDescription;
        }
        public void setLongDescription(String longDescription)
        {
            this.longDescription = longDescription;
        }

        public String getImageUrl()
        {
            return this.imageUrl;
        }
        public void setImageUrl(String imageUrl)
        {
            this.imageUrl = imageUrl;
        }


        internal void orderItem(int count)
        {
            productCount -= count;
            itemsOnHold += count;
        }
    }
}