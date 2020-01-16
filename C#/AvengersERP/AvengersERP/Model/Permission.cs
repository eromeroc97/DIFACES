using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.Model
{
    public class Permission
    {
        private RolesPermissionsDAO dao;

        private int idPermission;
        private string name;

        public Permission(int idPermission, string name)
        {
            this.dao = RolesPermissionsDAO.getInstance();
            this.idPermission = idPermission;
            this.name = name;
        }

        public int IdPermission { get => idPermission; set => idPermission = value; }
        public string Name { get => name; set => name = value; }
        public RolesPermissionsDAO Dao { get => dao; set => dao = value; }
    }
}