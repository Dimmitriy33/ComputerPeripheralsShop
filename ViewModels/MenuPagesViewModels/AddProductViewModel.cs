using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class AddProductViewModel : ViewModel
    {
        private Product _product;
        private ObservableCollection<string> _categories;
        private bool _visibilityDPI;
        private bool _visibilityMicrophone;

        private string _picture_Main_Path;
        private string _picture1_Path;
        private string _picture2_Path;
        private string _menuPicture_Path;

        public ICommand Picture_Main_Path_SetPathCommand { get; }
        public ICommand Picture1Path_SetPathCommand { get; }
        public ICommand Picture2Path_SetPathCommand { get; }
        public ICommand MenuPicturePath_SetPathCommand { get; }

        public ICommand AddCommand { get; }

        public AddProductViewModel()
        {
            _product = new Product();
            AddCommand = new CommandViewModel(ExecuteAddProduct);
            using (UnitOfWork context = new UnitOfWork())
            {
                _categories = context.ProductRepository.getCategories();
            }
            _visibilityDPI = false;
            _visibilityMicrophone = false;
            Picture_Main_Path_SetPathCommand = new CommandViewModel(executePicture_Main_Path_SetPath);
            Picture1Path_SetPathCommand = new CommandViewModel(executePicture1Path_SetPath);
            Picture2Path_SetPathCommand = new CommandViewModel(executePicture2Path_SetPath);
            MenuPicturePath_SetPathCommand = new CommandViewModel(executeMenuPicturePath_SetPath);
        }

        private void ExecuteAddProduct()
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                _product.Picture_Main = ConvertBitmapSourceToByteArray(_picture_Main_Path);
                _product.Picture1 = ConvertBitmapSourceToByteArray(_picture1_Path);
                _product.Picture2 = ConvertBitmapSourceToByteArray(_picture2_Path);
                _product.MenuPicture = ConvertBitmapSourceToByteArray(_menuPicture_Path);
                context.ProductRepository.AddProduct(_product);
            }
        }


        public ObservableCollection<string> Categories => _categories;

        public string Category
        {
            get => _product.Category;
            set
            {
                _product.Category = value;
                if (_product.Category.Equals("Mices"))
                    VisibilityDPI = true;
                else if (_product.Category.Equals("Gaming Headsets"))
                    VisibilityMicrophone = true;
                OnPropertyChanged("Category");
            }
        }
        public string Manufacturer
        {
            get => _product.Manufacturer;
            set
            {
                _product.Manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }
        public string Model
        {
            get => _product.Model;
            set
            {
                _product.Model = value;
                OnPropertyChanged("Model");
            }
        }
        public string Type
        {
            get => _product.Type;
            set
            {
                _product.Type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Connection_Type
        {
            get => _product.Connection_Type;
            set
            {
                _product.Connection_Type = value;
                OnPropertyChanged("Connection_Type");
            }
        }
        public string Weight
        {
            get => _product.Weight;
            set
            {
                _product.Weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public bool Backlight
        {
            get => _product.Backlight;
            set
            {
                _product.Backlight = value;
                OnPropertyChanged("Backlight");
            }
        }
        public string Height
        {
            get => _product.Height;
            set
            {
                _product.Height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Width
        {
            get => _product.Width;
            set
            {
                _product.Width = value;
                OnPropertyChanged("Width");
            }
        }
        public int dpi
        {
            get
            {
                if (_product.dpi != null)
                    return (int)_product.dpi;
                else
                    return 0;
            }
            set
            {
                _product.dpi = value;
                OnPropertyChanged("dpi");
            }
        }
        public bool Microphone
        {
            get
            {
                if (_product.Microphone != null)
                    return (bool)_product.Microphone;
                else
                    return false;
            }
            set
            {
                _product.Microphone = value;
                OnPropertyChanged("Microphone");
            }
        }
        public bool Gaming_mode
        {
            get => _product.Gaming_mode;
            set
            {
                _product.Gaming_mode = value;
                OnPropertyChanged("Gaming_mode");
            }
        }
        public decimal Price
        {
            get => _product.Price;
            set
            {
                _product.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Number_on_warehouse
        {
            get => _product.Number_on_warehouse;
            set
            {
                _product.Number_on_warehouse = value;
                OnPropertyChanged("Number_on_warehouse");
            }
        }
        public string Picture_Main_Path
        {
            get => _picture_Main_Path;
            set
            {
                _picture_Main_Path = value;
                OnPropertyChanged("Picture_Main_Path");
            }
        }
        public string Picture1Path
        {
            get => _picture1_Path;
            set
            {
                _picture1_Path = value;
                OnPropertyChanged("Picture1Path");
            }
        }
        public string Picture2Path
        {
            get => _picture2_Path;
            set
            {
                _picture2_Path = value;
                OnPropertyChanged("Picture2Path");
            }
        }
        public string Description
        {
            get => _product.Description;
            set
            {
                _product.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ShortDescription
        {
            get => _product.ShortDescription;
            set
            {
                _product.ShortDescription = value;
                OnPropertyChanged("ShortDescription");
            }
        }
        public string MenuPicturePath
        {
            get => _menuPicture_Path;
            set
            {
                _menuPicture_Path = value;
                OnPropertyChanged("MenuPicturePath");
            }
        }

        public bool VisibilityDPI
        {
            get => this._visibilityDPI;
            set
            {
                this._visibilityDPI = value;
                OnPropertyChanged("VisibilityDPI");
            }
        }

        public bool VisibilityMicrophone { get => this._visibilityMicrophone; set => this._visibilityMicrophone = value; }

        private void executePicture_Main_Path_SetPath() => Picture_Main_Path = FilePathfromFIleDialog();
        private void executePicture1Path_SetPath() => Picture1Path = FilePathfromFIleDialog();
        private void executePicture2Path_SetPath() => Picture2Path = FilePathfromFIleDialog();
        private void executeMenuPicturePath_SetPath() => MenuPicturePath = FilePathfromFIleDialog();

        private string FilePathfromFIleDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            /*fileDialog.Filter = "";*/
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
                return "";
            else
                return fileDialog.FileName;
        }

        public byte[] ConvertBitmapSourceToByteArray(string filepath)
        {
            var image = new BitmapImage(new Uri(filepath));
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
