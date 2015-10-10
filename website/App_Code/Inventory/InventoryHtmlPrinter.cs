using cisseniorproject.dataobjects;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for InventoryHtmlPrinter
/// </summary>
namespace cisseniorproject.inventory
{
    

    public class InventoryHtmlPrinter
    {
        private InventoryItem item;
        private StringBuilder htmlBuilder;

        public InventoryHtmlPrinter(InventoryItem item)
        {
            this.item = item;
            htmlBuilder = new StringBuilder();
        }

        public string getMultiItemHtml()
        {
            
            htmlBuilder.Append(getBeginingMultiItemDiv());
            htmlBuilder.Append(getItemNameHtml());
            htmlBuilder.Append(getImageHtml());
            htmlBuilder.Append(getshorItemDescriptionHtml());
            htmlBuilder.Append(getClearBothHtml());
            htmlBuilder.Append(getPriceDiv());
            htmlBuilder.Append(getLinkHtml());
            htmlBuilder.Append(getClearBothHtml());
            htmlBuilder.Append(getAddToCartLink());
            htmlBuilder.Append(getClearBothHtml());
            htmlBuilder.Append(getEndingHtml());

            return htmlBuilder.ToString();
        }

        public string getViewItemHtml(InventoryItem item)
        {
            htmlBuilder.Append(getBeginingSingleItemDiv());
            htmlBuilder.Append(getItemNameHtml());
            htmlBuilder.Append(getImageHtml());
            htmlBuilder.Append(getLongItemDescriptionHtml());
            htmlBuilder.Append(getPriceDiv());
            htmlBuilder.Append(getAddToCartLink());
            htmlBuilder.Append(getEndingHtml());

            return htmlBuilder.ToString();
        }

        public string getCartItemHtml()
        {
            htmlBuilder.Append(getBeginningCartItemDiv());
            htmlBuilder.Append(getItemNameHtml());
            htmlBuilder.Append(getImageHtml());
            htmlBuilder.Append(getshorItemDescriptionHtml());
            htmlBuilder.Append(getClearBothHtml());            
            htmlBuilder.Append(getPriceDiv());
           
            if (item.getProductCount() > 1)
            {
                htmlBuilder.Append(getCheckBoxDiv());
            }
            else
            {
                htmlBuilder.Append(getOutOfStockDiv());
            }
            
            htmlBuilder.Append(getEndingHtml());

            return htmlBuilder.ToString();
        }

        private String getOutOfStockDiv()
        {
            return "<div class='out-of-stock'><p>Sorry, this item is currently out of Stock.</p></div>";
        }

        private String getCheckBoxDiv()
        {
            
                String html = "<div class='cart-item-checkbox'><label><input type='checkbox' id='" + item.getInventoryId() + "' name='" + item.getInventoryId() +"' runat='server'/> Select </label>";
                html += getLinkHtml() + "</div>";
            return html;
        }

        private String getBeginningCartItemDiv()
        {
            return "<div class='cart-item'>";
        }

        private String getAddToCartLink()
        {
            String html = "<div class='cart-button'><input type='button' value='Add To Cart' onclick='addToCart(" + item.getInventoryId() + ")'></div>";
            return html;
        }
        private String getBeginingSingleItemDiv()
        {
            String html = "<div class='inventory-view-item'>";
            return html;
        }
        private String getBeginingMultiItemDiv()
        {
            String html = "<div class='inventory-item'>";
            return html;
        }

        private String getLinkHtml()
        {
            return "<a href='products.aspx?" + QueryStringManager.VIEW_ITEM + "=" + item.getInventoryId() + "'>view item </a>";
        }
        private String getImageHtml()
        {
            String html = "<div class='inventory-image'><img src='Graphics/" + item.getImageUrl() + "'></img></div>";
            return html;
        }

        private String getshorItemDescriptionHtml()
        {
            String html = "<div class='inventory-short-description'> <p>" + item.getShortDescription() + "</p></div>";
            return html;
        }

        private String getLongItemDescriptionHtml()
        {
            String html = "<div class='inventory-long-description'><p>" + item.getLongDescription() + "</p></div>";
            return html;
        }
        private String getPriceDiv()
        {
            String html = "<div class='item-price'><p>" + string.Format("{0:C}", item.getSalePrice()) + "</p></div>";
            return html;
        }
        private String getEndingHtml()
        {
            return "</div>";
        }
        private String getItemNameHtml()
        {
            String html = "<div class='product-name'> <h3>" + item.getProductName() + "</h3></div>";
            return html;
        }
        private String getClearBothHtml()
        {
            return "<div class='clear'></div>";
        }

        
    }
}