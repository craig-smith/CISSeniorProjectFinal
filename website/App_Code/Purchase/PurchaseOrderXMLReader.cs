using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderXMLReader
/// </summary>
namespace cisseniorproject.purchase
{


    public class PurchaseOrderXMLReader
    {
        private string path;
        private string extension;
        public PurchaseOrderXMLReader()
        {
            path = HttpContext.Current.Server.MapPath("~/App_Data/");
            extension = ".xml";
        }

        public List<String> getFileNames()
        {
            List<String> purchaseOrderFiles = new List<String>();

            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*" + extension);

            foreach (FileInfo file in files)
            {                
                String filename = file.Name.Replace(extension, "");
                purchaseOrderFiles.Add(filename);
            }

            return purchaseOrderFiles;

        }

        public String getXmlFile(String filename)
        {
            
            String filePath = (path + filename + extension);
            return filePath;
        }
    }
}