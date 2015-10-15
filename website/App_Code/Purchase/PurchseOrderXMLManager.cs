using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for PurchseOrderMailer
/// </summary>
namespace cisseniorproject.purchase
{


    public class PurchseOrderXMLManager
    {
        private string path;
        private string address;
        private XmlDocument attachment;
        private string archivePath = HttpContext.Current.Server.MapPath("~/App_Data/Archive/");
        private string filename;
        public PurchseOrderXMLManager(String path, string filename)
        {
            this.path = path;
            getDocument();
            getAddress();
            this.filename = filename + DateTime.Now.ToFileTime() + ".xml";
        }

        public void sendPurchaseOrderToSupplier()
        {
            MailMessage purchaseOrderEmail = new MailMessage();
            purchaseOrderEmail.To.Add(address);
            purchaseOrderEmail.From = new MailAddress("purchaser@williamsengraving.com");
            purchaseOrderEmail.Subject = "Purchase Order From Williams Engraving and Specialty Supplies";
            Attachment attachment = new Attachment(path, MediaTypeNames.Application.Octet);
            purchaseOrderEmail.Attachments.Add(attachment);
            using (SmtpClient smtp = new SmtpClient())
            {
                try
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("william.engravingsupplies@gmail.com", "Pa$$word");
                    smtp.Send(purchaseOrderEmail);
                }
                catch (SmtpException ex)
                {
                    smtp.Dispose();
                }
                finally
                {
                    purchaseOrderEmail.Dispose();
                    smtp.Dispose();
                }
            }
           
            
            
            
        }
        private void getDocument()
        {
            XmlDocument purchaseOrder = new XmlDocument();
            purchaseOrder.Load(path);
            attachment = purchaseOrder;
        }
        private void getAddress()
        {
            XmlNodeList customerAddress = attachment.GetElementsByTagName("address");
            address = customerAddress[0].InnerXml;
        }

        public void moveXMLDocToArchive()
        {
            File.Move(path, archivePath + filename);
            File.Delete(path);
        }

        
    }
}