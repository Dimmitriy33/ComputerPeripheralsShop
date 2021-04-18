using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class HeadsetsViewModel : ViewModel
    {

        public ICommand Revolver_InfoButton { get; }
        public ICommand Stinger_InfoButton { get; }
        public ICommand Cloud2_InfoButton { get; }
        public ICommand ProX_InfoButton { get; }
        public HeadsetsViewModel()
        {
            Revolver_InfoButton = new CommandViewModel(ExecuteRevolver);
            Stinger_InfoButton = new CommandViewModel(ExecuteStinger);
            Cloud2_InfoButton = new CommandViewModel(ExecuteCloud2);
            ProX_InfoButton = new CommandViewModel(ExecuteProX);
        }

        private void ExecuteProX()
        {
            throw new NotImplementedException();
        }

        private void ExecuteCloud2()
        {
            throw new NotImplementedException();
        }

        private void ExecuteStinger()
        {
            throw new NotImplementedException();
        }

        private void ExecuteRevolver()
        {
            throw new NotImplementedException();
        }
    }
}
