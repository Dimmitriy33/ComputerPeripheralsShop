using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для ReturnPolicy.xaml
    /// </summary>
    public partial class ReturnPolicy : Page
    {
        public ReturnPolicy()
        {
            InitializeComponent();
            this.DataContext = new ReturnPolicyViewModel();
        }
    }
}
