using ComputerPeripheralsShopModel.ViewModels.Base;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class LoginWindowViewModel : ViewModel
    {
        ComputerPeripheralsShopEntities computerPeripheralsShopEntities = new ComputerPeripheralsShopEntities();
        private string _username;
        private string _password;
        private bool _agree;
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

        public ICommand LoginCommand { get; }

        public LoginWindowViewModel()
        {
            LoginCommand = new CommandViewModel(executeLogin);
        }

        private void executeLogin()
        {
            /*if (!_agree)
            {
                MessageBox.Show("You can't register");
                return;
            }
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                foreach (User curUser in context.User)
                    if (_username.Equals(curUser.Login))
                    {
                        MessageBox.Show("This login already exists");
                        return;
                    }
                User user = new User(Username, GetHashString(Password));
                context.User.Add(user);
                context.SaveChanges();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(LoginWindow))
                    {
                        (window as LoginWindow).Hide();
                        (window as LoginWindow).Close();
                    }
                }

            }*/

            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                foreach (User curentUser in context.User)
                    if (_username.Equals(curentUser.Login) && (GetHashString(GetHashEncryption(Password)).Equals(GetHashString(curentUser.Password_hash))))
                    {
                        ComputerPeripheralsShopModel.Models.Authentication.Account.curUser = curentUser;
                        ComputerPeripheralsShopModel.Models.Authentication.Account.IsLoggedIn = true;
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(LoginWindow))
                            {
                                (window as LoginWindow).Hide();
                                (window as LoginWindow).Close();
                            }
                        }
                        return;
                    }
                MessageBox.Show("The username or password is incorrect");
                /*User user = new User(Username, GetHashEncryption(Password));
                context.User.Add(user);
                context.SaveChanges();*/

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
