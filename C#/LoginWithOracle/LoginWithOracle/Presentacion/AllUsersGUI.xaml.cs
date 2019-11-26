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
        UserDAO udao;
        public AllUsersGUI()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            udao = UserDAO.getInstance();
            udao.readUsers();
            DataTable usersData = udao.getUsers();
            datagridUsers.DataContext = usersData.DefaultView;
            
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
    }
}
