using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.Views.Windows;
using ComputerPeripheralsShopModel.Views.Windows;
using System.Windows;

namespace ComputerPeripheralsShopModel.Models.Authentication
{
    public class Account : IAuthentication
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

                NotificationWindowContoller.NewNotification("Error!", "The username or password is incorrect", ComputerPeripheralsShop.Models.Notification.NotificationType.Danger);
            }
        }

        public static void CreateAccount(bool agree, string username, string password, string name, string surname, string address)
        {
            if (!agree)
            {
                NotificationWindowContoller.NewNotification("Error!", "You can't create new account", ComputerPeripheralsShop.Models.Notification.NotificationType.Success);
                return;
            }
            using (UnitOfWork context = new UnitOfWork())
            {
                foreach (User curUser in context.UserRepository.AppContext.User)
                    if (username.Equals(curUser.Login))
                    {
                        NotificationWindowContoller.NewNotification("Error!", "This username already exists", ComputerPeripheralsShop.Models.Notification.NotificationType.Danger);
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

        public static void LogOut()
        {
            if (curUser != null)
            {
                curUser = null;
                IsLoggedIn = false;
                NotificationWindowContoller.NewNotification("Success!", "You successfully logged out", ComputerPeripheralsShop.Models.Notification.NotificationType.Success);
                MainFrameNavigator.FrameGoBack();
                return;
            }
            else
                NotificationWindowContoller.NewNotification("Error!", "You are not logged in", ComputerPeripheralsShop.Models.Notification.NotificationType.Danger);
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
