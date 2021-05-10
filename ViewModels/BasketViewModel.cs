using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.Models.Authentication;
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
            using (UnitOfWork context = new UnitOfWork())
            {
                TotalPrice -= (from product in context.ProductRepository.AppContext.Product
                               where product.Product_Id == (int)id
                               select product.Price).Single<decimal>();
            }
        }
        private void executeNewOrder()
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                if (Account.curUser.Balance >= basket.TotalPrice())
                {
                    foreach (Order_List list in Order_list)
                    {
                        context.ProductRepository.AppContext.Product.Where(p => p.Product_Id == list.Product_Id).Single().Number_on_warehouse -= 1;
                        context.ProductRepository.AppContext.Order_List.Add(new Order_List(list.Product_Id, list.Order_Id, list.Order_List_Id));
                    }
                    context.ProductRepository.AppContext.Order.Add(new Order(Account.curUser.User_Id, Order_list.FirstOrDefault().Order_Id, DateTime.Now, basket.TotalPrice(), Order_list.Count));
                    context.UserRepository.Reducebalance(Account.curUser.User_Id, basket.TotalPrice());
                    context.SaveChanges();
                    Order_list.Clear();
                    CurrentOrderList.CurOrderList.Clear();
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
