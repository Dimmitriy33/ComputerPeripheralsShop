using System;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class MousePadsViewModel
    {
        public ICommand FurySPro_InfoButton { get; }
        public ICommand FuryUltra_InfoButton { get; }

        public MousePadsViewModel()
        {
            FurySPro_InfoButton = new CommandViewModel(executeFurySPro);
            FuryUltra_InfoButton = new CommandViewModel(executeFuryUltra);
        }

        private void executeFuryUltra()
        {
            throw new NotImplementedException();
        }

        private void executeFurySPro()
        {
            throw new NotImplementedException();
        }
    }
}
