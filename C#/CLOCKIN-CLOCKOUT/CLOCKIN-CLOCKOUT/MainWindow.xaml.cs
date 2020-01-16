﻿using System;
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

namespace CLOCKIN_CLOCKOUT
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

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Visibility = Visibility.Visible;
        }

        private void BntEnd_Click(object sender, RoutedEventArgs e)
        {
            CheckOutConfirmation cout = new CheckOutConfirmation();
            cout.Visibility = Visibility.Visible;
        }
    }
}