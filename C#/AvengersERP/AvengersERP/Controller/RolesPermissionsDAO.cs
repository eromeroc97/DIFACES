using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class RolesPermissionsDAO
    {
        private static DataTable tabla;
        private static RolesPermissionsDAO instance;
        private static string lastChange;
        private RolesPermissionsDAO()
        {
            tabla = new DataTable();
        }
        public static RolesPermissionsDAO getInstance()
        {
            if (instance == null)
            {
                instance = new RolesPermissionsDAO();
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
        public void readRolesPermissions(int role)
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT R.ROLENAME, P.PERMISSIONNAME " +
                "FROM ERP_ROLES R, ERP_PERMISSIONS P, ERP_ROLES_PERMISSIONS RP" +
                "WHERE RP.REFROLE=" + role + "AND R.IDROLE=RP.REFROLE AND P.IDPERMISSION=RP.REFPERMISSION", "ROLESPERMISSIONS");
            tabla = data.Tables["rolespermissions"];
        }
        public void readPermissions()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT PERMISSIONNAME " +
                "FROM ERP_PERMISSIONS", "PERMISSIONS");
            tabla = data.Tables["permissions"];
        }

        public void insertRolesPermissions(int role, int permission)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_ROLES_PERMISSIONS (REFROLE, REFPERMISSION) VALUES ("
                + role + ", " + permission + ");";
            search.setData(sql);
            lastChange = "Permission " + permission + " inserted to the role " + role;
        }

        public void deleteRolesPermissions(int role, int permission)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "DELETE FROM ERP_ROLES_PERMISSIONS WHERE REFROLE=" + role + "REFPERMISSION=" + permission + "; ";
            search.setData(sql);
            lastChange = "Deleted permission " + permission + " from the role " + role;
        }
    }
}
