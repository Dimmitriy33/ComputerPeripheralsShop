using System;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class CommandViewModel : ICommand
    {
        private readonly Action _action;

        public CommandViewModel(Action action)
        {
            _action = action;
        }

        public void Execute(object obj)
        {
            _action();
        }

        public bool CanExecute(object obj)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}