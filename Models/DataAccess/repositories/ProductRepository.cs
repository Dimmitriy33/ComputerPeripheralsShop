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

        public IEnumerable<Product> GetMicrophones() => GetProductsByCategory("Microphones");

        public IEnumerable<Product> GetGamingHeadsets() => GetProductsByCategory("Gaming Headsets");

        public IEnumerable<Product> GetMices() => GetProductsByCategory("Mices");

        public IEnumerable<Product> GetKeyboards() => GetProductsByCategory("Keyboards");

        public IEnumerable<Product> GetMousePads() => GetProductsByCategory("Mouse Pads");

        public IEnumerable<Product> GetProductsByCategory(string category) => AppContext.Product.Where(x => x.Category.Equals(category));

        public ObservableCollection<string> GetCategories() => new ObservableCollection<string>()
            {
                "Gaming Headsets",
                "Microphones",
                "Keyboards",
                "Mices",
                "Mouse Pads"
            };

        public ObservableCollection<string> GetConnectionTypes() => new ObservableCollection<string>()
            {
                "Cabel",
                "Wireless"
            };

        public ObservableCollection<string> GetBacklight() => new ObservableCollection<string>()
            {
                "True",
                "False"
            };

        public ObservableCollection<string> GetMicrophone() => new ObservableCollection<string>()
            {
                "True",
                "False"
            };

        public ObservableCollection<string> GetGamingMode() => new ObservableCollection<string>()
            {
                "True",
                "False"
            };

        public ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> curProducts = new ObservableCollection<Product>();
            foreach (Product el in AppContext.Product)
                curProducts.Add(el);
            return curProducts;
        }

        public Product GetProductById(int id) => (from product in AppContext.Product
                                                  where product.Product_Id.Equals(id)
                                                  select product).Single();

        public decimal GetProductPrice(int product_id)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                return AppContext.Product.Where(p => p.Product_Id == product_id).Single().Price;
            }
        }

        public void AddProduct(Product product)
        {
            AppContext.Product.Add(product);
            AppContext.SaveChanges();
        }

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
