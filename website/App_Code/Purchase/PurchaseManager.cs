using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cisseniorproject.dataobjects;

/// <summary>
/// Summary description for PurchaseManager
/// </summary>
namespace cisseniorproject.purchase
{


    public class PurchaseManager
    {
        
        public PurchaseManager()
        {
            
        }

        public static Manufacturer getManufacturer(int id)
        {
            ManufacturerDAO datalayer = new ManufacturerDAO();
            return datalayer.getSingleManufacturer(id);
        }

        public static List<Manufacturer> getAllManufacturers()
        {
            ManufacturerDAO datalayer = new ManufacturerDAO();
            return datalayer.getAllManufacturers();
        }

        public static Boolean addManaufacturer(Manufacturer manufacturer)
        {
            ManufacturerDAO datalayer = new ManufacturerDAO();
            return datalayer.addManufacturer(manufacturer);
        }

        public static Boolean updateManufacturer(Manufacturer manufacturer)
        {
            ManufacturerDAO datalayer = new ManufacturerDAO();
            return datalayer.updateManufacturer(manufacturer);
        }

        public static InventoryPurchaseInfo getSingleInventoryPurchaseItem(int id)
        {
            InventoryPurchaseInfoDAO datalayer = new InventoryPurchaseInfoDAO();
            return datalayer.getSingleInventoryPurchaseInfo(id);
            
        }
        public static List<InventoryPurchaseInfo> getAllInventoryPurchaseItems()
        {
            InventoryPurchaseInfoDAO datalayer = new InventoryPurchaseInfoDAO();
            return datalayer.getAllInventoryPurchaseInfo();
        }

        public static Boolean updateInventoryPurchaseInfo(InventoryPurchaseInfo purchaseInfo)
        {
            InventoryPurchaseInfoDAO datalayer = new InventoryPurchaseInfoDAO();
            return datalayer.updateInventoryPurchaseInfo(purchaseInfo);
        }

        public static Boolean addNewInventoryPurchaseInfo(InventoryPurchaseInfo purchaseInfo)
        {
            ManufacturerDAO datalayer1 = new ManufacturerDAO();
            Manufacturer existingManufacturer = datalayer1.getSingleManufacturer(purchaseInfo.manufacturerId);

            if (existingManufacturer.manufacturerId != null)
            {
                InventoryPurchaseInfoDAO datalayer2 = new InventoryPurchaseInfoDAO();
                return datalayer2.addNewInventoryPurchaseInfo(purchaseInfo);
            }
            else
            {
                return false;
            }
        }
    }
}