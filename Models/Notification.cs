using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace ComputerPeripheralsShop.Models
{
    public class Notification
    {
        public Notification(string title, string message, NotificationType type)
        {
            Title = title;
            Message = message;
            Type = type;
            Icon = GetPackIconKind(Type);
            Background = GetBackgroundColor(Type);
        }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public PackIconKind Icon { get; set; }
        public Brush Background { get; set; }

        public enum NotificationType
        {
            Default = 0,
            Warning = 1,
            Success = 2,
            Danger = 3
        }

        private PackIconKind GetPackIconKind(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Default:
                    return PackIconKind.WbIncandescent;
                case NotificationType.Danger:
                    return PackIconKind.Dangerous;
                case NotificationType.Success:
                    return PackIconKind.CheckCircle;
                case NotificationType.Warning:
                    return PackIconKind.WarningCircleOutline;
                default:
                    return PackIconKind.Sack;
            }
        }

        private Brush GetBackgroundColor(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Default:
                    return Brushes.FloralWhite;
                case NotificationType.Danger:
                    return Brushes.Tomato;
                case NotificationType.Success:
                    return Brushes.PaleGreen;
                case NotificationType.Warning:
                    return Brushes.Yellow;
                default:
                    return Brushes.Transparent;
            }
        }
    }
}
