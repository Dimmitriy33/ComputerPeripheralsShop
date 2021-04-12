using System;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class ReturnPolicyViewModel
    {
        public ICommand ToContacts { get; }

        public ReturnPolicyViewModel()
        {
            ToContacts = new CommandViewModel(executeToContacts);
        }

        private void executeToContacts()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/MenuPages/", "Contacts", ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}
