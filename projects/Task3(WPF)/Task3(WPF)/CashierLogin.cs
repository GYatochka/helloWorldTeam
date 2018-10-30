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
        private string cashierName;
        public Action CloseAction { get; set; } //для закриття вікна CashierLoginWindow
        public string CashierName
        {
            get { return cashierName; }
            set
            {
                cashierName = value;
                OnPropertyChanged("CashierName");
              
            }
        }
      
        private RelayCommand addName;
        /// <summary>
        /// Командає пересилає ім'я Касира в клас Ticket
        /// </summary>
        public RelayCommand AddName
        {
            get
            {
                return addName ??
                       (addName = new RelayCommand(obj => {
                                    
                                     Ticket.Cashier = CashierName;
                           CloseAction();
                       }));
            }
        }
        private RelayCommand cancelCommand;
        /// <summary>
        /// Командає cancel, яка закриває вікно
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                       (cancelCommand = new RelayCommand(obj => {
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
