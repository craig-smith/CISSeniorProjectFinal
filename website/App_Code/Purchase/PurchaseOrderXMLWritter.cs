using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for PurchaseOrderXMLWritter
/// </summary>
namespace cisseniorproject.purchase
{


    public class PurchaseOrderXMLWritter
    {
        private string path;
        public PurchaseOrderXMLWritter()
        {
            path = HttpContext.Current.Server.MapPath("~/App_Data");
        }

        public Boolean writePurchaseOrders(List<PurchaseOrder> orders)
        {
            try
            {
                XmlSerializer xmlWritter = new XmlSerializer(typeof(PurchaseOrder));
                foreach (PurchaseOrder order in orders)
                {
                    TextWriter textWriter = new StreamWriter(path + "/" + order.manufacturer.name + ".xml");
                    xmlWritter.Serialize(textWriter, order);
                }
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
            
            
            
        }
    }
}