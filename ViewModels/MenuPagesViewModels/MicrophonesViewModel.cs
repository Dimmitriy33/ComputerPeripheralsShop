using ComputerPeripheralsShop;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicrophonesViewModel : ViewModel
    {
        public ICommand QuadCast_InfoButton { get; }
        public ICommand SoloCast_InfoButton { get; }

        public MicrophonesViewModel()
        {
            this.QuadCast_InfoButton = new CommandViewModel(ExecuteQuadCast);
            this.SoloCast_InfoButton = new CommandViewModel(ExecuteSoloCast);
        }

        private void ExecuteSoloCast()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        foreach (var el in context.Product)
                        {
                            if (el.Model.Equals("SoloCast"))
                                ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = el;
                        }

                    }
                }
            }
        }

        private void ExecuteQuadCast()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    /*(window as MainWindow).MainWindowFrame.Navigate(new Uri(SubName, UriKind.RelativeOrAbsolute));*/
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        foreach (var el in context.Product)
                        {
                            if (el.Model.Equals("QuadCast"))
                                ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = el;
                        }

                    }
                }
            }
        }

    }
}
