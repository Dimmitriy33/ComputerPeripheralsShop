using ComputerPeripheralsShop;

namespace ComputerPeripheralsShopModel.Models.Authentication
{
    public static class Account
    {
        public static User curUser { get; set; }
        public static bool IsLoggedIn { get; set; }

    }
}
