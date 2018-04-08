using System;
using System.Windows.Forms;
using System.Windows;

namespace TrayIcon
{
    class IconGenerator
    {

        public NotifyIcon notifyIcon;

        private ContextMenu _menu;
        private Window _window;

        public IconGenerator(Window window, string balloon, string text, string iconPath)
        {
            _window = window;
            //NotifyIcon
            notifyIcon = new NotifyIcon();
            _menu = new ContextMenu();
            notifyIcon.BalloonTipText = balloon;
            notifyIcon.Text = text;
            notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = _menu;
        }

        public void AddNotifyMenuItem(int index, string text, EventHandler func)
        {
            MenuItem temp = new MenuItem(text, func);
            temp.Index = index;
            _menu.MenuItems.Add(temp);
        }
    }
}
