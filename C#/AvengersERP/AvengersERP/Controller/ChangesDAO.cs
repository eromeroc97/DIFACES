using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class ChangesDAO
    {
        private static DataTable tabla;
        private static ChangesDAO instance;
        private static string lastChange;
        private ChangesDAO()
        {
            tabla = new DataTable();
        }
        public static ChangesDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ChangesDAO();
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

        public void readChanges()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT C.IDCHANGE, U.NAME, C.CHANGE" +
                "FROM ERP_CHANGES C, ERP_USERS U" +
                "WHERE C.REFUSER=U.IDUSER", "CHANGES");
            tabla = data.Tables["changes"];
        }

        public void insertChange(int user, string change)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_CHANGES (REFUSER, CHANGE) VALUES ("
                + user + ", " + change + ");";
            search.setData(sql);
            lastChange = "User " + Convert.ToInt32(search.DLookUp("IDCHANGE", " (select * from ERP_CHANGES order by " +
                "IDCHANGE desc)", "rownum = 1")) + " inserted";
        }

    }
}
