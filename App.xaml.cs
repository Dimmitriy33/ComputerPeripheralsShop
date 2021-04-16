using ComputerPeripheralsShop.Views.Windows;
using System.Windows;

namespace ComputerPeripheralsShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            base.OnStartup(e);
        }
    }
}
