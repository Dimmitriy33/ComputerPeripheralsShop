using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ComputerPeripheralsShop.ViewModels
{
    internal class ProductViewModel : ViewModel
    {
        public ICommand BuyCommand { get; }

        public ProductViewModel()
        {
            BuyCommand = new CommandViewModel(executeBuyCommand);
        }


        public int Product_Id
        {
            get => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Product_Id;
        }
        /*
         public string Category
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Category;
         public string Manufacturer
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Manufacturer;

         public string Type
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Type;
         public string Connection_Type
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Connection_Type;
         public string Weight
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Weight;
         public bool Backlight
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Backlight;
         public string Height
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Height;
         public string Width
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Width;
         public Nullable<int> dpi
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.dpi;
         public Nullable<bool> Microphone
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Microphone;
         public bool Gaming_mode
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Gaming_mode;
         public decimal Price
         => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Price;
        */
        public int Number_on_warehouse
        => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Number_on_warehouse;
        public string Model
        => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Model;
        public BitmapImage Picture_Main
        => ImageFromBytearray(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Picture_Main);
        public ImageSource Picture1
        => ImageFromBytearray(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Picture1);

        public ImageSource Picture2
        => ImageFromBytearray(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Picture2);

        public string ProductFullName
        => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Manufacturer + " " + Model;

        public string Description
        => ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Description;

        public List<Specifications> SpecificationsList => AddSpec();

        public ObservableCollection<Order_List> order_Lists
        {
            get => ComputerPeripheralsShop.Models.CurrentOrderList.CurOrderList;
            set => ComputerPeripheralsShop.Models.CurrentOrderList.CurOrderList = value;
        }

        public static List<Specifications> AddSpec()
        {
            List<Specifications> list = new List<Specifications>()
            {
                new Specifications("Manufacturer", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Manufacturer),
            new Specifications("Model", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Model),
            new Specifications("Type", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Type),
            new Specifications("Connection type", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Connection_Type),
            new Specifications("Weight", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Weight),
            new Specifications("Backlight", BoolToStringView(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Backlight)),
            new Specifications("Height", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Height),
            new Specifications("Width", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Width),
            new Specifications("Gaming mode", BoolToStringView(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Gaming_mode))
            };

            if (ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Category.Equals("Gaming Headsets"))
                list.Add(new Specifications("Microphone", BoolToStringView(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Microphone.HasValue && ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Microphone == true)));

            if (ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Category.Equals("Mices"))
                list.Add(new Specifications("DPI", ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.dpi.ToString()));

            list.Add(new Specifications("Price", Decimal.Round(ComputerPeripheralsShop.Models.CurrentProduct.currentProduct.Price).ToString() + "$"));

            return list;

        }
        private void executeBuyCommand()
        {
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                int count_of_orders = context.Order.Count<Order>();
                ObservableCollection<Order_List> curOrderList = ComputerPeripheralsShop.Models.CurrentOrderList.CurOrderList;
                curOrderList.Add(new Order_List(Product_Id, count_of_orders, ComputerPeripheralsShop.Models.CurrentOrderList.CurOrderList.Count));
                ComputerPeripheralsShop.Models.CurrentOrderList.CurOrderList = curOrderList;
                /* context.Product.Find(Product_Id).Number_on_warehouse -= 1;
                 context.SaveChanges();*/

            }
        }

        private BitmapImage ImageFromBytearray(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
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

        public static string BoolToStringView(bool value)
        {
            if (value)
                return "Yes";
            else
                return "No";
        }
    }
}
