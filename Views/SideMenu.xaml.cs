using ComputerPeripheralsShopModel.ViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views
{
    /// <summary>
    /// Логика взаимодействия для SideMenu.xaml
    /// </summary>
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
            DataContext = new SideMenuViewModel();
        }

    }
}
