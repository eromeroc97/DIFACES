using AvengersERP.controller;

namespace AvengersERP.model
{
    public class OrderProduct
    {
        private OrdersProductsDAO dao;
        private Product product;
        private int amount;
        private float pricesale;

        private OrderProduct()
        {
            this.dao = OrdersProductsDAO.getInstance();
        }

        public OrderProduct(Product product, int amount, float pricesale)
        {
            this.dao = OrdersProductsDAO.getInstance();
            this.product = product;
            this.amount = amount;
            this.pricesale = pricesale;
        }

        public Product Product { get => product; set => product = value; }
        public int Amount { get => amount; set => amount = value; }
        public float Pricesale { get => pricesale; set => pricesale = value; }
        public OrdersProductsDAO Dao { get => dao; }
    }
}