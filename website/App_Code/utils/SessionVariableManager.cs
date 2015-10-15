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
        private const String ORDER = "order";
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

        public static void removeItemFromCart(int item)
        {
            List<InventoryItem> items = (List<InventoryItem>)HttpContext.Current.Session[USER_CART];

            for (int i = 0; i < items.Count; i++ )
                if (items[i].getInventoryId() == item)
                {
                    items.RemoveAt(i);
                    
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

        public static void clearCart()
        {
            List<InventoryItem> items = (List<InventoryItem>) HttpContext.Current.Session[USER_CART];
            if (items != null)
            {
                items.Clear();
            }
        }

        public static void setOrderItems(String[] items)
        {
            HttpContext.Current.Session[ORDER] = items;
        }
        public static String[] getOrderItems()
        {
            String[] orderItems = (String[]) HttpContext.Current.Session[ORDER];
            return orderItems;
        }

        public static void removeOrderItems()
        {
            HttpContext.Current.Session[ORDER] = null;
        }

        public static void logOut()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}