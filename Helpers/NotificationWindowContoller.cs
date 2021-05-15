using ComputerPeripheralsShop.Views.Windows;

namespace ComputerPeripheralsShop.Helpers
{
    public static class NotificationWindowContoller
    {
        public static void NewNotification(string title, string message, Models.Notification.NotificationType type)
        {
            Notification notificationWindow = new Notification(new Models.Notification(title, message, type));
            notificationWindow.ShowDialog();
        }
    }
}
