using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class PaymentMethodsDAO
    {
        private static DataTable tabla;
        private static PaymentMethodsDAO instance;
        private static string lastChange;
        private PaymentMethodsDAO()
        {
            tabla = new DataTable();
        }
        public static PaymentMethodsDAO getInstance()
        {
            if (instance == null)
            {
                instance = new PaymentMethodsDAO();
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

        public void readPaymentMethods()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT IDPAYMENTMETHOD, PAYMENTMETHOD" +
                "FROM ERP_PAYMENTMETHODS" +
                "WHERE DELETED=FALSE", "PAYMENTMETHODS");
            tabla = data.Tables["paymentmethods"];
        }
        public void readDeletedPaymentMethods()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT IDPAYMENTMETHOD, PAYMENTMETHOD" +
                "FROM ERP_PAYMENTMETHODS" +
                "WHERE DELETED=TRUE", "PAYMENTMETHODS");
            tabla = data.Tables["paymentmethods"];
        }
        public void insertPaymentMethod(string paymentmethod)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_PAYMENTMETHODS (PAYMENTMETHOD) VALUES (" + paymentmethod + ");";
            search.setData(sql);
            lastChange = "Payment method " + Convert.ToInt32(search.DLookUp("IDPAYMENTMETHOD", " (select * from ERP_PAYMENTMETHODS" +
                " order by IDPAYMENTMETHOD desc)", "rownum = 1")) + " inserted";
        }

        public void modifyPaymentMethod(int id, string paymentmethod)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PAYMENTMETHODS SET PAYMENTMETHOD=" + paymentmethod + " WHERE IDPAYMENTMETHOD=" + id + "; ";
            search.setData(sql);
            lastChange = "Payment method " + id + " modified";
        }
        public void deletePaymentMethod(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PAYMENTMETHODS SET DELETED = TRUE WHERE IDPAYMENTMETHOD=" + id + "; ";
            search.setData(sql);
            lastChange = "Payment method " + id + " deleted";
        }
        public void undoDeletePaymentMethod(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_PAYMENTMETHODS SET DELETED = FALSE WHERE IDPAYMENTMETHOD=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of payment method " + id;
        }
    }
}
