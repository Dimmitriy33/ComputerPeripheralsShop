using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для GamingHeadsets.xaml
    /// </summary>
    public partial class GamingHeadsets : Page
    {
        public GamingHeadsets()
        {
            InitializeComponent();
            DataContext = new HeadsetsViewModel();
        }
    }
}
