using PRODUCTS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCTS.Domain.DAO
{
    class ProductDAO
    {
        private static DataTable retrievedData;
        private static ProductDAO instance;

        private ProductDAO()
        {
            retrievedData = new DataTable();
        }

        public static ProductDAO getInstance()
        {
            if (instance == null) //if doesn't exists instance -> create one
            {
                instance = new ProductDAO();
            }
            return instance; //return the existing instance
        }
        public DataTable getData()
        {
            return retrievedData;
        }
        public List<string> getCompositions()
        {
            List<string> values = new List<string>();

            String sql = "SELECT DISTINCT COMPOSITION FROM COMPOSITIONS";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "COMPOSITIONS");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                values.Add(ds.Tables[0].Rows[i]["COMPOSITION"].ToString());

            return values;
        }

        public List<string> getMeasures(string composition)
        {
            List<string> values = new List<string>();

            String sql = "SELECT DISTINCT M.MEASURE FROM MEASURES M, PRODUCTS P, COMPOSITIONS C WHERE M.IDMEASURE = P.REFMEASURE AND P.REFCOMPOSITION = C.IDCOMPOSITION AND C.COMPOSITION='"+composition+"'";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "MEASURES");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                values.Add(ds.Tables[0].Rows[i]["MEASURE"].ToString());

            return values;
        }

        internal void loadByPrice(string symbol, float price)
        {
            string sql = "SELECT C.COMPOSITION, M.MEASURE, P.PRICE FROM COMPOSITIONS C, MEASURES M, PRODUCTS P WHERE C.IDCOMPOSITION = P.REFCOMPOSITION AND M.IDMEASURE = P.REFMEASURE AND P.DELETED = -1 AND P.PRICE"+symbol+" "+price+"";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "PRODUCTS");
            retrievedData = ds.Tables["PRODUCTS"];
        }

        internal void readByCompositionMeasure(string composition, string measure)
        {
            string sql = "SELECT C.COMPOSITION, M.MEASURE, P.PRICE FROM COMPOSITIONS C, MEASURES M, PRODUCTS P WHERE C.IDCOMPOSITION = P.REFCOMPOSITION AND M.IDMEASURE = P.REFMEASURE AND P.DELETED = -1 AND C.COMPOSITION='" + composition + "' AND M.MEASURE='"+measure+"'";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "PRODUCTS");
            retrievedData = ds.Tables["PRODUCTS"];
        }

        public void readAllProducts()
        {
            string sql = "SELECT C.COMPOSITION, M.MEASURE, P.PRICE FROM COMPOSITIONS C, MEASURES M, PRODUCTS P WHERE C.IDCOMPOSITION = P.REFCOMPOSITION AND M.IDMEASURE = P.REFMEASURE AND DELETED = -1";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "PRODUCTS");
            retrievedData = ds.Tables["PRODUCTS"];
        }

        public void readByComposition(string composition)
        {
            string sql = "SELECT C.COMPOSITION, M.MEASURE, P.PRICE FROM COMPOSITIONS C, MEASURES M, PRODUCTS P WHERE C.IDCOMPOSITION = P.REFCOMPOSITION AND M.IDMEASURE = P.REFMEASURE AND P.DELETED = -1 AND C.COMPOSITION='"+composition+"'";
            ConnectOracle con = new ConnectOracle();
            DataSet ds = con.getData(sql, "PRODUCTS");
            retrievedData = ds.Tables["PRODUCTS"];
        }
    }
}
