using ComputerPeripheralsShopModel.ViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShopModel.Views
{
    /// <summary>
    /// Логика взаимодействия для TopRightToolBar.xaml
    /// </summary>
    public partial class TopRightToolBar : UserControl
    {
        public TopRightToolBar()
        {
            InitializeComponent();
            this.DataContext = new TopRightToolBarViewModel();
        }
    }
}
