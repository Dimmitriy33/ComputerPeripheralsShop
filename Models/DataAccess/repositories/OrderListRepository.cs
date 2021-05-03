using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System.Linq;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class OrderListRepository : Repository<Order_List>, IOrderListRepository
    {
        public ComputerPeripheralsShopEntities context => _context as ComputerPeripheralsShopEntities;
        public OrderListRepository(ComputerPeripheralsShopEntities context) : base(context)
        {

        }

        public string ProductFullName(int Product_Id) => (from product in context.Product
                                                          where product.Product_Id.Equals(Product_Id)
                                                          select product.Manufacturer).Single() + " " +
                                                        (from product in context.Product
                                                         where product.Product_Id.Equals(Product_Id)
                                                         select product.Model).Single();
    }
}
