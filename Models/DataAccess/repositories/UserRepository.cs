using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System.Linq;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public ComputerPeripheralsShopEntities AppContext => _context as ComputerPeripheralsShopEntities;

        public UserRepository(ComputerPeripheralsShopEntities context) : base(context)
        {
        }

        public User GetUserByUsername(string username) => AppContext.User.Where(i => i.Login.Equals(username)).FirstOrDefault();
    }
}
