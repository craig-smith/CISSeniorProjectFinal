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

            XmlSerializer xmlWritter = new XmlSerializer(typeof(PurchaseOrder));
            foreach (PurchaseOrder order in orders)
            {
                using (TextWriter textWriter = new StreamWriter(path + "/" + order.manufacturer.name + ".xml"))
                {
                    try
                    {
                        xmlWritter.Serialize(textWriter, order);
                    }


                    catch (IOException ex)
                    {
                        return false;
                    }
                    finally
                    {
                        textWriter.Close();
                    }
                }                
            }
            return true;
        }
    }
            
            
        
    
}