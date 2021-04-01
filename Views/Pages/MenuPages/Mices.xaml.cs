using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для Mices.xaml
    /// </summary>
    public partial class Mices : Page
    {
        public Mices()
        {
            InitializeComponent();
            this.DataContext = new MicesViewModel();
        }
    }
}
