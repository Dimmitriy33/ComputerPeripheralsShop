using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShopModel.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class SideMenuViewModel : ViewModel
    {
        public List<ItemMenu> MenuList => new List<ItemMenu>
                {
                    //Prodeucts
                    new ItemMenu("Products", PackIconKind.Devices,
                        new List<SubItem>
                        {
                            new SubItem("Gaming Headsets"),
                            new SubItem("Microphones"),
                            new SubItem("Keyboards"),
                            new SubItem("Mices"),
                            new SubItem("Mouse Pads")
                        }),

                    //Support
                    new ItemMenu("Support", PackIconKind.Support,
                        new List<SubItem>
                        {
                            new SubItem("Product Verification"),
                            new SubItem("Return Policy")
                         }),

                    //Shops
                    new ItemMenu("Shops", PackIconKind.Shop,
                        new List<SubItem>
                        {
                            new SubItem("Russia"),
                            new SubItem("Belarus"),
                            new SubItem("Ukraine"),
                        }),

                    //Contacts
                    new ItemMenu("Contacts", PackIconKind.Contact, new List<SubItem> { new SubItem("Contacts")}),

                    //Info
                    new ItemMenu("Info", PackIconKind.AboutCircleOutline, new List<SubItem>
                    {
                         new SubItem("About us"),
                        new SubItem("Cooperation")
                    })
                };
    }

    public class ItemMenu
    {
        public ItemMenu(string itemName, PackIconKind icon, List<SubItem> subItems)
        {
            /* MoveToMenuPageCommand = new CommandViewModel(Execute);*/
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

    public class SubItem
    {
        public SubItem(string SubName, UserControl screen = null)
        {
            MoveToMenuPageCommand = new CommandViewModel(Execute);
            this.SubName = SubName;
            this.Screen = screen;
        }
        public string SubName { get; private set; }
        public UserControl Screen { get; private set; }

        public ICommand MoveToMenuPageCommand { get; }
        private void Execute()
        {
            string PageName = SubName.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(PageName))
                navigateToPage(PageName);
        }

        private void navigateToPage(string SubName) => MainFrameNavigator.FrameNavigator("Views/Pages/MenuPages/", SubName);
    }
}