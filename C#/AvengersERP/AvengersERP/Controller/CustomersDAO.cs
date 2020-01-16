using System;
using System.Collections.Generic;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class CustomersDAO
    {
        private static DataTable tabla;
        private static CustomersDAO instance;
        private static string lastChange;
        private CustomersDAO()
        {
            tabla = new DataTable();
        }
        public static CustomersDAO getInstance()
        {
            if (instance == null)
            {
                instance= new CustomersDAO();
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

        public void readCustomers()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT CS.IDCUSTOMER, CS.NIF, CS.NAME, CS.SURNAME, CS.ADDRESS, CS.PHONE, CS.EMAIL, R.REGION," +
                "S.STATE, CT.CITY, Z.ZIPCODE " +
                "FROM ERP_CUSTOMERS CS, ERP_ZIPCODES_CITIES ZC, ERP_CITIES CT, ERP_ZIPCODES Z, ERP_STATES S, ERP_REGIONS R " +
                "WHERE CS.REFERP_ZIPCODES_CITIES=ZC.IDERP_ZIPCODES_CITIES AND ZC.REFZIPCODE=Z.IDZIPCODE AND ZC.REFCITY=CT.IDCITY AND " +
                "ZC.REFSTATE=S.IDSTATE AND S.REFREGION=R.IDREGION AND CS.DELETED=0", "CUSTOMERS");
            tabla = data.Tables["CUSTOMERS"];
        }
        public void readDeletedCustomers()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT CS.IDCUSTOMER, CS.NIF, CS.NAME, CS.SURNAME, CS.ADDRESS, CS.PHONE, CS.EMAIL, R.REGION," +
                "S.STATE, CT.CITY, Z.ZIPCODE " +
                "FROM ERP_CUSTOMERS CS, ERP_ZIPCODESCITIES ZC, ERP_CITIES CT, ERP_ZIPCODES Z, ERP_STATES S, ERP_REGIONS R " +
                "WHERE CS.REFERP_ZIPCODES_CITIES=ZC.IDERP_ZIPCODES_CITIES AND ZC.REFZIPCODE=Z.IDZIPCODE AND ZC.REFCITY=CT.IDCITY AND " +
                "ZC.REFSTATE=S.IDSTATE AND S.REFREGION=R.IDREGION AND CS.DELETED=1", "CUSTOMERS");
            tabla = data.Tables["CUSTOMERS"];
        }

        public void readZipList()
        {
            ConnectOracle con = new ConnectOracle();
            DataSet data = con.getData("SELECT ZIPCODE FROM ERP_ZIPCODES", "ZIPCODES");
            tabla = data.Tables["ZIPCODES"];
        }

        public void insertCustomer(string nif, string name, string surname, string address, int phone, string email, int zipcode,
            string user)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_CUSTOMERS (NIF, NAME, SURNAME, ADDRESS, PHONE, EMAIL, REFZIPCODESCITIES) VALUES ("
                + nif + ", " + name + ", " + surname + ", " + address + ", " + phone + ", " + email + ", " + zipcode + ");";
            search.setData(sql);
            lastChange = "Customer " + Convert.ToInt32(search.DLookUp("idcustomer", " (select * from erp_customers order by " +
                "idcustomer desc)", "rownum = 1")) + " inserted by user "+ user;
        }

        public void modifyCustomer(int id, string nif, string name, string surname, string address, int phone, string email,
            int zipcode, string user)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_CUSTOMERS SET NIF=" + nif + " NAME = " + name + " SURNAME=" + surname + "ADDRESS=" +
                address + "PHONE= " + phone + " EMAIL=" + email + "REFZIPCODESCITIES=" + zipcode + " WHERE IDCUSTOMER=" + id + "; ";
            search.setData(sql);
            lastChange = "Customer " + id + " modified by user " + user;
        }
        public void deleteCustomer(int id, string user)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_CUSTOMERS SET DELETED = 1 WHERE IDCUSTOMER=" + id + "; ";
            search.setData(sql);
            lastChange = "Customer "+ id + " deleted by user " + user;
        }
        public void undoDeleteCustomer(int id, string user)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_CUSTOMERS SET DELETED = 0 WHERE IDCUSTOMER=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of customer " + id + " by user " + user; 
        }
    }
}
