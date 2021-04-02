using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
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
