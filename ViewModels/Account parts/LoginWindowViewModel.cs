using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel.Models.Authentication;
using ComputerPeripheralsShopModel.ViewModels.Base;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class LoginWindowViewModel : ViewModel
    {
        private string _username = "";
        private string _password = "";
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

        public ICommand LoginCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand MoveToCreateAccountCommand { get; }

        public LoginWindowViewModel()
        {
            LoginCommand = new CommandViewModel(executeLogin);
            CloseCommand = new CommandViewModel(ExecuteClose);
            MoveToCreateAccountCommand = new CommandViewModel(ExecuteMoveToCreateAccountCommand);
        }

        private void ExecuteMoveToCreateAccountCommand()
        {
            CloseLoginWindow();
            OpenCreateAccountWindow();
        }

        private void executeLogin() => Account.Login(Username, Password);

        public void ExecuteClose() => CloseLoginWindow();

        private void CloseLoginWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(LoginWindow))
                {
                    (window as LoginWindow).Hide();
                    (window as LoginWindow).Close();
                }
            }
        }

        private void OpenCreateAccountWindow()
        {
            Window createAccWindow = new CreateAccountWindow();
            createAccWindow.Show();
        }
    }
}
