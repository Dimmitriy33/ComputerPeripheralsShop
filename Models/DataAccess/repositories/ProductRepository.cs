using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ComputerPeripheralsShopEntities AppContext => _context as ComputerPeripheralsShopEntities;
        public ProductRepository(ComputerPeripheralsShopEntities context) : base(context)
        {

        }

        public ObservableCollection<Product> getMicrophones() => getProductsByCategory("Microphones");

        public ObservableCollection<Product> getGamingHeadsets() => getProductsByCategory("Gaming Headsets");

        public ObservableCollection<Product> getMices() => getProductsByCategory("Mices");

        public ObservableCollection<Product> getKeyboards() => getProductsByCategory("Keyboards");

        public ObservableCollection<Product> getMousePads() => getProductsByCategory("Mouse Pads");

        public ObservableCollection<Product> getProductsByCategory(string category)
        {
            ObservableCollection<Product> items = new ObservableCollection<Product>();
            foreach (Product item in AppContext.Product)
            {
                if (item.Category.Equals(category))
                    items.Add(item);
            }
            return items;
        }

        public Product getProductById(int id) => (from product in AppContext.Product
                                                  where product.Product_Id.Equals(id)
                                                  select product).Single<Product>();
    }
}
