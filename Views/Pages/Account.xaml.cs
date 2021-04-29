using ComputerPeripheralsShop.ViewModels.Account_parts;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            DataContext = new AccountViewModel();
        }
    }
}
