using ComputerPeripheralsShop.ViewModels;
using System.Windows;
using System.Windows.Threading;

namespace ComputerPeripheralsShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public LoadingWindow()
        {
            InitializeComponent();
            this.DataContext = new LoadingWindowViewModel();
        }



    }
}
