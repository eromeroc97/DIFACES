using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class OrdersProductsDAO
    {
        private static DataTable tabla;
        private static OrdersProductsDAO instance;
        private static string lastChange;
        private OrdersProductsDAO()
        {
            tabla = new DataTable();
        }
        public static OrdersProductsDAO getInstance()
        {
            if (instance == null)
            {
                instance = new OrdersProductsDAO();
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
        public void readOrdersProducts(int order)
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT P.PRODUCT, OP.AMOUNT, OP.PRICESALE " +
                "FROM ERP_ORDERS_PRODUCTS OP, ERP_PRODUCTS P" +
                "WHERE OP.REFORDER=" + order, "ORDERSPRODUCTS");
            tabla = data.Tables["orders"];
        }

        public void insertOrderProduct(int order, int product, int amount, double priceSale)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_ORDERS_PRODUCTS (REFORDER, REFPRODUCT, AMOUNT, PRICESALE) VALUES ("
                + order + ", " + product + ", " + amount + ", " + priceSale + ");";
            search.setData(sql);
            lastChange = "Product " + product + " inserted in the order " + order;
        }

        public void modifyAmountOrderProduct(int order,int product, int amount)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ORDERS_PRODUCTS SET AMOUNT=" + amount + " WHERE REFORDER=" + order + 
                "AND REFPRODUCT=" + product + "; ";
            search.setData(sql);
            lastChange = "Product " + product + " units modified in order " + order;
        }
        public void deleteOrderProduct(int order, int product)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "DELETE FROM ERP_ORDERS_PRODUCTS WHERE REFORDER="+ order + "REFPRODUCT=" + product + "; ";
            search.setData(sql);
            lastChange = "Deleted product " + product + " from the order " + order;
        }
        public double calcTotalOrder(int order)
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT SUM(AMOUNT*PRICESALE)" +
                " FROM ERP_ORDERS_PRODUCTS" +
                " WHERE REFORDER=" + order+ 
                " GROUP BY REFPRODUCT", "ORDERSPRODUCTS");
            tabla = data.Tables["orders"];
            return Convert.ToDouble(tabla.Rows[0][0].ToString());
        }
    }
}
