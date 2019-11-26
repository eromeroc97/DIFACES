using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithOracle.Dominio.DAO
{
    class UserDAO
    {
        private static DataTable table;
        private static UserDAO instance;
        private UserDAO()
        {
            table = new DataTable();
        }

        public static UserDAO getInstance()
        {
            if(instance == null) //if doesn't exists instance -> create one
            {
                instance = new UserDAO();
            }
            return instance; //return the existing instance
        }
        public int insert(User u)
        {
            String sql = "INSERT INTO USERS VALUES('"+u.getLogin()+"','"+u.getPassword()+"')";
            ConnectOracle con = new ConnectOracle();
            int res = con.setData(sql);
            return res;
        }
        public Boolean searchUser(User u)
        {
            ConnectOracle con = new ConnectOracle();
            String sql = "SELECT COUNT(*) AS NUM_USER FROM USERS WHERE LOGIN='" + u.getLogin() + "' AND PASSWORD='" + u.getPassword() + "'";
            DataSet ds = con.getData(sql, "USERS");
            int test = Int32.Parse(ds.Tables[0].Rows[0]["NUM_USER"].ToString());
            return test > 0;
        }
        public void readUsers()
        {
            String sql = "SELECT * FROM USERS";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "USERS");
            table = ds.Tables["USERS"];
        }
        public DataTable getUsers()
        {
            return table;
        }
    }
}
