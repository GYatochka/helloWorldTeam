using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Task3_WPF_
{
    /// <summary>
    /// This class is viewmodel realization in our program.
    /// </summary>
    class Ticket : INotifyPropertyChanged
    {
        private Product _selectedProduct;
        private float totalSum;
        private string _cashier;

        public ObservableCollection<Product> SushiesList { get; set; }
        public ObservableCollection<Product> selectedSushiesList { get; set; }

        public Ticket()
        {
            totalSum = 0;
            Sushies = new ObservableCollection<Product>();
            _cashier = "Natasha";
        }
        public string Cashier
        {
            set { _cashier = value; }get { return _cashier; }
        }
        public float calculateTotalSum()
        {
            for(int i=0; i<Sushies.Count; i++)
            {

                totalSum += (Sushies[i].Price * Sushies[i].Quantity);

                totalSum += SushiesList[i].Price;

            }

            return totalSum;
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

        public Ticket()
        {

        }
        /// <summary>
        /// command add new object to the selected shushi list
        /// </summary>
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           Product product = new Product();
                           selectedSushiesList.Insert(0, product);
                           SelectedProduct = product;
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
