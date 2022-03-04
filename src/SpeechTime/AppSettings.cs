using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTime
{
    public class AppSettings
    {
        public static string TargetTimeZone { get; set; }
        public static string TargetTimeZoneLabel { get; set; }
        public static TimeSpan SpeechTimeLimit { get; set; }
        public static string SignalSound { get; set; }
        public static string MainWindowBackground { get; set; }
        public static string MainWindowForeground { get; set; }
        public static string SpecialWindowBackground { get; set; }
        public static int MainWindowLocation { get; set; }
        public static int SpecialWindowLocation { get; set; }
        public static int UIUpdateIntervalMs { get; set; }
    }
}
