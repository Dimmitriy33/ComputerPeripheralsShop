using ComputerPeripheralsShop.Helpers;

namespace ComputerPeripheralsShop.Models
{
    public class AccountModel : Model
    {
        private string _username;
        private int _userId;
        private byte[] _password;
        private string _passwordString;
        private decimal _balance;
        private bool _isAdmin;
        private string _name;
        private string _surname;
        private string _address;

        public AccountModel()
        {
            this._username = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Login;
            this._userId = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.User_Id;
            this._password = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Password_hash;
            this._balance = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Balance;
            this._isAdmin = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.IsAdmin;
            this._name = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Name;
            this._surname = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Surname;
            this._address = ComputerPeripheralsShopModel.Models.Authentication.Account.curUser.Address;
        }

        public int User_Id
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged("User_Id");

            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get => HashConverters.GetHashString(_password);
            set
            {
                _passwordString = value;
                _password = HashConverters.GetHashEncryption(value);
                OnPropertyChanged(nameof(Password));
            }
        }

        public string PasswordString => _passwordString;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }


    }
}
