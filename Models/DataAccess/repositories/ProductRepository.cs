using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System.Collections.ObjectModel;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ComputerPeripheralsShopEntities AppContext => _context as ComputerPeripheralsShopEntities;

        public ProductRepository(ComputerPeripheralsShopEntities context) : base(context)
        {

        }

        public ObservableCollection<Product> getMicrophones()
        {
            ObservableCollection<Product> items = new ObservableCollection<Product>();
            foreach (Product item in AppContext.Product)
            {
                if (item.Category.Equals("Microphones"))
                    items.Add(item);
            }
            return items;
        }
    }
}
