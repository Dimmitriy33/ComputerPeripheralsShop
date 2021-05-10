using ComputerPeripheralsShop.Helpers;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class ReturnPolicyViewModel : ViewModel
    {
        public ICommand ToContacts { get; }

        public ReturnPolicyViewModel()
        {
            ToContacts = new CommandViewModel(executeToContacts);
        }

        private void executeToContacts() => MainFrameNavigator.FrameNavigator("Views/Pages/MenuPages/", "Contacts");
    }
}
