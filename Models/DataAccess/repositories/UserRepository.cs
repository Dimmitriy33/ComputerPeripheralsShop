using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public ComputerPeripheralsShopEntities AppContext => _context as ComputerPeripheralsShopEntities;

        public UserRepository(ComputerPeripheralsShopEntities context) : base(context)
        {
        }
    }
}
