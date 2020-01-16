using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.Model
{
    public class Role
    {
        private RolesDAO dao;
        private List<Permission> permissions;

        private int idRole;
        private string name;
        private int deleted;

        public Role(List<Permission> permissions, int idRole, string name, int deleted)
        {
            this.dao = RolesDAO.getInstance();
            this.permissions = permissions;
            this.idRole = idRole;
            this.name = name;
            this.deleted = deleted;
        }

        public List<Permission> Permissions { get => permissions; set => permissions = value; }
        public int IdRole { get => idRole; set => idRole = value; }
        public string Name { get => name; set => name = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        public RolesDAO Dao { get => dao; }
    }
}
