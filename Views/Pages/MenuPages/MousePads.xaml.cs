using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
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
