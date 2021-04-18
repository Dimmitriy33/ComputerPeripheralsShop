using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class KeyboardsViewModel : ViewModel
    {
        public ICommand AlloyCore_InfoButton { get; }
        public ICommand AlloyElite_InfoButton { get; }
        public ICommand AlloyOrigins_InfoButton { get; }
        public ICommand ProX_InfoButton { get; }

        public KeyboardsViewModel()
        {
            AlloyCore_InfoButton = new CommandViewModel(executeAlloyCore);
            AlloyElite_InfoButton = new CommandViewModel(executeAlloyElite);
            AlloyOrigins_InfoButton = new CommandViewModel(executeAlloyOrigins);
            ProX_InfoButton = new CommandViewModel(executeProX);
        }

        private void executeProX()
        {
            throw new NotImplementedException();
        }

        private void executeAlloyOrigins()
        {
            throw new NotImplementedException();
        }

        private void executeAlloyElite()
        {
            throw new NotImplementedException();
        }

        private void executeAlloyCore()
        {
            throw new NotImplementedException();
        }
    }
}
