using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InventoryPurchaseInfo
/// </summary>
public class InventoryPurchaseInfo
{
    public int inventoryItemId { get; set; }
    public int manufacturerId { get; set; }
    public int minInventory { get; set; }
    
	public InventoryPurchaseInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}