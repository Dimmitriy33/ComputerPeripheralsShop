using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels
{
    internal class BasketViewModel : ViewModel
    {
        public ICommand NewOrderCommand { get; }
        public ICommand RemoveItemCommand { get; }

        public BasketModel basket;
        public decimal _totalPrice;

        public BasketViewModel()
        {
            basket = new BasketModel();
            NewOrderCommand = new CommandViewModel(executeNewOrder);
            RemoveItemCommand = new RelayCommand(executeRemoveItem);
            _totalPrice = basket.TotalPrice();
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public ObservableCollection<Order_List> Order_list
        {
            get => basket.Order_list;
            set
            {
                basket.Order_list = value;
                OnPropertyChanged("Order_list");
            }
        }

        private void executeRemoveItem(object id)
        {
            Order_list = basket.RemoveProduct((int)id);
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                TotalPrice -= (from product in context.Product
                               where product.Product_Id == (int)id
                               select product.Price).Single<decimal>();
            }
        }
        private void executeNewOrder()
        {
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                if (ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Balance >= basket.TotalPrice())
                {
                    foreach (Order_List list in Order_list)
                    {
                        Product NewProduct = (from product in context.Product
                                              where product.Product_Id == list.Product_Id
                                              select product).Single<Product>();
                        context.Product.Find(NewProduct).Number_on_warehouse = NewProduct.Number_on_warehouse - 1;
                        context.Order_List.Add(new Order_List(list.Product_Id, list.Order_Id, list.Order_List_Id));
                    }
                    context.Order.Add(new Order(ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.User_Id, DateTime.Now, basket.TotalPrice(), Order_list.Count));

                    context.SaveChanges();
                    MessageBox.Show("successfully acquired");
                }
                else
                {
                    MessageBox.Show("Not enough funds for the order");

                }

            }
        }
    }
}
