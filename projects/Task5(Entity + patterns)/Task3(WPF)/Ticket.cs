using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Runtime.Remoting;
using System.Windows;
using System.Diagnostics;

namespace Task3_WPF_
{
    /// <summary>
    /// Даний клас є реалізацією ViewModel, із патерну MVVM, в даній програмі.
    /// </summary>
     public class Ticket : INotifyPropertyChanged
    {
        /// <summary>
        /// Продукт вибраний на ListView  із запропонованих в SushiesList 
        /// </summary>
        private Product _selectedProduct;
        /// <summary>
        /// Продукт вибраний на ListView  із запропонованих в OrderList 
        /// </summary>
        private Product _selectedOrder;
        private float _totalSum;
        private static string _cashier;
  

        /// <summary>
        /// Змінна для зчитування числа замовлених продуктів із View
        /// </summary>
        public string ProductAmount { get; set; }
        /// <summary>
        /// Змінна для зміни загальної суми на View
        /// </summary>            
        public string TotalSumText { get; set; }
        /// <summary>
        /// Колекція для демонстрації списку запропонованих закладом наборів на View
        /// </summary>
        public ObservableCollection<Product> SushiesList { get; set; }
        /// <summary>
        /// Колекція для демонстрації списку замовлених відвідувачем наборів на View
        /// </summary>
        public ObservableCollection<Product> OrderList { get; set; }

        public static string Cashier
        {
            set
            { _cashier = value;
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).cashierNameLabel.Content = value;
                    }
                }

            }
            get { return _cashier; }
        }
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public Product SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        public Ticket()
        {
            TotalSumText = "0";
            ProductAmount = "1";
            _totalSum = 0;
         
            SushiesList = WorkWithData.GetProducts();
            OrderList = new ObservableCollection<Product>();
            _cashier = "Natasha";
        }

        /// <summary>
        /// Метод, який обчислює загальну суму замовлення
        /// </summary>
        public float calculateTotalSum()
        {
            _totalSum = 0;
            for(int i=0; i< OrderList.Count; i++)
            {
                _totalSum += (OrderList[i].Price * OrderList[i].Quantity);
            }

            TotalSumText = ""+ _totalSum;
            return _totalSum;
        }
        
        private void addOrder()
        {
            bool flag = false;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (OrderList[i].Name == SelectedProduct.Name)
                {
                    OrderList[i].Quantity += 1;
                    flag = true;
                }
            }

            if (flag == false)
            {
                OrderList.Insert(0, SelectedProduct);
            }
            _totalSum += SelectedProduct.Price * Convert.ToInt32(ProductAmount);
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).cashierLabel_value.Content = Convert.ToSingle(_totalSum);
                }
            }
        }
        private void removeOrder()
        {
            if (SelectedOrder != null)
            {
                for (int i = 0; i < OrderList.Count; i++)
                {
                    if (SelectedOrder != null)
                    {
                        if (OrderList[i].Name == SelectedOrder.Name && OrderList[i].Quantity > 1)
                        {
                            OrderList[i].Quantity -= 1;
                            if (_totalSum > 0)
                                _totalSum -= OrderList[i].Price;
                        }
                        else if (OrderList[i].Name == SelectedOrder.Name && OrderList[i].Quantity <= 1)
                        {
                            if (_totalSum > 0)
                                _totalSum -= OrderList[i].Price;
                            OrderList.Remove(SelectedOrder);
                        }
                    }
                }
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).cashierLabel_value.Content = Convert.ToSingle(_totalSum);
                }
            }
        }

        /// <summary>
        /// Команда додає новий об'єкт до списку замовлень
        /// </summary>
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                          addOrder();            
                       }));
            }
        }
        /// <summary>
        /// Команда, яка зменшує кількість, якщо замовлено кілька однакових товарів, або видаляє товар, якщо він один
        /// </summary>
        private RelayCommand removeCommand;     
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                       (removeCommand = new RelayCommand(obj =>
                           {
                               removeOrder();                                                     
                           },
                           (obj) => OrderList.Count > 0));
            }
        }
        /// <summary>
        /// Команда, що виводить чек у разі закінчення опрацювання замовлення
        /// </summary>
        private RelayCommand printTicketCommand;
        public RelayCommand PrintTicketCommand
        {
            get
            {
                return printTicketCommand ??
                       (printTicketCommand = new RelayCommand(obj =>
                       {
                          
                           WorkWithData.WriteCheckInDB(_cashier, calculateTotalSum(), OrderList);
                           MessageBox.Show("Check is printed!");
                       
                       }));
            }
        }
        /// <summary>
        /// Команда для зміни імені касира
        /// </summary>
        private RelayCommand changeKashierNameCommand;
        public RelayCommand ChangeKashierNameCommand
        {
            get
            {
                return changeKashierNameCommand ??
                       (changeKashierNameCommand = new RelayCommand(obj =>
                       {
                           CashierLoginWindow cashierLogin = new CashierLoginWindow();
                           cashierLogin.Owner = App.Current.MainWindow;
                           cashierLogin.Topmost = true;
                           cashierLogin.Show();                    
                       }));
                           
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
