using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.model
{
    public class User
    {
        private UsersDAO dao;
        private int idUser;
        private int idRole;
        private string name;
        private string password;
        private int deleted;

        public User()
        {
            this.dao = UsersDAO.getInstance();
        }
        public User(int idUser, int idRole, string name, string password, int deleted)
        {
            this.dao = UsersDAO.getInstance();
            this.idUser = idUser;
            this.idRole = idRole;
            this.name = name;
            this.password = password;
            this.deleted = deleted;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public int IdRole { get => idRole; set => idRole = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        public UsersDAO Dao { get => dao; }
    }
}
