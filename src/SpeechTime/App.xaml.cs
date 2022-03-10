using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;

using SpeechTime.Helpers;
using SpeechTime.Extensions;

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

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["TimerLimit"].Value = AppSettings.TimerLimit.ToString(@"hh\:mm\:ss");
            config.AppSettings.Settings["PanelWindowBackground"].Value = AppSettings.PanelWindowBackground.ToHexString();
            config.AppSettings.Settings["PanelWindowForeground"].Value = AppSettings.PanelWindowForeground.ToHexString();
            config.AppSettings.Settings["PanelWindowScreen"].Value = AppSettings.PanelWindowScreen.ToString();
            config.AppSettings.Settings["TimerWindowScreen"].Value = AppSettings.TimerWindowScreen.ToString();
            config.AppSettings.Settings["UIUpdateIntervalMs"].Value = AppSettings.UIUpdateIntervalMs.ToString();

            config.Save();
        }
    }
}
