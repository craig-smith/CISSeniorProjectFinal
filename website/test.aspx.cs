using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = null;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["CISSeniorProjectDB"].ConnectionString; //connection string for db

        OleDbConnection sqlConn = new OleDbConnection(database); //db connection

        sqlConn.Open();

        String select = "SELECT [USERS].username FROM [USERS] WHERE [user_id] = 1";

        OleDbCommand cmd = new OleDbCommand(select, sqlConn);

        //add parameters to command
        
        cmd.Prepare();

        //create data reader
        OleDbDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            username = dr["username"].ToString();
            
        }
        //close all resources and return list to calling method
        dr.Close();
        sqlConn.Close();

        testLable.Text = username;
    }
}