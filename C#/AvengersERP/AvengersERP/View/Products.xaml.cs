using AvengersERP.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AvengersERP.view
{
    /// <summary>
    /// Lógica de interacción para Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        Product prod;

        public Products()
        {
            InitializeComponent();
            loadTableProd();
        }

        private void loadTableProd()
        {
            prod = new Product();
            DataTable prodData = prod.readAllProducts();
            datagridProd.DataContext = prodData.DefaultView;
            datagridProd.FrozenColumnCount = 2;
            datagridProd.IsReadOnly = true;
        }
    }
}
