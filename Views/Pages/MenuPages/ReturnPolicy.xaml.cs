using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
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
