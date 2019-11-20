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

namespace LoginWithOracle
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text != "" && txtPassword.Text != "")
            {
                ConnectOracle con = new ConnectOracle();
                DataSet ds = con.getData("SELECT * FROM USERS WHERE LOGIN='"+txtUser.Text+"'AND PASSWORD='"+txtPassword.Text+"'", "USERS");
                if(ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Log In");
                }
                else
                {
                    MessageBox.Show("Correct! Loging in...");
                }
            }
        }
    }


}
