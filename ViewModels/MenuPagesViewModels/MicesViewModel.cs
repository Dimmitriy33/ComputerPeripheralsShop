using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicesViewModel : ViewModel
    {
        public ICommand Haste_InfoButton { get; }
        public ICommand Surge_InfoButton { get; }
        public ICommand Core_InfoButton { get; }
        public ICommand G305_InfoButton { get; }

        public MicesViewModel()
        {
            // лучше одну команду сделать, которая будет вызывать метод который будет открывать новую страницу в которую передается объект продукта
            Haste_InfoButton = new CommandViewModel(ExecuteHaste);
            Surge_InfoButton = new CommandViewModel(ExecuteSurge);
            Core_InfoButton = new CommandViewModel(ExecuteCore);
            G305_InfoButton = new CommandViewModel(ExecuteG305);
        }

        private void ExecuteG305()
        {
            throw new NotImplementedException();
        }

        private void ExecuteCore()
        {
            throw new NotImplementedException();
        }

        private void ExecuteSurge()
        {
            throw new NotImplementedException();
        }

        private void ExecuteHaste()
        {
            throw new NotImplementedException();
        }
    }
}
