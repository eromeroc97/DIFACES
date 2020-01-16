using AvengersERP.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        User u;
        Window caller;
        public Principal(User user, MainWindow caller)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            WindowState = System.Windows.WindowState.Maximized;
            u = user;
            this.caller = caller;
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
            CustomerAdministrator ua = new CustomerAdministrator(u);
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Products ua = new Products();
            Control.Height = ua.Height;
            Control.Width = ua.Width;
            Control.Content = ua.Content;
        }

        private void Principal_Closing(object sender, CancelEventArgs e)
        {
            if(caller != null)
            {
                caller.Visibility = Visibility.Visible;
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
            
        }
    }
}
