using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpeechTime.Helpers
{
    public static class WindowHelper
    {
        public static void PlaceWindowOnScreen(Window window, int screenNumber)
        {
            var screens = System.Windows.Forms.Screen.AllScreens;

            int screenIndex = screenNumber - 1;

            bool isValidScreen = (screenIndex >= 0 & screenIndex < screens.Length) && screens[screenIndex] != null;

            if (isValidScreen)
            {
                var previousWindowState = window.WindowState;
                window.WindowState = WindowState.Minimized;
                window.Left = screens[screenIndex].Bounds.Left;
                window.Top = screens[screenIndex].Bounds.Top;
                window.WindowState = previousWindowState;
                window.Show();
            }
            else
            {
                window.Hide();
            }
        }
    }
}
