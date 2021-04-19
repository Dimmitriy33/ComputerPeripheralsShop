using ComputerPeripheralsShop.ViewModels.Account_parts;
using System.Windows;

namespace ComputerPeripheralsShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public CreateAccountWindow()
        {
            InitializeComponent();
            this.DataContext = new CreateAccountViewModel();
        }
    }
}
