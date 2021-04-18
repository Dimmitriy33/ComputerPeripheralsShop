using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для Keyboards.xaml
    /// </summary>
    public partial class Keyboards : Page
    {
        public Keyboards()
        {
            InitializeComponent();
            this.DataContext = new KeyboardsViewModel();
        }
    }
}
