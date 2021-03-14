using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Controls.Menu

{
    public class ItemMenu
    {
        public ItemMenu(string itemName, PackIconKind icon, List<SubItem> subItems)
        {
            this.ItemName = itemName;
            this.Icon = icon;
            this.SubItems = subItems;
        }

        public ItemMenu(string itemName, PackIconKind icon, UserControl screen)
        {
            this.ItemName = itemName;
            this.Screen = screen;
            this.Icon = icon;
        }

        public string ItemName { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }
    }

}

