using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task3_WPF_
{
    /// <summary>
    /// Даний клас є реалізацією Model, із патерну MVVM, в даній програмі.
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private float _price;
        private int _quantity;

        public int Quantity
        {
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
            get { return _quantity; }
        }
        public string Name
        {
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
            get { return _name; }
        }
        public float Price
        {
            set
            {
                if (value > 0)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
                else
                {
                    throw new Exception("Invalid value!");
                }
            }

            get { return _price; }
        }

        public Product()
        {
            _name = "";
            _price = 0;
            _quantity = 1;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return "Name: "+ _name + '\t' + "x"+_quantity + '\t' + "\tPrice: " + _price;
        }
    }
}
