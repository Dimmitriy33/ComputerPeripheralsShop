using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel.Models.Authentication;
using ComputerPeripheralsShopModel.ViewModels.Base;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class TopRightToolBarViewModel : ViewModel
    {
        public ICommand CloseCommand { get; }
        public ICommand ResizeCommand { get; }
        public ICommand CollapseCommand { get; }
        public ICommand AccountCommand { get; }
        public ICommand ThemeCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand BasketCommand { get; }

        public int ResizeCommand_ClickCount { get; set; }

        public TopRightToolBarViewModel()
        {
            CloseCommand = new CommandViewModel(ExecuteClose);
            ResizeCommand = new CommandViewModel(ExecuteResize);
            CollapseCommand = new CommandViewModel(ExecuteCollapse);
            AccountCommand = new CommandViewModel(ExecuteAccount);
            ThemeCommand = new CommandViewModel(ExecuteTheme);
            LoginCommand = new CommandViewModel(ExecuteLogin);
            CreateAccountCommand = new CommandViewModel(ExecuteCreateAccount);
            BasketCommand = new CommandViewModel(ExecuteBasketCommand);
        }

        private void ExecuteBasketCommand() => MainFrameNavigator.FrameNavigator("Views/Pages/", "Basket");

        private void ExecuteCreateAccount()
        {
            Window createAcc = new CreateAccountWindow();
            createAcc.Show();
        }

        private void ExecuteLogin()
        {
            if (!Account.IsLoggedIn)
            {
                Window loginWindow = new LoginWindow();
                loginWindow.Show();
            }
            else
            {
                // notifier
            }
        }

        private void ExecuteTheme()
        {
        }

        private void ExecuteAccount()
        {
            if (Account.curUser != null)
                MainFrameNavigator.FrameNavigator("Views/Pages/", "Account");
            else
            {
                Window loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }

        private void ExecuteCollapse()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                }
            }
        }

        private void ExecuteResize()
        {
            ++ResizeCommand_ClickCount;
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    if (ResizeCommand_ClickCount % 2 == 1)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;

                    }
                    else if (ResizeCommand_ClickCount % 2 == 0)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                        Application.Current.MainWindow.Height = 800;
                        Application.Current.MainWindow.Width = 1200;
                    }
                }
            }
        }

        public void ExecuteClose() => Application.Current.Shutdown();
    }
}
