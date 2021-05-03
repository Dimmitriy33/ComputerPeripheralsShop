using ComputerPeripheralsShop.Database;

namespace ComputerPeripheralsShopModel.Models.Authentication
{
    public interface IAuthentication
    {
        User curUser { get; set; }
        bool IsLoggedIn { get; set; }
    }
}
