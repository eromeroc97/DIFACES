using LoginWithOracle.Dominio;
using LoginWithOracle.Dominio.DAO;
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

namespace LoginWithOracle.Presentacion
{
    /// <summary>
    /// Lógica de interacción para AllUsersGUI.xaml
    /// </summary>
    public partial class AllUsersGUI : Window
    {
        User u;
        public AllUsersGUI()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            loadDataTable();
        }

        private void loadDataTable()
        {
            u = new User();
            DataTable usersData = u.loadUsers();
            datagridUsers.DataContext = usersData.DefaultView;
            datagridUsers.FrozenColumnCount = 2;
            datagridUsers.IsReadOnly = true;
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

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datagridUsers.SelectedItems[0];
            txtLogin.Text = row["Login"].ToString();
            txtPassword.Password = deencrypt(row["Password"].ToString());
        }
        public static string deencrypt(String ePass)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(ePass);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int val = u.insert(txtLogin.Text, txtPassword.Password);
                if (val > 0)
                {
                    MessageBox.Show("User inserted correctly!");
                    loadDataTable();
                }
                else
                    MessageBox.Show("User could not be inserted");
            }
            catch (Exception)
            {
                MessageBox.Show("Error while inserting");
            }
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DatagridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
