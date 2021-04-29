using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Linq;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.Account_parts
{
    internal class AccountViewModel : ViewModel
    {
        public AccountModel account;

        public ICommand SaveChanges { get; }
        public ICommand RechargeTheBalance { get; }

        public AccountViewModel()
        {
            this.account = new AccountModel();
            this.SaveChanges = new CommandViewModel(executeSaveChanges);
            this.RechargeTheBalance = new CommandViewModel(executeRechargeTheBalance);
        }


        public int User_Id
        {
            get => account.User_Id;
            set
            {
                account.User_Id = value;
                OnPropertyChanged("User_Id");
            }
        }
        public string Username
        {
            get => account.Username;
            set
            {
                account.Username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get
            {
                return account.Password;
            }
            set
            {
                account.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get
            {
                return account.Name;
            }
            set
            {
                account.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get
            {
                return account.Surname;
            }
            set
            {
                account.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Address
        {
            get
            {
                return account.Address;
            }
            set
            {
                account.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public decimal Balance
        {
            get => account.Balance;
            set
            {
                account.Balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public bool IsAdmin
        {
            get => account.IsAdmin;
            set
            {
                account.IsAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }

        private void executeSaveChanges()
        {
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Login = Username;
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Password_hash = account.GetHashEncryption(account.PasswordString);
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Name = Name;
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Surname = Surname;
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Address = Address;
                context.SaveChanges();
                ComputerPeripheralsShopModel.Models.Authentication.Account.curUser = context.User.FirstOrDefault(i => i.User_Id == User_Id);
            }
        }
        private void executeRechargeTheBalance()
        {
            Balance += 500;
            using (ComputerPeripheralsShopEntities context = new ComputerPeripheralsShopEntities())
            {
                context.User.FirstOrDefault(i => i.User_Id == User_Id).Balance = Balance;
                context.SaveChanges();
                ComputerPeripheralsShopModel.Models.Authentication.Account.curUser = context.User.FirstOrDefault(i => i.User_Id == User_Id);
            }

        }

    }
}
