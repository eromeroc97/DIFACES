using PRODUCTS.Domain;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRODUCTS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product p;
        public MainWindow()
        {
            InitializeComponent();
            loadDataTable();
            loadCompositions();
            loadPrices();
        }

        private void loadDataTable()
        {
            p = new Product();
            DataTable dataProducts = p.loadAllProducts();
            dgvProducts.DataContext = dataProducts.DefaultView;
            dgvProducts.MinColumnWidth = dgvProducts.Width / 3;
            dgvProducts.IsReadOnly = true;
        }

        private void loadDataCompositions(string composition)
        {
            DataTable dataProducts = p.loadByComposition(composition);
            dgvProducts.DataContext = dataProducts.DefaultView;
            dgvProducts.MinColumnWidth = dgvProducts.Width / 3;
            dgvProducts.IsReadOnly = true;
        }

        private void loadDataMeasures(string composition, string measure)
        {
            DataTable dataProducts = p.loadByCompositionMeasure(composition, measure);
            dgvProducts.DataContext = dataProducts.DefaultView;
            dgvProducts.MinColumnWidth = dgvProducts.Width / 3;
            dgvProducts.IsReadOnly = true;
        }

        private void loadDataPrice(string symbol, float price)
        {
            DataTable dataProducts = p.loadByPrice(symbol, price);
            dgvProducts.DataContext = dataProducts.DefaultView;
            dgvProducts.MinColumnWidth = dgvProducts.Width / 3;
            dgvProducts.IsReadOnly = true;
        }

        private void loadCompositions()
        {
            List<string> compositions = p.loadCompositions();
            cbxComposition.Items.Add(null);
            for (int i = 0; i < compositions.Count; i++)
                cbxComposition.Items.Add(compositions.ElementAt(i));
        }

        private void loadPrices()
        {
            cbxPrice.Items.Add(">");
            cbxPrice.Items.Add("=");
            cbxPrice.Items.Add("<");
        }

        private void loadMeasures(string composition)
        {
            
            List<string> measures = p.loadMeasures(composition);
            cbxMeasure.Items.Add(string.Empty);
            for (int i = 0; i < measures.Count; i++)
                cbxMeasure.Items.Add(measures.ElementAt(i));
            
        }

        private void CbxComposition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string composition = cbxComposition.SelectedValue.ToString();
            
            cbxMeasure.Items.Clear();
            if (!composition.Equals(String.Empty))
            {
                cbxMeasure.IsEnabled = true;
                loadDataCompositions(composition);
                loadMeasures(composition);
            }
            else
            {
                cbxMeasure.IsEnabled = false;
                loadDataTable();
            }
        }

        private void CbxMeasure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string composition = cbxComposition.SelectedValue.ToString();
            string measure = cbxMeasure.SelectedValue.ToString();
            
            if (!measure.Equals(""))
            {
                loadDataMeasures(composition, measure);
            }
            else
            {
                loadDataCompositions(composition);
            }
        }

        private void CbxPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string symbol = cbxPrice.SelectedValue.ToString();
            float price = float.Parse(txtSearch.Text);
            loadDataPrice(symbol, price);
        }
    }
}
