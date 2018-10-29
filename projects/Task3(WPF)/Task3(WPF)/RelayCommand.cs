using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task3_WPF_
{
    class RelayCommand: ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        /// <summary>
        /// overriding EventHandler form ICommand
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// overriding RelayCommand form ICommand
        /// </summary>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        /// <summary>
        /// overriding CanExecute form ICommand
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        /// <summary>
        /// overriding Execute form ICommand
        /// </summary>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
