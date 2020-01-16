using AvengersERP.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;


namespace AvengersERP.view
{
    /// <summary>
    /// Lógica de interacción para CustomerCreator.xaml
    /// </summary>
    public partial class CustomerCreator : Window
    {
        private bool createMode;
        private User logedUser;
        private Customer selectedCustomer;
        public CustomerCreator(User u)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            createMode = true;
            logedUser = u;
            selectedCustomer = new Customer();
            loadZipCodes();
        }
        public CustomerCreator(User u, Customer c)
        {
            InitializeComponent();
            createMode = false;
            logedUser = u;
            selectedCustomer = c;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (createMode)
            {
                selectedCustomer.Dao.insertCustomer(selectedCustomer.Nif, selectedCustomer.Name, selectedCustomer.Surname,
                    selectedCustomer.Address, selectedCustomer.Phone, selectedCustomer.Email, selectedCustomer.Zipcode,
                    logedUser.Name);
            }
            else
            {
                selectedCustomer.Dao.modifyCustomer(selectedCustomer.Idcustomer, selectedCustomer.Nif,
                    selectedCustomer.Name, selectedCustomer.Surname, selectedCustomer.Address, selectedCustomer.Phone,
                    selectedCustomer.Email, selectedCustomer.Zipcode, logedUser.Name);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loadZipCodes()
        {
            Customer customerManager = new Customer();
            customerManager.Dao.readZipList();

            DataTable tablaCustomers = customerManager.Dao.getTable();

            cboZipcode.ItemsSource = tablaCustomers.DefaultView;

            /*int[] array = new int[tablaCustomers.Rows.Count];
            for (int i = 0; i < tablaCustomers.Rows.Count; i++)
            {
                array[i] = Int32.Parse(tablaCustomers.Rows[i][0].ToString());
            }
            for (int i = 0; i < array.Length; i++)
            {
                cboZipcode.Items.Add(array[i]);
            }*/

        }
    }
}
