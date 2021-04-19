using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.Account_parts
{
    internal class CreateAccountViewModel : ViewModel
    {
        ComputerPeripheralsShopEntities computerPeripheralsShopEntities = new ComputerPeripheralsShopEntities();
        private string _username = "";
        private string _password = "";
        private string _name = "";
        private string _surname = "";
        private string _address = "";
        private bool _agree = false;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public bool Agree
        {
            get
            {
                return _agree;
            }
            set
            {
                _agree = value;
                OnPropertyChanged(nameof(Agree));
            }
        }

        public ICommand CreateAccountCommand { get; }
        public ICommand CloseCommand { get; }

        public CreateAccountViewModel()
        {
            CreateAccountCommand = new CommandViewModel(executeCreateAccount);
            CloseCommand = new CommandViewModel(ExecuteClose);
        }

        public void ExecuteClose()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(CreateAccountWindow))
                {
                    (window as CreateAccountWindow).Hide();
                    (window as CreateAccountWindow).Close();
                }
            }
        }

        private void executeCreateAccount()
        {
            if (!_agree)
            {
                MessageBox.Show("You can't create new account");
                return;
            }
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                foreach (User curUser in context.User)
                    if (_username.Equals(curUser.Login))
                    {
                        MessageBox.Show("This username already exists");
                        return;
                    }
                User user = new User(Username, GetHashEncryption(Password), Name, Surname, Address);
                context.User.Add(user);
                context.SaveChanges();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(CreateAccountWindow))
                    {
                        (window as CreateAccountWindow).Hide();
                        (window as CreateAccountWindow).Close();
                    }
                }

            }

        }

        private byte[] GetHashEncryption(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            /*string hash = string.Empty;*/

            //формируем одну цельную строку из массива  
            /*foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);*/

            return byteHash;
        }

        private string GetHashString(byte[] byteHash)
        {
            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
