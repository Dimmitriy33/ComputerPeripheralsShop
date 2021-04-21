using ComputerPeripheralsShop.ViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModel();
        }
    }
}
