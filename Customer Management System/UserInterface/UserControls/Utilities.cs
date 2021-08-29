using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterface.UserControls
{
    public class Utilities
    {
        public static void ShowSearchPopup(object content)
        {
            Window win = new Window();
            //win.Width = w;
            //win.Height = h;
            //win.Owner = GetRibbonMainWindow();
            //win.Content = content;
            win = content as Window;
            win.ShowInTaskbar = false;
            win.ResizeMode = ResizeMode.NoResize;
            win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win.ShowDialog();
            win.BringIntoView();
            win.Focus();
        }

        public static Window GetRibbonMainWindow()
        {
            if (System.Windows.Application.Current != null && System.Windows.Application.Current.Windows != null && System.Windows.Application.Current.Windows.Count > 0)
            {
                for (int i = 0; i < System.Windows.Application.Current.Windows.Count; i++)
                {
                    if (System.Windows.Application.Current.Windows[i] is Window && System.Windows.Application.Current.Windows[i].GetType().Name == "MainWindow")
                    {
                        return System.Windows.Application.Current.Windows[i];
                    }
                }
            }
            return null;
        }
    }
}
