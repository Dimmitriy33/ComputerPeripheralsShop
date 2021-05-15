using ComputerPeripheralsShop.ViewModels;
using System.Windows;

namespace ComputerPeripheralsShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification(ComputerPeripheralsShop.Models.Notification notification)
        {
            InitializeComponent();
            this.DataContext = new NotificationViewModel(notification);
        }
    }
}
