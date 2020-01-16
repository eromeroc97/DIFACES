using System;
using System.Collections.Generic;
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

namespace AvengersERP
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAdministrator ua = new UserAdministrator();
            Control.Height = ua.Height;
            Control.Width = ua.Width;
            Control.Content = ua.Content;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RolesAdministrator ua = new RolesAdministrator();
            Control.Height = ua.Height;
            Control.Width = ua.Width;
            Control.Content = ua.Content;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CustomerAdministrator ua = new CustomerAdministrator();
            Control.Height = ua.Height;
            Control.Width = ua.Width;
            Control.Content = ua.Content;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OrdersAdministrator ua = new OrdersAdministrator();
            Control.Height = ua.Height;
            Control.Width = ua.Width;
            Control.Content = ua.Content;
        }
    }
}
