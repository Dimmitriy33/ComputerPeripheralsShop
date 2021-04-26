using ComputerPeripheralsShop.ViewModels.Menu_parts;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views
{
    /// <summary>
    /// Логика взаимодействия для BasketToolBar.xaml
    /// </summary>
    public partial class BasketToolBar : UserControl
    {
        public BasketToolBar()
        {
            InitializeComponent();
            this.DataContext = new BaksetToolBarViewModel();
        }
    }
}
