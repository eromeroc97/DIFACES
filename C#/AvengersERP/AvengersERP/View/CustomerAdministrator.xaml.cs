
using AvengersERP.model;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace AvengersERP.view
{
    /// <summary>
    /// Lógica de interacción para CustomerAdministrator.xaml
    /// </summary>
    public partial class CustomerAdministrator : Window
    {
        private DataTable table;
        private User logedUser;
        private Customer selectedCustomer;
        private bool showingDeleted;

        public CustomerAdministrator(User user)
        {
            InitializeComponent();
            startTable();
            logedUser = user;
            selectedCustomer = null;
            showingDeleted = false;
        }
        private void startTable()
        {
            Customer c = new Customer();
            c.Dao.readCustomers();
            table = c.Dao.getTable();
            dgvCustomers.ItemsSource = table.DefaultView;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CustomerCreator newWindow = new CustomerCreator(logedUser);
            newWindow.ShowDialog();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            CustomerCreator newWindow = new CustomerCreator(logedUser,selectedCustomer);
            newWindow.ShowDialog();
        }

        private void dgvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowSelected = dgvCustomers.SelectedCells as DataRowView;
            if (rowSelected != null)
            {
                if (showingDeleted)
                {
                    selectedCustomer = new Customer(Convert.ToInt32(rowSelected[0].ToString()), rowSelected[1].ToString(),
                    rowSelected[2].ToString(), rowSelected[3].ToString(), rowSelected[4].ToString(),
                    Convert.ToInt32(rowSelected[5].ToString()), rowSelected[6].ToString(),
                    0, Convert.ToInt32(rowSelected[7].ToString()), rowSelected[8].ToString(),
                    rowSelected[9].ToString(), rowSelected[10].ToString());
                }
                else
                {
                    selectedCustomer = new Customer(Convert.ToInt32(rowSelected[0].ToString()), rowSelected[1].ToString(),
                    rowSelected[2].ToString(), rowSelected[3].ToString(), rowSelected[4].ToString(),
                    Convert.ToInt32(rowSelected[5].ToString()), rowSelected[6].ToString(),
                    1, Convert.ToInt32(rowSelected[7].ToString()), rowSelected[8].ToString(),
                    rowSelected[9].ToString(), rowSelected[10].ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCustomer != null)
            {
                if (!showingDeleted)
                {
                    selectedCustomer.Dao.deleteCustomer(selectedCustomer.Idcustomer,logedUser.Name);
                }
                else
                {
                    selectedCustomer.Dao.undoDeleteCustomer(selectedCustomer.Idcustomer, logedUser.Name);
                }
            }
        }

        private void btnSeeDeleted_Click(object sender, RoutedEventArgs e)
        {
            if (!showingDeleted)
            {
                showingDeleted = true;
                btnDelete.Content = "Revert Delete";
                btnCreate.Visibility = Visibility.Hidden;
                btnCreate.IsEnabled = false;
                btnModify.Visibility = Visibility.Hidden;
                btnModify.IsEnabled = false;
            }
            else
            {
                showingDeleted = false;
                btnDelete.Content = "Delete Customer";
                btnCreate.Visibility = Visibility.Visible;
                btnCreate.IsEnabled = true;
                btnModify.Visibility = Visibility.Visible;
                btnModify.IsEnabled = true;
            }
        }
    }
}
