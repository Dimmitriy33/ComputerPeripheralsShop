using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class HeadsetsViewModel : ViewModel
    {

        public ICommand Revolver_InfoButton { get; }
        public ICommand Stinger_InfoButton { get; }
        public ICommand Cloud2_InfoButton { get; }
        public ICommand ProX_InfoButton { get; }
        public HeadsetsViewModel()
        {
            Revolver_InfoButton = new CommandViewModel(ExecuteRevolver);
            Stinger_InfoButton = new CommandViewModel(ExecuteStinger);
            Cloud2_InfoButton = new CommandViewModel(ExecuteCloud2);
            ProX_InfoButton = new CommandViewModel(ExecuteProX);
        }

        private void ExecuteProX()
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
                                                                                        where product.Model.Equals("Pro X") && product.Category.Equals("Gaming Headsets")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteCloud2()
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
                                                                                        where product.Model.Equals("Cloud 2 Wireless")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteStinger()
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
                                                                                        where product.Model.Equals("Cloud Stinger Core Wireless")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteRevolver()
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
                                                                                        where product.Model.Equals("Cloud Revolver")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }
    }
}
