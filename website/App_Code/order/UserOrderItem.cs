using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserOrderItem
/// </summary>
public class UserOrderItem
{
    public int itemCount { get; set; }
    public double itemCost { get; set; }
    public String itemShortDescription { get; set; }
    public String itemName { get; set; }
	public UserOrderItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}