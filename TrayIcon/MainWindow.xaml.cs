using System;
using System.Windows;
using System.ComponentModel;

namespace TrayIcon
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool canExitFlag;
        private int sec;

        public MainWindow()
        {
            IconGenerator icon = new IconGenerator(this ,"SuperAppka", "Nazdar", @"./icon.ico");
            icon.AddNotifyMenuItem(0, "Exit", exitItem_Click);
            icon.notifyIcon.DoubleClick += notifyIcon_MouseDoubleClick;
            InitializeComponent();
            Visibility = Visibility.Hidden;
            ShowInTaskbar = false;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            sec++;
            TimerText.Content = "Sekund od startu: " + sec;
        }

        private void notifyIcon_MouseDoubleClick(object sender, EventArgs e)
        {
            if (Visibility == Visibility.Hidden || WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
                Visibility = Visibility.Visible;
                ShowInTaskbar = true;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!canExitFlag)
            {
                e.Cancel = true;
                Visibility = Visibility.Hidden;
                ShowInTaskbar = false;
            }
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            canExitFlag = true;
            System.Windows.Application.Current.Shutdown();
        }
    }
}
