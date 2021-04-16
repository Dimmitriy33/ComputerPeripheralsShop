using System;
using System.Windows;
using System.Windows.Threading;

namespace ComputerPeripheralsShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public LoadingWindow()
        {
            InitializeComponent();
            Loading();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.ShowDialog();
            Close();
        }

        void Loading()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

    }
}
