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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvengersERP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean click;
        public MainWindow()
        {
            InitializeComponent();
            click = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (click)
            {
                click = false;
                Ojo.Source = (ImageSource)FindResource("Ocultar");
            }
            else
            {
                click = true;
                Ojo.Source = (ImageSource)FindResource("Ver");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Principal cc = new Principal();
            cc.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserCreator uc = new UserCreator();
            uc.Show();
            this.Hide();
        }
    }
}
