using ComputerPeripheralsShopModel.ViewModels.Base;
using ComputerPeripheralsShopModel.Views.Windows;
using System;
using System.Windows;
using System.Windows.Threading;

namespace ComputerPeripheralsShopModel.ViewModels
{
    internal class LoadingWindowViewModel : ViewModel
    {

        public LoadingWindowViewModel()
        {
            Loading();
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(LoadingWindow))
                {
                    (window as LoadingWindow).Hide();
                    MainWindow mainwindow = new MainWindow();
                    (window as LoadingWindow).Close();
                    Application.Current.MainWindow = mainwindow;
                    mainwindow.ShowDialog();
                }
            }
        }

        void Loading()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }
    }
}
