using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.Models.DataAccess.repositories;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ComputerPeripheralsShop.ViewModels
{
    internal class ProductViewModel : ViewModel
    {
        public ICommand BuyCommand { get; }

        public ProductViewModel()
        {
            BuyCommand = new CommandViewModel(executeBuyCommand);
        }


        public int Product_Id => CurrentProduct.currentProduct.Product_Id;

        public int Number_on_warehouse
        => CurrentProduct.currentProduct.Number_on_warehouse;
        public string Model
        => CurrentProduct.currentProduct.Model;
        public BitmapImage Picture_Main
        => ImageConverters.ImageFromBytearray(CurrentProduct.currentProduct.Picture_Main);
        public ImageSource Picture1
        => ImageConverters.ImageFromBytearray(CurrentProduct.currentProduct.Picture1);

        public ImageSource Picture2
        => ImageConverters.ImageFromBytearray(CurrentProduct.currentProduct.Picture2);

        public string ProductFullName
        => CurrentProduct.currentProduct.Manufacturer + " " + Model;

        public string Description
        => CurrentProduct.currentProduct.Description;

        public List<ProductRepository.Specifications> SpecificationsList
        {
            get
            {
                using (UnitOfWork context = new UnitOfWork())
                {
                    return context.ProductRepository.AddSpec();
                }
            }
        }

        public ObservableCollection<Order_List> order_Lists
        {
            get => CurrentOrderList.CurOrderList;
            set => CurrentOrderList.CurOrderList = value;
        }

        private void executeBuyCommand()
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                int count_of_orders = context.OrderRepository.context.Order.Count();
                ObservableCollection<Order_List> curOrderList = CurrentOrderList.CurOrderList;
                CurrentOrderList.CurOrderList.Add(new Order_List(Product_Id, count_of_orders, CurrentOrderList.CurOrderList.Count));
                CurrentOrderList.CurOrderList = curOrderList;
            }

        }

    }
}
