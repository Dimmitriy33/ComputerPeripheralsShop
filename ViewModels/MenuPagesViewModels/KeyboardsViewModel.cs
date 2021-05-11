using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class KeyboardsViewModel : ViewModel
    {
        public ObservableCollection<Product> Keyboards { get; set; }

        public ICommand Info_Button { get; }

        public KeyboardsViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Keyboards = new ObservableCollection<Product>(unitOfWork.ProductRepository.GetKeyboards());
            }
            Info_Button = new RelayCommand(executeInfo);
        }

        private void executeInfo(object obj)
        {
            MainFrameNavigator.FrameNavigator("Views/Pages/", "Product");
            using (UnitOfWork context = new UnitOfWork())
            {
                ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = context.ProductRepository.GetProductById((int)obj);
            }
        }
    }
}
