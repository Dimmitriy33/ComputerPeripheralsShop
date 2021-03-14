namespace ComputerPeripheralsShop.ViewModels.Base
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "ComputerPeripheralsShop";
        public string Title
        {
            get => _Title;
            set => set(ref _Title, value);
        }
    }
}
