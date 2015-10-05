using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QueryStringManager
/// </summary>
namespace cisseniorproject.utils
{
   

    public class QueryStringManager
    {
        public const String LAST_ITEM = "lastItem";
        public const String VIEW_ITEM = "viewItem";
        public const String ORDER_ID = "OrderId";
        public const String ITEM_ID = "itemId";
        public const int NOT_PRESENT = -1;

        public QueryStringManager()
        {
            
        }

        private static Boolean isNotNull(object queryString)
        {
            if (queryString != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object getQueryString(String variable)
        {
            return HttpContext.Current.Request.QueryString.Get(variable);
        }

        public static int getLastItem()
        {
            if (isNotNull(getQueryString(LAST_ITEM)))
            {
                return Convert.ToInt32(getQueryString(LAST_ITEM));
            }
            else
            {
                return NOT_PRESENT;
            }
        }

        public static int getViewItem()
        {
            if (isNotNull(getQueryString(VIEW_ITEM)))
            {
                return Convert.ToInt32(getQueryString(VIEW_ITEM));
            }
            else
            {
                return NOT_PRESENT;
            }
        }

        public static int getOrderId()
        {
            if (isNotNull(getQueryString(ORDER_ID)))
            {
                return Convert.ToInt32(getQueryString(ORDER_ID));
            }
            else return NOT_PRESENT;
        }

        public static int getItemId()
        {
            if (isNotNull(getQueryString(ITEM_ID)))
            {
                return Convert.ToInt32(getQueryString(ITEM_ID));
            }
            else return NOT_PRESENT;
        }
    }
}