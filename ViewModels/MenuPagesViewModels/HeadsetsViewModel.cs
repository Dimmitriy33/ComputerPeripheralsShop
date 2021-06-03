using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class HeadsetsViewModel : ViewModel
    {
        public ObservableCollection<Product> Headsets { get; set; }

        public ICommand Info_Button { get; }

        public HeadsetsViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Headsets = new ObservableCollection<Product>(unitOfWork.ProductRepository.GetGamingHeadsets());
                // add this commit for test
                // add this commit for test 2
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
