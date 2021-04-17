﻿using ComputerPeripheralsShop.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels
{
    internal class SideMenuViewModel : ViewModel
    {
        public List<ItemMenu> MenuList
        {
            get
            {
                return new List<ItemMenu>
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
        }
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

        //ICommand to switch pages 

        /*public ICommand MoveToMenuPageCommand { get; }
        private void Execute()
        {
            string PageName = ItemName.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(PageName))
                navigateToPage(PageName);
        }

        private void navigateToPage(string name)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(name, UriKind.RelativeOrAbsolute));
                    *//*(window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}","Pages/", name, ".xaml"), UriKind.RelativeOrAbsolute));*//*

                }
            }
        }*/
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

        private void navigateToPage(string SubName)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/MenuPages/", SubName, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }




    }
}