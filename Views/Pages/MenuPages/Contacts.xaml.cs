using ComputerPeripheralsShop.ViewModels.MenuPagesViewModels;
using System.Windows.Controls;

namespace ComputerPeripheralsShop.Views.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для Contacts.xaml
    /// </summary>
    public partial class Contacts : Page
    {
        public Contacts()
        {
            InitializeComponent();
            this.DataContext = new ContactsViewModel();
        }
    }
}
