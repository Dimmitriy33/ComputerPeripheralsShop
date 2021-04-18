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
        public ICommand LanguageCommand { get; }
        public ICommand ThemeCommand { get; }
        public ICommand LoginCommand { get; }

        public int ResizeCommand_ClickCount { get; set; }

        public TopRightToolBarViewModel()
        {
            CloseCommand = new CommandViewModel(ExecuteClose);
            ResizeCommand = new CommandViewModel(ExecuteResize);
            CollapseCommand = new CommandViewModel(ExecuteCollapse);
            LanguageCommand = new CommandViewModel(ExecuteLanguage);
            ThemeCommand = new CommandViewModel(ExecuteTheme);
            LoginCommand = new CommandViewModel(ExecuteLogin);
        }

        private void ExecuteLogin()
        {
            Window loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void ExecuteTheme()
        {
        }

        private void ExecuteLanguage()
        {
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

        public void ExecuteClose()
        {
            Application.Current.Shutdown();
        }
    }
}
