using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces.@base;

namespace ComputerPeripheralsShop.Models.DataAccess.interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        // новые методы для order-a
    }
}
