using System.Windows;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для MenuBar.xaml
    /// </summary>
    public partial class MenuBarItem : UserControl
    {
        public MenuBarItem(ItemMenu itemMenu)
        {
            InitializeComponent();
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;

            this.DataContext = itemMenu;
        }
    }
}
