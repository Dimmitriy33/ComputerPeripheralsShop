using ComputerPeripheralsShop;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MousePadsViewModel : ViewModel
    {
        public ICommand FurySPro_InfoButton { get; }
        public ICommand FuryUltra_InfoButton { get; }

        public MousePadsViewModel()
        {
            FurySPro_InfoButton = new CommandViewModel(executeFurySPro);
            FuryUltra_InfoButton = new CommandViewModel(executeFuryUltra);
        }

        private void executeFuryUltra()
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
                                                                                        where product.Model.Equals("FURY Ultra")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        private void executeFurySPro()
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
                                                                                        where product.Model.Equals("FURY S Pro")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }
    }
}
