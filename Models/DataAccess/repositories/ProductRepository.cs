using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess.interfaces;
using System;
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

        public List<Specifications> AddSpec()
        {
            List<Specifications> list = new List<Specifications>()
            {
                new Specifications("Manufacturer", CurrentProduct.currentProduct.Manufacturer),
            new Specifications("Model", CurrentProduct.currentProduct.Model),
            new Specifications("Type", CurrentProduct.currentProduct.Type),
            new Specifications("Connection type", CurrentProduct.currentProduct.Connection_Type),
            new Specifications("Weight", CurrentProduct.currentProduct.Weight),
            new Specifications("Backlight", BoolToStringConverters.BoolToStringView(CurrentProduct.currentProduct.Backlight)),
            new Specifications("Height", CurrentProduct.currentProduct.Height),
            new Specifications("Width", CurrentProduct.currentProduct.Width),
            new Specifications("Gaming mode", BoolToStringConverters.BoolToStringView(CurrentProduct.currentProduct.Gaming_mode))
            };

            if (CurrentProduct.currentProduct.Category.Equals("Gaming Headsets"))
                list.Add(new Specifications("Microphone", BoolToStringConverters.BoolToStringView(CurrentProduct.currentProduct.Microphone.HasValue && CurrentProduct.currentProduct.Microphone == true)));

            if (CurrentProduct.currentProduct.Category.Equals("Mices"))
                list.Add(new Specifications("DPI", CurrentProduct.currentProduct.dpi.ToString()));

            list.Add(new Specifications("Price", Decimal.Round(CurrentProduct.currentProduct.Price).ToString() + "$"));

            return list;

        }

        public class Specifications
        {

            public Specifications(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

        }
    }
}
