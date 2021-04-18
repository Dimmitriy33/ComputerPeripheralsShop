using ComputerPeripheralsShopModel.ViewModels;
using System.Windows;
using System.Windows.Threading;

namespace ComputerPeripheralsShopModel.Views.Windows
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
