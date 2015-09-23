using cisseniorproject.dataobjects;
using cisseniorproject.inventory;
using cisseniorproject.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for AddToCart
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AddToCart : System.Web.Services.WebService {

    public AddToCart () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession=true)]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(EnableSession=true)]
    public Boolean addItem(int itemId)
    {
        try
        {
            InventoryItem item = InventoryManager.getSingleItem(itemId);
            SessionVariableManager.addItemToCart(item);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

        
    }
    
}
