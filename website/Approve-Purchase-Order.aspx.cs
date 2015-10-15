using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cisseniorproject.purchase;
using System.Data;
using System.Xml;

public partial class Approve_Purchase_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDdlPurchasOrder();

            getXmlData(ddlPurchaseOrder.SelectedValue);            
            
        }
    }

    private void loadDdlPurchasOrder()
    {
        PurchaseOrderXMLReader xmlReader = new PurchaseOrderXMLReader();
        List<String> purchaseOrders = xmlReader.getFileNames();

        ddlPurchaseOrder.DataSource = purchaseOrders;
        ddlPurchaseOrder.DataBind();
    }

    private void getXmlData(String xmlFile)
    {
        PurchaseOrderXMLReader xmlReader = new PurchaseOrderXMLReader();
        XmlDataSource1.DataFile = xmlReader.getXmlFile(xmlFile);
        XmlDocument doc = XmlDataSource1.GetXmlDocument();
        XmlNodeList manufacturerName = doc.GetElementsByTagName("name");
        lblCompanyName.Text = manufacturerName[0].InnerXml;
        XmlDataSource1.XPath = "/PurchaseOrder/items/PurchaseOrderItem";
        XmlDataSource1.DataBind();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        PurchaseOrderXMLReader xmlReader = new PurchaseOrderXMLReader();
        String purchaseOrder = xmlReader.getXmlFile(ddlPurchaseOrder.SelectedValue);
        PurchseOrderXMLManager xmlManager = new PurchseOrderXMLManager(purchaseOrder, ddlPurchaseOrder.SelectedValue);
        xmlManager.sendPurchaseOrderToSupplier();
        xmlManager.moveXMLDocToArchive();
        loadDdlPurchasOrder();
        getXmlData(ddlPurchaseOrder.SelectedValue);
        lblMsg.Text = "Message sent and purchase order moved to archive directory.";
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        String purchaseOrder = ddlPurchaseOrder.SelectedValue;
        getXmlData(purchaseOrder);
    }
}