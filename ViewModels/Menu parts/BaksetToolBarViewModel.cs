using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.Menu_parts
{
    internal class BaksetToolBarViewModel : ViewModel
    {
        private int product_id;
        public int Product_Id
        {
            get => product_id;
            set
            {
                product_id = value;
                OnPropertyChanged("Product_Id");
            }
        }

        public ICommand RemoveProductButton { get; }

        public BaksetToolBarViewModel()
        {
            this.RemoveProductButton = new CommandViewModel(executeRemoveButton);
        }

        private void executeRemoveButton()
        {
            ObservableCollection<Order_List> curOrderList = CurrentOrderList.CurOrderList;
            curOrderList.Remove(curOrderList.Where(i => i.Product_Id == Product_Id).Single());
            CurrentOrderList.CurOrderList = curOrderList;
        }
    }
}
