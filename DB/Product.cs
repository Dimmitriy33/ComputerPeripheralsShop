using System.Drawing;

namespace ComputerPeripheralsShop.DB
{
    public class Product
    {

        public Product()
        {

        }
        public int Product_Id { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Connection_Type { get; set; }
        public string Weight { get; set; }
        public bool Backlight { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public int? DPI { get; set; }
        public bool Microphone { get; set; }
        public bool Gaming_mode { get; set; }
        public decimal Price { get; set; }
        public int Number_on_warehouse { get; set; }
        public Image Picture_Main { get; set; }
        public Image Picture1 { get; set; }
        public Image Picture2 { get; set; }




    }
}
