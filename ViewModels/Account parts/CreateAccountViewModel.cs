using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel.Models.Authentication;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.Account_parts
{
    internal class CreateAccountViewModel : ViewModel
    {
        ComputerPeripheralsShopEntities computerPeripheralsShopEntities = new ComputerPeripheralsShopEntities();
        private string _username = "";
        private string _password = "";
        private string _name = "";
        private string _surname = "";
        private string _address = "";
        private bool _agree = false;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public bool Agree
        {
            get => _agree;
            set
            {
                _agree = value;
                OnPropertyChanged(nameof(Agree));
            }
        }

        public ICommand CreateAccountCommand { get; }
        public ICommand MoveToLoginCommand { get; }
        public ICommand CloseCommand { get; }

        public CreateAccountViewModel()
        {
            CreateAccountCommand = new CommandViewModel(executeCreateAccount);
            CloseCommand = new CommandViewModel(ExecuteClose);
            MoveToLoginCommand = new CommandViewModel(executeMoveToLogin);
        }

        private void executeMoveToLogin()
        {
            CloseCreateAccountWindow();
            OpenLoginWindow();
        }

        public void ExecuteClose() => CloseCreateAccountWindow();

        private void executeCreateAccount()
        {
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                Account.CreateAccount(_agree, Username, Password, Name, Surname, Address);
            }

        }

        private void CloseCreateAccountWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(CreateAccountWindow))
                {
                    (window as CreateAccountWindow).Hide();
                    (window as CreateAccountWindow).Close();
                }
            }
        }

        private void OpenLoginWindow()
        {
            Window loginAccWindow = new LoginWindow();
            loginAccWindow.Show();
        }

    }
}
