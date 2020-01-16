using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.model

{
    public class Product
    {
        private ProductsDAO dao;

        private int idproduct;
        private string composition;
        private float measure;
        private float price;
        private string brand;
        private string model;
        private int ram;
        private int rom;
        private string screen;
        private string processor;
        private int deleted;

        public Product(){
            this.dao = ProductsDAO.getInstance();
        }

        public Product(int idproduct, string composition, float measure, float price, string brand, string model, int ram, int rom, string screen, string processor, int deleted)
        {
            this.dao = ProductsDAO.getInstance();
            this.Idproduct = idproduct;
            this.Composition = composition;
            this.Measure = measure;
            this.Price = price;
            this.Brand = brand;
            this.Model = model;
            this.Ram = ram;
            this.Rom = rom;
            this.Screen = screen;
            this.Processor = processor;
            this.Deleted = deleted;
        }

        public int Idproduct { get => idproduct; set => idproduct = value; }
        public string Composition { get => composition; set => composition = value; }
        public float Measure { get => measure; set => measure = value; }
        public float Price { get => price; set => price = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Ram { get => ram; set => ram = value; }
        public int Rom { get => rom; set => rom = value; }
        public string Screen { get => screen; set => screen = value; }
        public string Processor { get => processor; set => processor = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        internal ProductsDAO Dao { get => dao; set => dao = value; }

        public DataTable readAllProducts()
        {
            dao.readProducts();
            return dao.getTable();
        }
    }
}
