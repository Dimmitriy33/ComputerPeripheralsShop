using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces.@base;

namespace ComputerPeripheralsShop.Models.DataAccess.interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // новые методы для user-a
        User GetUserByUsername(string username);

    }
}
