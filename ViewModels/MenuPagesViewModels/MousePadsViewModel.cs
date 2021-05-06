using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MousePadsViewModel : ViewModel
    {
        private ObservableCollection<Product> _mousePads;
        public ObservableCollection<Product> MousePads { get => this._mousePads; set => this._mousePads = value; }

        public ICommand Info_Button { get; }

        public MousePadsViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                MousePads = unitOfWork.ProductRepository.getMousePads();
            }
            Info_Button = new RelayCommand(executeInfo);
        }

        private void executeInfo(object obj)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (UnitOfWork context = new UnitOfWork())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = context.ProductRepository.getProductById((int)obj);
                    }
                }
            }
        }
    }
}
