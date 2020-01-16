using AvengersERP.model;
using AvengersERP.Utilities;
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

namespace AvengersERP.view
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean visiblePassword;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            visiblePassword = false;
        }

        private void btnOkey_Click(object sender, RoutedEventArgs e)
        {
            //Ping to Database
            if (Utils.PingHost("10.14.0.6"))
            {
                //1. Check user
                User userManager = new User();
                if (userManager.Dao.checkUser(txtUser.Text, Utilities.Utils.md5(txtPassword.Password)))
                {
                    //2. Load User
                    User logedUser = userManager.Dao.loadUser(txtUser.Text);
                    //3. Load window
                    Principal cc = new Principal(logedUser, this); //we send the window which called the principal
                    cc.Show();
                    this.Visibility = Visibility.Hidden;
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Incorrect user!", "Error");
                }
            }
            else
            {
                MessageBox.Show("Connection to Data Base not available");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //exit
            this.Close();
        }

        private void clearFields()
        {
            txtUser.Clear();
            txtPassword.Clear();
        }
    }
}
