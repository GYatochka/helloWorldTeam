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

        public Ticket()
        {
            totalSum = 0;
            Sushies = new ObservableCollection<Product>();
        }

        public float calculateTotalSum()
        {
            for(int i=0; i<Sushies.Count; i++)
            {
                totalSum += Sushies[i].Price;
            }

            return totalSum;
        }
        public ObservableCollection<Product> Sushies { get; set; }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
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
