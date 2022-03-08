using System;
using System.Windows.Media;

namespace SpeechTime
{
    public static class AppSettings
    {
        public static TimeSpan TimerLimit { get; set; }
        public static string Bleeper { get; set; }
        public static Color PanelWindowBackground { get; set; }
        public static Color PanelWindowForeground { get; set; }
        public static string TimerWindowBackgroundImage { get; set; }
        public static int PanelWindowScreen { get; set; }
        public static int TimerWindowScreen { get; set; }
        public static int UIUpdateIntervalMs { get; set; }
    }
}
