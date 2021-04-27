using ComputerPeripheralsShop.ViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        public Basket()
        {
            InitializeComponent();
            this.DataContext = new BasketViewModel();
        }
    }
}
