using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Application = System.Windows.Application;

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
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("SoloCast")
                                                                                        select product).Single<Product>();
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
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = (from product in context.Product
                                                                                        where product.Model.Equals("QuadCast")
                                                                                        select product).Single<Product>();
                    }
                }
            }
        }

        /*private ObservableCollection<Product> _microphones;
        public ObservableCollection<Product> Microphones { get => this._microphones; set => this._microphones = value; }

        public MicrophonesViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Microphones = unitOfWork.ProductRepository.getMicrophones();
            }
        }*/

    }
}
