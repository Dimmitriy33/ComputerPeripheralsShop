using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces.@base;

namespace ComputerPeripheralsShop.Models.DataAccess.interfaces
{
    public interface IOrderListRepository : IRepository<Order_List>
    {
        string ProductFullName(int Product_Id);
    }
}
