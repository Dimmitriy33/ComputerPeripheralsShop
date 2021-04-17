using ComputerPeripheralsShop.ViewModels;
using System.Windows;

namespace ComputerPeripheralsShop.Views.Windows
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
