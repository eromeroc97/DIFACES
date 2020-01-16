using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.model
{
    public class Customer
    {
        private CustomersDAO dao;

        private int idcustomer;
        private string nif;
        private string name;
        private string surname;
        private string address;
        private int phone;
        private string email;
        private int deleted;
        private int zipcode;
        private string city;
        private string state;
        private string region;

        public Customer()
        {
            this.dao = CustomersDAO.getInstance();
        }

        public Customer(int idcustomer, string nif, string name, string surname, string address, int phone, 
            string email, int deleted, int zipcode, string city, string state, string region)
        {
            this.dao = CustomersDAO.getInstance();
            this.Idcustomer = idcustomer;
            this.nif = nif;
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Deleted = deleted;
            this.Zipcode = zipcode;
            this.City = city;
            this.State = state;
            this.Region = region;
        }

        public int Idcustomer { get => idcustomer; set => idcustomer = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Address { get => address; set => address = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        public int Zipcode { get => zipcode; set => zipcode = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Region { get => region; set => region = value; }
        public CustomersDAO Dao { get => dao; }
        public string Nif { get => nif; set => nif = value; }
    }
}
