using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using ComputerPeripheralsShopModel.Models.Authentication;
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

        public void Reducebalance(int user_id, decimal sum)
        {
            AppContext.User.Where(u => u.User_Id == user_id).FirstOrDefault().Balance -= sum;
            Account.curUser.Balance -= sum;
            AppContext.SaveChanges();
        }
    }
}
