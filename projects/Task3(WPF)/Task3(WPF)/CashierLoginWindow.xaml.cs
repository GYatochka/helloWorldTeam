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
using System.Windows.Shapes;

namespace Task3_WPF_
{
    /// <summary>
    /// Interaction logic for CashierLoginWindow.xaml
    /// </summary>
    public partial class CashierLoginWindow : Window
    {
        public CashierLoginWindow()
        {
            InitializeComponent();
            CashierLogin cashierLogin = new CashierLogin();
            this.DataContext = cashierLogin;
            if (cashierLogin.CloseAction == null)
                cashierLogin.CloseAction = new Action(this.Close);

        }
       
  
}
}
