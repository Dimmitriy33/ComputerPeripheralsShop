using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для Cooperation.xaml
    /// </summary>
    public partial class Cooperation : Page
    {
        public Cooperation()
        {
            InitializeComponent();
            this.DataContext = new CooperationViewModel();
        }
    }
}
