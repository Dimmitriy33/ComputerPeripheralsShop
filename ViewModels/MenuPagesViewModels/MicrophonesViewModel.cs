using ComputerPeripheralsShop.ViewModels.Base;
using System;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class MicrophonesViewModel : ViewModel
    {
        public MicrophonesViewModel()
        {
            this.QuadCast_InfoButton = new CommandViewModel(ExecuteQuadCast);
            this.SoloCast_InfoButton = new CommandViewModel(ExecuteSoloCast);
        }

        private void ExecuteSoloCast()
        {
            throw new NotImplementedException();
        }

        private void ExecuteQuadCast()
        {
            throw new NotImplementedException();
        }

        public ICommand QuadCast_InfoButton { get; }
        public ICommand SoloCast_InfoButton { get; }
    }
}
