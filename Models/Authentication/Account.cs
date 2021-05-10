using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Windows;

namespace ComputerPeripheralsShopModel.Models.Authentication
{
    public class Account
    {
        public static User curUser { get; set; }
        public static bool IsLoggedIn { get; set; }

        public static void Login(string username, string password)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                var registeredUser = context.UserRepository.GetUserByUsername(username);
                if (registeredUser != null)
                {
                    if (HashConverters.GetHashString(HashConverters.GetHashEncryption(password)).Equals(HashConverters.GetHashString(registeredUser.Password_hash)))
                    {

                        curUser = registeredUser;
                        IsLoggedIn = true;
                        CloseLoginWindow();
                        return;
                    }

                }

                MessageBox.Show("The username or password is incorrect");
            }
        }

        public static void CreateAccount(bool agree, string username, string password, string name, string surname, string address)
        {
            if (!agree)
            {
                MessageBox.Show("You can't create new account");
                return;
            }
            using (UnitOfWork context = new UnitOfWork())
            {
                foreach (User curUser in context.UserRepository.AppContext.User)
                    if (username.Equals(curUser.Login))
                    {
                        MessageBox.Show("This username already exists");
                        return;
                    }
                User user = new User(username, HashConverters.GetHashEncryption(password), name, surname, address);
                context.UserRepository.AppContext.User.Add(user);
                context.SaveChanges();
                curUser = user;
                IsLoggedIn = true;
                CloseCreateAccountWindow();
            }
        }

        private static void CloseLoginWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(LoginWindow))
                {
                    (window as LoginWindow).Hide();
                    (window as LoginWindow).Close();
                }
            }
        }

        private static void CloseCreateAccountWindow()
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

        private static void OpenLoginWindow()
        {
            Window loginAccWindow = new LoginWindow();
            loginAccWindow.Show();
        }

        private static void OpenCreateAccountWindow()
        {
            Window createAccWindow = new CreateAccountWindow();
            createAccWindow.Show();
        }

    }
}
