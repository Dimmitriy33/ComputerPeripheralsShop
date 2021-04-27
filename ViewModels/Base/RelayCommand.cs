using System;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

}
