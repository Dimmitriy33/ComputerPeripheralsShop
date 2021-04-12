using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
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
