using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.model
{
    public class Order
    {
        private OrdersDAO dao;

        private int idorder;
        private int idcustomer;
        private int iduser;
        private DateTime datetime;
        private int paymentmethod;
        private float total;
        private float prepaid;
        private int deleted;

        private List<OrderProduct> orderproducts;

        public Order()
        {
            this.dao = OrdersDAO.getInstance();
            this.orderproducts = new List<OrderProduct>();
        }

        public Order(int idorder, int idcustomer, int iduser, DateTime datetime, int paymentmethod, float total, float prepaid, int deleted)
        {
            this.dao = OrdersDAO.getInstance();
            this.orderproducts = new List<OrderProduct>();
            this.Idorder = idorder;
            this.Idcustomer = idcustomer;
            this.Iduser = iduser;
            this.Datetime = datetime;
            this.Paymentmethod = paymentmethod;
            this.Total = total;
            this.Prepaid = prepaid;
            this.Deleted = deleted;
        }

        public int Idorder { get => idorder; set => idorder = value; }
        public int Idcustomer { get => idcustomer; set => idcustomer = value; }
        public int Iduser { get => iduser; set => iduser = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }
        public int Paymentmethod { get => paymentmethod; set => paymentmethod = value; }
        public float Total { get => total; set => total = value; }
        public float Prepaid { get => prepaid; set => prepaid = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        public List<OrderProduct> Orderproducts { get => orderproducts; }
        public OrdersDAO Dao { get => dao; }
    }
}
