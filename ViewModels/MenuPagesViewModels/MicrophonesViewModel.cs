using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicrophonesViewModel : ViewModel
    {
        public ObservableCollection<Product> Microphones { get; set; }

        public ICommand Info_Button { get; }

        public MicrophonesViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Microphones = new ObservableCollection<Product>(unitOfWork.ProductRepository.getMicrophones());
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
