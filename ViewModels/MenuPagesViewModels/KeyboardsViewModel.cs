using ComputerPeripheralsShop;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class KeyboardsViewModel : ViewModel
    {
        public ICommand AlloyCore_InfoButton { get; }
        public ICommand AlloyElite_InfoButton { get; }
        public ICommand AlloyOrigins_InfoButton { get; }
        public ICommand ProX_InfoButton { get; }

        public KeyboardsViewModel()
        {
            AlloyCore_InfoButton = new CommandViewModel(executeAlloyCore);
            AlloyElite_InfoButton = new CommandViewModel(executeAlloyElite);
            AlloyOrigins_InfoButton = new CommandViewModel(executeAlloyOrigins);
            ProX_InfoButton = new CommandViewModel(executeProX);
        }

        private void executeProX()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("PRO X")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void executeAlloyOrigins()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("Alloy Origins 60")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void executeAlloyElite()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("Alloy Elite 2")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void executeAlloyCore()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("Alloy Core RGB")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }
    }
}
