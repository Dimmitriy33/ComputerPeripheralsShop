using ComputerPeripheralsShop;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicesViewModel : ViewModel
    {
        public ICommand Haste_InfoButton { get; }
        public ICommand Surge_InfoButton { get; }
        public ICommand Core_InfoButton { get; }
        public ICommand G305_InfoButton { get; }

        public MicesViewModel()
        {
            // лучше одну команду сделать, которая будет вызывать метод который будет открывать новую страницу в которую передается объект продукта
            Haste_InfoButton = new CommandViewModel(ExecuteHaste);
            Surge_InfoButton = new CommandViewModel(ExecuteSurge);
            Core_InfoButton = new CommandViewModel(ExecuteCore);
            G305_InfoButton = new CommandViewModel(ExecuteG305);
        }

        private void ExecuteG305()
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
                                                                                        where product.Model.Equals("G 305")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteCore()
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
                                                                                        where product.Model.Equals("Pulsefire Core RGB")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteSurge()
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
                                                                                        where product.Model.Equals("Pulsefire Surge RGB")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void ExecuteHaste()
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
                                                                                        where product.Model.Equals("Pulsefire Haste")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }
    }
}
