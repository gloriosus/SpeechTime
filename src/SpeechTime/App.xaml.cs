using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;

using SpeechTime.Helpers;

namespace SpeechTime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppSettings.TimerLimit = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("TimerLimit"), TimeSpan.Zero);
            AppSettings.Bleeper = SettingsHelper.GetAbsolutePath(ConfigurationManager.AppSettings.Get("Bleeper"));
            AppSettings.PanelWindowBackground = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("PanelWindowBackground"), Colors.Black);
            AppSettings.PanelWindowForeground = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("PanelWindowForeground"), Colors.Lime);
            AppSettings.TimerWindowBackgroundImage = SettingsHelper.GetAbsolutePath(ConfigurationManager.AppSettings.Get("TimerWindowBackgroundImage"));
            AppSettings.PanelWindowScreen = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("PanelWindowScreen"), 1);
            AppSettings.TimerWindowScreen = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("TimerWindowScreen"), 1);
            AppSettings.UIUpdateIntervalMs = SettingsHelper.GetValueOrDefault(ConfigurationManager.AppSettings.Get("UIUpdateIntervalMs"), 200);
        }
    }
}
