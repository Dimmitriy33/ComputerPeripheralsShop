using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public ComputerPeripheralsShopEntities context => _context as ComputerPeripheralsShopEntities;
        public OrderRepository(ComputerPeripheralsShopEntities context) : base(context)
        {

        }

    }
}
