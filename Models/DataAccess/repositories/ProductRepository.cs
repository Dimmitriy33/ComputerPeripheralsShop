using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System.Collections.Generic;
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

        public IEnumerable<Product> getMicrophones() => getProductsByCategory("Microphones");

        public IEnumerable<Product> getGamingHeadsets() => getProductsByCategory("Gaming Headsets");

        public IEnumerable<Product> getMices() => getProductsByCategory("Mices");

        public IEnumerable<Product> getKeyboards() => getProductsByCategory("Keyboards");

        public IEnumerable<Product> getMousePads() => getProductsByCategory("Mouse Pads");

        public IEnumerable<Product> getProductsByCategory(string category) => AppContext.Product.Where(x => x.Category.Equals(category));

        public ObservableCollection<string> getCategories() => new ObservableCollection<string>()
            {
                "Gaming Headsets",
                "Microphones",
                "Keyboards",
                "Mices",
                "Mouse Pads"
            };

        public Product GetProductById(int id) => (from product in AppContext.Product
                                                  where product.Product_Id.Equals(id)
                                                  select product).Single();

        public void AddProduct(Product product) => AppContext.Product.Add(product);
    }
}
