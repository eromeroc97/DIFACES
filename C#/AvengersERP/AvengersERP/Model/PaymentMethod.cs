using AvengersERP.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersERP.model
{
    class PaymentMethod
    {
        private PaymentMethodsDAO dao;
        private int idPaymentMethod;
        private string paymentmethod;
        private int deleted;

        public PaymentMethod(int idPaymentMethod, string paymentmethod, int deleted)
        {
            this.dao = PaymentMethodsDAO.getInstance();
            this.idPaymentMethod = idPaymentMethod;
            this.Paymentmethod = paymentmethod;
            this.Deleted = deleted;
        }

        public string Paymentmethod { get => paymentmethod; set => paymentmethod = value; }
        public int Deleted { get => deleted; set => deleted = value; }
        public int IdPaymentMethod { get => idPaymentMethod; set => idPaymentMethod = value; }
        public PaymentMethodsDAO Dao { get => dao; }
    }
}
