using AvengersERP.model;
using System;
using System.Data;

//Pedro Martín-Serrano

namespace AvengersERP.controller
{
    public class UsersDAO
    {
        private static DataTable tabla;
        private static UsersDAO instance;
        private static string lastChange;
        private UsersDAO()
        {
            tabla = new DataTable();
        }
        public static UsersDAO getInstance()
        {
            if (instance == null)
            {
                instance = new UsersDAO();
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

        public void readUsers()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT U.IDUSER, R.ROLENAME, U.NAME" +
                "FROM ERP_USERS U, ERP_ROLES R" +
                "WHERE R.IDROLE=U.REFROLE, U.DELETED=FALSE", "USERS");
            tabla = data.Tables["users"];
        }
        public void readDeletedUsers()
        {
            ConnectOracle search = new ConnectOracle();
            DataSet data = search.getData("SELECT U.IDUSER, R.ROLEMANE, U.NAME" +
                "FROM ERP_USERS U, ERP_ROLES R" +
                "WHERE R.IDROLE=U.REFROLE, U.DELETED=TRUE", "USERS");
            tabla = data.Tables["users"];
        }
        public void insertUser(int role, string name, string password)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "INSERT INTO ERP_USERS (REFROLE, NAME, PASSWORD) VALUES ("
                + role + ", " + name + ", " + password + ");";
            search.setData(sql);
            lastChange = "User " + Convert.ToInt32(search.DLookUp("IDUSER", " (select * from ERP_USERS order by " +
                "IDUSER desc)", "rownum = 1")) + " inserted";
        }

        public void modifyUser(int id, int role, string name, string password)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_USERS SET REFROLE=" + role + " NAME = " + name + " PASSWORD=" + password +
                " WHERE IDPRODUCT=" + id + "; ";
            search.setData(sql);
            lastChange = "User " + id + " modified";
        }
        public void deleteUser(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_USERS SET DELETED = TRUE WHERE IDUSER=" + id + "; ";
            search.setData(sql);
            lastChange = "User " + id + " deleted";
        }
        public void undoDeleteUser(int id)
        {
            ConnectOracle search = new ConnectOracle();
            string sql = "UPDATE ERP_USERS SET DELETED = FALSE WHERE IDUSER=" + id + "; ";
            search.setData(sql);
            lastChange = "Reverted delete of user " + id;
        }

        public Boolean checkUser(string name, string password)
        {
            ConnectOracle con = new ConnectOracle();
            Object o = con.DLookUp("IDUSER", "ERP_USERS", "NAME='"+name+"' AND PASSWORD='"+password+"'");
            return !o.Equals(-1);
        }

        public User loadUser(string name)
        {
            ConnectOracle con = new ConnectOracle();
            Object o = con.DLookUp("IDUSER", "ERP_USERS", "NAME='" + name + "'");
            return o as User;
        }
    }
}
