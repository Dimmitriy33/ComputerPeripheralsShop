using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();

            var MenuProductsSub = new List<SubItem> {
                new SubItem("Gaming Headsets"),
                new SubItem("Microphones"),
                new SubItem("Keyboards"),
                new SubItem("Mice"),
                new SubItem("Mouse Pads")
            };

            var MenuSupportSub = new List<SubItem> {
                new SubItem("Product Verification"),
                new SubItem("Return Policy")
            };

            var MenuShopsSub = new List<SubItem>() {
                new SubItem("Russia"),
                new SubItem("Belarus"),
                new SubItem("Ukraine")
            };

            var MenuContactsSub = new List<SubItem>() {
                new SubItem("Contacts")
            };

            var MenuInfoAboutUsSub = new List<SubItem>() {
                new SubItem("About us"),
                new SubItem("Cooperation"),
            };

            var MenuProduct = new ItemMenu("Products", PackIconKind.Devices, MenuProductsSub);
            var MenuSupport = new ItemMenu("Support", PackIconKind.Support, MenuSupportSub);
            var MenuShops = new ItemMenu("Shops", PackIconKind.Shop, MenuShopsSub);
            var MenuContacts = new ItemMenu("Contacts", PackIconKind.Contact, MenuContactsSub);
            var MenuInfo = new ItemMenu("Info", PackIconKind.AboutCircleOutline, MenuInfoAboutUsSub);

            /*var MenuContacts = new ItemMenu("Contacts", PackIconKind.Contact, new UserControl());
             var MenuInfoAboutUs = new ItemMenu("About us", PackIconKind.AboutCircleOutline, new UserControl());*/

            MenuPanel.Children.Add(new MenuBarItem(MenuProduct));
            MenuPanel.Children.Add(new MenuBarItem(MenuSupport));
            MenuPanel.Children.Add(new MenuBarItem(MenuShops));
            MenuPanel.Children.Add(new MenuBarItem(MenuContacts));
            MenuPanel.Children.Add(new MenuBarItem(MenuInfo));
        }
    }
}
