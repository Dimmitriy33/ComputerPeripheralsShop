using ComputerPeripheralsShopModel.ViewModels;
using System.Windows;

namespace ComputerPeripheralsShopModel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginWindowViewModel();
        }
    }
}
