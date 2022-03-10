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
        public static void PlaceWindowOnScreen(Window window)
        {
            var screens = System.Windows.Forms.Screen.AllScreens;

            string windowName = window.GetType().Name;

            int screenNumber = 0;

            if (windowName.Equals("PanelWindow"))
            {
                screenNumber = AppSettings.PanelWindowScreen - 1;
            }
            else if (windowName.Equals("TimerWindow"))
            {
                screenNumber = AppSettings.TimerWindowScreen - 1;
            }

            if ((screenNumber >= 0 & screenNumber < screens.Length) && screens[screenNumber] != null)
            {
                window.Left = screens[screenNumber].Bounds.Left;
                window.Top = screens[screenNumber].Bounds.Top;
            }
        }
    }
}
