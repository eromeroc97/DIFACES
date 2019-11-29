using PRODUCTS.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCTS.Domain
{
    class Product
    {
        private int idProduct;
        private string composition;
        private string measure;
        private float price;
        private ProductDAO pdao;

        public Product()
        {
            this.pdao = ProductDAO.getInstance();
        }

        public Product(int idProduct, string composition, string measure, float price)
        {
            this.pdao = ProductDAO.getInstance();
            this.idProduct = idProduct;
            this.composition = composition;
            this.measure = measure;
            this.price = price;
        }

        public int getIdProduct() { return idProduct; }
        public string getRefComposition() { return composition; }
        public string getRefMeasure() { return measure; }
        public float getPrice() { return price; }


        public DataTable loadAllProducts()
        {
            pdao.readAllProducts();
            return pdao.getData();
        }

        public DataTable loadByComposition(string composition)
        {
            pdao.readByComposition(composition);
            return pdao.getData();
        }

        public List<string> loadCompositions()
        {
            return pdao.getCompositions();
        }

        public List<string> loadMeasures(string composition)
        {
            return pdao.getMeasures(composition);
        }

        internal DataTable loadByCompositionMeasure(string composition, string measure)
        {
            pdao.readByCompositionMeasure(composition, measure);
            return pdao.getData();
        }

        public DataTable loadByPrice(string symbol, float price)
        {
            pdao.loadByPrice(symbol, price);
            return pdao.getData();
        }
    }
}
