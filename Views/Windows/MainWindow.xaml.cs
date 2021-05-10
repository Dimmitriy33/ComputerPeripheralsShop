using ComputerPeripheralsShop.Helpers;
using System.Windows;

namespace ComputerPeripheralsShopModel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrameNavigator.FrameNavigator("Views/Pages/MenuPages/", "AboutUs");
        }
    }
}
