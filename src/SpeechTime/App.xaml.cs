using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Specialized;

namespace SpeechTime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppSettings.TargetTimeZone = ConfigurationManager.AppSettings.Get("TargetTimeZone");
            AppSettings.TargetTimeZoneLabel = ConfigurationManager.AppSettings.Get("TargetTimeZoneLabel");
            // TODO: replace to the TryParse method
            AppSettings.SpeechTimeLimit = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("SpeechTimeLimit"));
            AppSettings.SignalSound = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings.Get("SignalSound");
            AppSettings.MainWindowBackground = ConfigurationManager.AppSettings.Get("MainWindowBackground");
            AppSettings.MainWindowForeground = ConfigurationManager.AppSettings.Get("MainWindowForeground");
            AppSettings.SpecialWindowBackground = ConfigurationManager.AppSettings.Get("SpecialWindowBackground");
            // TODO: replace to the TryParse metho
            AppSettings.MainWindowLocation = Int32.Parse(ConfigurationManager.AppSettings.Get("MainWindowLocation"));
            // TODO: replace to the TryParse metho
            AppSettings.SpecialWindowLocation = Int32.Parse(ConfigurationManager.AppSettings.Get("SpecialWindowLocation"));
            AppSettings.UIUpdateIntervalMs = Int32.Parse(ConfigurationManager.AppSettings.Get("UIUpdateIntervalMs"));
        }
    }
}
