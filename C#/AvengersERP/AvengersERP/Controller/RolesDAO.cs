using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class RolesDAO
    {
        private static DataTable tabla;
        private static RolesDAO instance;
        private static string lastChange;
        private RolesDAO()
        {
            tabla = new DataTable();
        }
        public static RolesDAO getInstance()
        {
            if (instance == null)
            {
                instance = new RolesDAO();
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

        public void readRoles()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT IDROLE, NAMEROLE" +
                "FROM ERP_ROLES" +
                "WHERE DELETED=FALSE", "ROLES");
            tabla = data.Tables["roles"];
        }
        public void readDeletedRoles()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT IDROLE, NAMEROLE" +
                "FROM ERP_ROLES" +
                "WHERE DELETED=TRUE", "ROLES");
            tabla = data.Tables["roles"];
        }
        public void insertRole(string namerole)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_ROLES (NAMEROLE) VALUES ("+ namerole + ");";
            search.setData(sql);
            lastChange = "Role " + Convert.ToInt32(search.DLookUp("IDROLE", " (select * from ERP_ROLES order by " +
                "IDROLE desc)", "rownum = 1")) + " inserted";
        }

        public void modifyRole(int id, string namerole)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ROLES SET NAMEROLE=" + namerole + " WHERE IDROLE=" + id + "; ";
            search.setData(sql);
            lastChange = "Role " + id + " modified";
        }
        public void deleteRole(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ROLES SET DELETED = TRUE WHERE IDROLE=" + id + "; ";
            search.setData(sql);
            lastChange = "Role " + id + " deleted";
        }
        public void undoDeleteRole(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_ROLES SET DELETED = FALSE WHERE IDROLE=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of role " + id;
        }
    }
}
