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
        public  string CashierName { set; get; }
        private RelayCommand addName;
        // Дописати команду, щоб пересилала ім'я в головне вікно й закривала вікно логування,
        // а також написати логіку для кнопки відміни
        public RelayCommand AddName
        {
            get
            {
                return addName ??
                       (addName = new RelayCommand(obj => { Ticket.Cashier = CashierName; }));
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
