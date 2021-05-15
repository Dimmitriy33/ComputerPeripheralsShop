using ComputerPeripheralsShop.Models;
using ComputerPeripheralsShopModel.ViewModels;
using ComputerPeripheralsShopModel.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ComputerPeripheralsShop.ViewModels
{
    internal class NotificationViewModel : ViewModel
    {
        private string _title = "";
        private string _message = "";
        private PackIconKind _icon;
        private Brush _background;

        public ICommand CloseCommand { get; }

        public NotificationViewModel(Notification notification)
        {
            Title = notification.Title;
            Message = notification.Message;
            Background = notification.Background;
            Icon = notification.Icon;
            CloseCommand = new CommandViewModel(ExecuteClose);
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public Brush Background
        {
            get => _background;
            set
            {
                _background = value;
                OnPropertyChanged("Background");
            }
        }

        public PackIconKind Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        public void ExecuteClose() => CloseNotificationWindow();

        private void CloseNotificationWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Views.Windows.Notification))
                {
                    (window as Views.Windows.Notification).Hide();
                    (window as Views.Windows.Notification).Close();
                }
            }
        }

    }
}
