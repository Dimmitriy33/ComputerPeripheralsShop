using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для Microphones.xaml
    /// </summary>
    public partial class Microphones : Page
    {
        public Microphones()
        {
            InitializeComponent();
            this.DataContext = new MicrophonesViewModel();

        }
    }
}
