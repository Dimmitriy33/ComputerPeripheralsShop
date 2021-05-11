using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicesViewModel : ViewModel
    {
        public ObservableCollection<Product> Mices { get; set; }

        public ICommand Info_Button { get; }

        public MicesViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Mices = new ObservableCollection<Product>(unitOfWork.ProductRepository.GetMices());
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
