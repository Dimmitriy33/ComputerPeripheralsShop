using ComputerPeripheralsShop.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ComputerPeripheralsShop.Models
{
    public class BasketModel
    {



        public ObservableCollection<Order_List> _order_list;

        public BasketModel()
        {
            Order_list = CurrentOrderList.CurOrderList;
        }
        public ObservableCollection<Order_List> Order_list
        {
            get => _order_list;
            set
            {
                _order_list = value;
                OnPropertyChanged("Order_list");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        //обновление нескольких свойств(например)
        public virtual bool set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value))
                return false;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public ObservableCollection<Order_List> RemoveProduct(int productId)
        {
            Order_List OrderItemToRemove = (from item in this.Order_list
                                            where item.Product_Id == productId
                                            select item).FirstOrDefault();
            ObservableCollection<Order_List> newOrderList = this.Order_list;
            newOrderList.Remove(OrderItemToRemove);
            return newOrderList;
        }

        public decimal TotalPrice()
        {
            // ! - нужно оптимизировать(сейчас лень)
            decimal price = 0;
            foreach (Order_List item in Order_list)
            {
                using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
                {
                    price += (from product in context.Product
                              where product.Product_Id == item.Product_Id
                              select product.Price).Single<decimal>();
                }
            }
            return price;
        }
    }
}
