using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class OrdersDAO
    {
        private static DataTable tabla;
        private static OrdersDAO instance;
        private static string lastChange;
        private OrdersDAO()
        {
            tabla = new DataTable();
        }
        public static OrdersDAO getInstance()
        {
            if (instance == null)
            {
                instance = new OrdersDAO();
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
        public void readOrders()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT O.IDORDER, C.NIF, U.NAME, O.DATETIME, P.PAYMENTMETHOD, O.TOTAL, O.PREPAID, " +
                "FROM ERP_ORDERS O, ERP_CUSTOMERS C, ERP_USERS U, ERP_PAYMENTMETHODS P " +
                "WHERE O.REFCUSTOMERS=C.IDCUSTOMER AND O.REFUSER=U.IDUSER AND O.REFPAYMENTMETHOD=P.IDPAYMENTMETHOD AND" +
                "O.DELETED=FALSE", "ORDERS");
            tabla = data.Tables["orders"];
        }
        public void readDeletedOrders()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT O.IDORDER, C.NIF, U.NAME, O.DATETIME, P.PAYMENTMETHOD, O.TOTAL, O.PREPAID, " +
                "FROM ERP_ORDERS O, ERP_CUSTOMERS C, ERP_USERS U, ERP_PAYMENTMETHODS P " +
                "WHERE O.REFCUSTOMERS=C.IDCUSTOMER AND O.REFUSER=U.IDUSER AND O.REFPAYMENTMETHOD=P.IDPAYMENTMETHOD AND" +
                "O.DELETED=TRUE", "ORDERS");
            tabla = data.Tables["orders"];
        }
        public void insertOrder(int customer, int user, int paymentMethod, double total, double prepaid)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_ORDERS (REFCUSTOMER, REFUSER, SYSDATE, REFPAYMENTMETHOD, TOTAL, PREPAID) VALUES ("
                + customer + ", " + user + ", " + paymentMethod + ", " + total + ", " + prepaid + ");";
            search.setData(sql);
            lastChange = "Order " + Convert.ToInt32(search.DLookUp("idorder", " (select * from erp_orders order by idorder " +
                "desc)", "rownum = 1")) + " inserted";
        }

        public void modifyOrder(int id, int customer, int user, int paymentMethod, double total, double prepaid)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ORDERS SET REFCUSTOMER=" + customer + " REFUSER = " + user + " REFPAYMENTMETHOD=" + paymentMethod +
                " TOTAL=" + total + "PREPAID= " + prepaid + " WHERE IDORDER=" + id + " ; ";
            search.setData(sql);
            lastChange = "Order " + id + " modified";
        }
        public void deleteOrder(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ORDERS SET DELETED = TRUE WHERE IDORDER=" + id + "; ";
            search.setData(sql);
            lastChange = "Customer " + id + " deleted";
        }
        public void undoDeleteOrder(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ORDERS SET DELETED = FALSE WHERE IDORDER=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of customer " + id;
        }
    }
}
