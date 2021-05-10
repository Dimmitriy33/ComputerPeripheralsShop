using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComputerPeripheralsShop.Models.Products
{
    public class ProductsMenuModel
    {

        public ProductsMenuModel()
        {
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                using (UnitOfWork context = new UnitOfWork())
                {
                    return context.ProductRepository.GetProducts();
                }
            }
        }

        public ObservableCollection<Product> GamingHeadsetsItems => (ObservableCollection<Product>)Products.Where(i => i.Category.Equals("Gaming Headsets"));

        public ObservableCollection<Product> MicrophonesItems => (ObservableCollection<Product>)Products.Where(i => i.Category.Equals("Microphones"));

        public ObservableCollection<Product> KeyboardsItems => (ObservableCollection<Product>)Products.Where(i => i.Category.Equals("Keyboards"));

        public ObservableCollection<Product> MicesItems => (ObservableCollection<Product>)Products.Where(i => i.Category.Equals("Mices"));

        public ObservableCollection<Product> MousePadsItems => (ObservableCollection<Product>)Products.Where(i => i.Category.Equals("Mouse Pads"));
    }
}
