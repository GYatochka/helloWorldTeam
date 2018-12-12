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


namespace Task3_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CashierLoginWindow cashierLogin;
            this.Show();
            cashierLogin = new CashierLoginWindow();
            cashierLogin.Owner = this;
            cashierLogin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cashierLogin.Topmost = true;
            DataContext = new Ticket();
           // cashierLogin.ShowDialog();
            using (ProductContext db = new ProductContext())
            {
                var products= db.Products;
                foreach (Product u in products)
                {
                    MessageBox.Show(  u.Name,u.Price.ToString());
                }
            }
        }  
    }
}