using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpeechTime.Helpers
{
    internal class WindowHelper
    {
        internal static void PlaceWindowOnScreen(Window window)
        {
            var screens = System.Windows.Forms.Screen.AllScreens;

            // TODO: possible error at 'MainWindowLocation'
            int screenNumber = AppSettings.PanelWindowScreen - 1;

            if (screens[screenNumber] != null)
            {
                window.Left = screens[screenNumber].Bounds.Left;
                window.Top = screens[screenNumber].Bounds.Top;
            }
        }
    }
}
