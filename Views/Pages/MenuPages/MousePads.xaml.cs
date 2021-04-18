using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для MousePads.xaml
    /// </summary>
    public partial class MousePads : Page
    {
        public MousePads()
        {
            InitializeComponent();
            this.DataContext = new MousePadsViewModel();
        }
    }
}
