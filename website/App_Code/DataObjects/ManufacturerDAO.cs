using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManufacturerDAO
/// </summary>
namespace cisseniorproject.dataobjects
{


    public class ManufacturerDAO
    {
        private string database;
        public ManufacturerDAO()
        {
            database = DatabaseConnectionManager.getDatabaseConnectionString();
        }

        public Manufacturer getSingleManufacturer(int id)
        {
            Manufacturer manufacturer = new Manufacturer();

            using(OleDbConnection sqlconn = new OleDbConnection(database)){

                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [MANUFACTURER] WHERE [manufacturer_id] = @manufacturerId";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("manufacturerId", OleDbType.Integer).Value = id;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        manufacturer.manufacturerId = (int)reader["manufacturer_id"];
                        manufacturer.name = reader["manufacturer_name"].ToString();
                        manufacturer.address = reader["address"].ToString();
                    }
                    return manufacturer;
                }
                catch (OleDbException ex)
                {
                    return manufacturer;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        public List<Manufacturer> getAllManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();
                    String select = "SELECT [manufacturer_id] FROM [MANUFACTURER]";

                    cmd.CommandText = select;
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Manufacturer manufacturer = getSingleManufacturer((int)reader["manufacturer_id"]);
                        manufacturers.Add(manufacturer);
                    }
                    return manufacturers;
                }
                catch (OleDbException ex)
                {
                    return manufacturers;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        public Boolean addManufacturer(Manufacturer manufacturer)
        {
            Boolean success = false;
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String insert = "INSERT INTO [MANUFACTURER] ([manufacturer_name], [address]) VALUES " +
                        "(@manufacturerName, @address)";
                    cmd.CommandText = insert;
                    cmd.Parameters.Add("manufacturerName", OleDbType.VarChar, 255).Value = manufacturer.name;
                    cmd.Parameters.Add("address", OleDbType.VarChar, 255).Value = manufacturer.address;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        success = true;
                    }
                    return success;
                
                }
                catch (OleDbException ex)
                {

                    return success;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        public Boolean updateManufacturer(Manufacturer manufacturer)
        {
            bool success = false;
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String update = "UPDATE [MANUFACTURER] SET [manufacturer_name] = @manufacturerName, [address] = @address WHERE [manufacturer_id] = @manufacturerId";
                    cmd.CommandText = update;
                    cmd.Parameters.Add("manufacturerName", OleDbType.VarChar, 255).Value = manufacturer.name;
                    cmd.Parameters.Add("address", OleDbType.VarChar, 255).Value = manufacturer.address;
                    cmd.Parameters.Add("manufacturerId", OleDbType.Integer).Value = manufacturer.manufacturerId;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        success = true;
                    }
                    return success;
                }
                catch (OleDbException ex)
                {
                    return success;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }

        internal Manufacturer getSingleManufacturer(string name)
        {
            Manufacturer manufacturer = new Manufacturer();
            using (OleDbConnection sqlconn = new OleDbConnection(database))
            {
                try
                {
                    sqlconn.Open();
                    OleDbCommand cmd = sqlconn.CreateCommand();

                    String select = "SELECT * FROM [MANUFACTURER] WHERE [manufacturer_name] = @manufacturerName";
                    cmd.CommandText = select;
                    cmd.Parameters.Add("manufacturerName", OleDbType.VarChar, 255).Value = name;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        manufacturer.manufacturerId = (int)reader["manufacturer_id"];
                        manufacturer.name = reader["manufacturer_name"].ToString();
                        manufacturer.address = reader["address"].ToString();
                    }
                    return manufacturer;

                }
                catch (OleDbException ex)
                {
                    return manufacturer;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
    
}