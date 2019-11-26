using LoginWithOracle.Dominio;
using LoginWithOracle.Presentacion;
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


//oracle.dataprovider
namespace LoginWithOracle
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User u;
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            u = new User();
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text != "" && txtPassword.Text != "")
            {
                if(u.gestor().searchUser(new User(txtUser.Text, txtPassword.Text)))
                {
                    MessageBox.Show("Successful Login");
                    clearFields();
                    AllUsersGUI ventana = new AllUsersGUI();
                    ventana.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Incorrect Login");
                }
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                if(u.gestor().insert(new User(txtUser.Text, txtPassword.Text)) > 0)
                {
                    MessageBox.Show("Successful Register");
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Incorrect Register");
                }

            }
        }

        private void clearFields()
        {
            txtUser.Clear();
            txtPassword.Clear();
        }
    }


}
