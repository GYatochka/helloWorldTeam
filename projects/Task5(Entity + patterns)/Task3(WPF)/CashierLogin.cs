using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Task3_WPF_
{
    class CashierLogin : INotifyPropertyChanged
    {
        private string _cashierName;

        /// <summary>
        /// для закриття вікна CashierLoginWindow
        /// </summary>
        public Action CloseAction { get; set; } 
        public string CashierName
        {
            get { return _cashierName; }
            set
            {
                _cashierName = value;
                OnPropertyChanged("CashierName");              
            }
        }

        /// <summary>
        /// Командає пересилає ім'я Касира в клас Ticket
        /// </summary>
        private RelayCommand addName;      
        public RelayCommand AddName
        {
            get
            {
                return addName ??
                       (addName = new RelayCommand(obj => 
                       {                                  
                           Ticket.Cashier = CashierName;
                           CloseAction();
                       }));
            }
        }
        /// <summary>
        /// Командає cancel, яка закриває вікно
        /// </summary>
        private RelayCommand cancelCommand;      
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                       (cancelCommand = new RelayCommand(obj => 
                       {
                          CloseAction();
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
