using ComputerPeripheralsShop.Models.DataAccess.interfaces;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ComputerPeripheralsShopEntities AppContext => _context as ComputerPeripheralsShopEntities;

        public ProductRepository(ComputerPeripheralsShopEntities context) : base(context)
        {

        }
    }
}
