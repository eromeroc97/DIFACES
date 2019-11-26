using LoginWithOracle.Dominio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithOracle.Dominio
{
    class User
    {
        private string login;
        private string password;
        private UserDAO u;

        public User()
        {
            this.u = UserDAO.getInstance();
        }
        public User(String login, String password)
        {
            this.u = UserDAO.getInstance();
            this.login = login;
            this.password = password;
        }
        public UserDAO gestor()
        {
            return this.u;
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
    }
}
