using cisseniorproject.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionVariableManager
/// </summary>
namespace cisseniorproject.utils
{


    public class SessionVariableManager
    {
        private const String USERNAME = "username";
        private const String LINKS = "links";
        private const String USER_CART = "user_cart";
        public SessionVariableManager()
        {

        }

        public static String getUsername()
        {
            if (isNotNull(HttpContext.Current.Session[USERNAME]))
            {
                return HttpContext.Current.Session[USERNAME].ToString();
            }
            else return String.Empty;
        }


        public static void setUsername(string username)
        {
            HttpContext.Current.Session[USERNAME] = username;
        }

        public static List<Links> getLinks()
        {
            return (List<Links>)HttpContext.Current.Session[LINKS];
        }

        public static void setLinks(List<Links> links)
        {
            HttpContext.Current.Session[LINKS] = links;
        }

        public static void addItemToCart(InventoryItem item)
        {
            List<InventoryItem> items = (List<InventoryItem>)HttpContext.Current.Session[USER_CART];
            if (items != null)
            {
                items.Add(item);
                HttpContext.Current.Session[USER_CART] = items;
            }
            else
            {
                items = new List<InventoryItem>();
                items.Add(item);
                HttpContext.Current.Session[USER_CART] = items;
            }
           
        }

        public static List<InventoryItem> getUserCart()
        {
            return (List<InventoryItem>)HttpContext.Current.Session[USER_CART];
        }

        public static void removeItemFromCart(InventoryItem item)
        {
            List<InventoryItem> items = (List<InventoryItem>)HttpContext.Current.Session[USER_CART];
            foreach (InventoryItem i in items)
            {
                if (i.getProductName() == item.getProductName())
                {
                    items.Remove(i);
                }
            }

           
        }

        private static Boolean isNotNull(object sessionVarialbe)
        {
            if (sessionVarialbe != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}