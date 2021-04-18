using ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views.Pages.MenuPages
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
