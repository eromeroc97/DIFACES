using LoginWithOracle.Dominio.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithOracle.Dominio
{
    class User
    {
        private string login;
        private string password;
        private UserDAO gestor;

        public User()
        {
            this.gestor = UserDAO.getInstance();
        }
        public User(String login, String password)
        {
            this.gestor = UserDAO.getInstance();
            this.login = login;
            this.password = password;
        }
        
        public String getLogin()
        {
            return this.login;
        }
        public String getPassword()
        {
            return encryptPassword(this.password);
        }
        private String encryptPassword(String pass)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(pass);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public DataTable loadUsers()
        {
            gestor.readUsers();
            return gestor.getUsers();
        }

        public Boolean searchUser(String login, String password)
        {
            User u = new User(login, password);
            return gestor.searchUser(u);
        }

        public int insert(String login, String password)
        {
            User u = new User(login, password);
            return gestor.insert(u);
        }
    }
}
