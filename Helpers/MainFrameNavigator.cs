using ComputerPeripheralsShopModel;
using System;
using System.Windows;

namespace ComputerPeripheralsShop.Helpers
{
    public static class MainFrameNavigator
    {
        public static void FrameNavigator(string folder, string file)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri($"{folder}{file}.xaml", UriKind.RelativeOrAbsolute));
                }
            }
        }

    }
}
