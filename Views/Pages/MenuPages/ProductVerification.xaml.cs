using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для ProductVerification.xaml
    /// </summary>
    public partial class ProductVerification : Page
    {
        public ProductVerification()
        {
            InitializeComponent();
            this.DataContext = new ProductVerificationViewModel();
        }
    }
}
