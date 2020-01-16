using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class ProductsDAO
    {
        private static DataTable tabla;
        private static ProductsDAO instance;
        private static string lastChange;
        private ProductsDAO()
        {
            tabla = new DataTable();
        }
        public static ProductsDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ProductsDAO();
            }
            return instance;
        }
        public DataTable getTable()
        {
            return tabla;
        }
        public string getLastChange()
        {
            return lastChange;
        }

        public void readProducts()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT NAME, MEASURE, PRICE, BRAND, MODEL, RAM, ROM, SCREEN, PROCESSOR" +
                " FROM ERP_PRODUCTS" +
                " WHERE DELETED=0", "PRODUCTS");
            tabla = data.Tables["PRODUCTS"];
        }
        public void readDeletedProducts()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT NAME, MEASURE, PRICE, BRAND, MODEL, RAM, ROM, SCREEN, PROCESSOR" +
                " FROM ERP_PRODUCTS" +
                " WHERE DELETED=1", "PRODUCTS");
            tabla = data.Tables["PRODUCTS"];
        }
        public void insertProduct(string name, string measure, double price, string brand, string model, int ram, int rom, 
            double screen, string processor)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_PRODUCTS (NAME, MEASURE, PRICE, BRAND, MODEL, RAM, ROM, SCREEN, PROCESSOR) VALUES ("
                + name + ", " + measure + ", " + price + ", " + brand + ", " + model + ", " + ram + ", " + rom + ", " + screen
                + processor + ");";
            search.setData(sql);
            lastChange = "Product " + Convert.ToInt32(search.DLookUp("IDPRODUCT", " (select * from ERP_PRODUCTS order by " +
                "IDPRODUCT desc)", "rownum = 1")) + " inserted";
        }

        public void modifyProduct(int id, string name, string measure, double price, string brand, string model, int ram, int rom,
            double screen, string processor)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PRODUCTS SET NAME=" + name + " MEASURE = " + measure + " PRICE=" + price + "BRAND=" 
                + brand + "MODEL= " + model + " RAM=" + ram + "ROM=" + rom + "SCREEN=" + screen + "PROCESSOR=" + processor
                + " WHERE IDPRODUCT=" + id + "; ";
            search.setData(sql);
            lastChange = "Product " + id + " modified";
        }
        public void deleteProduct(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PRODUCTS SET DELETED = 1 WHERE IDPRODUCT=" + id + "; ";
            search.setData(sql);
            lastChange = "Product " + id + " deleted";
        }
        public void undoDeleteProduct(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PRODUCTS SET DELETED = 0 WHERE IDPRODUCT=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of product " + id;
        }
    }
}
