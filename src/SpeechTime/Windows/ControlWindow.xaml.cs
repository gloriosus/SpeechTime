using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpeechTime.Clocks;
using SpeechTime.Helpers;

namespace SpeechTime.Windows
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        private Timer timer = Timer.Instance;
        private Stopwatch stopwatch = Stopwatch.Instance;
        private Bleeper bleeper;
        private DispatcherTimer dispatcherTimer;

        public ControlWindow()
        {
            InitializeComponent();

            WindowHelper.PlaceWindowOnScreen(this);

            timer.InitialValue = AppSettings.TimerLimit;
            bleeper = new Bleeper(AppSettings.Bleeper);

            TimerLimitTextBox.Text = AppSettings.TimerLimit.ToString();
            PanelWindowBackgroundColorPicker.SelectedColor = AppSettings.PanelWindowBackground;
            PanelWindowForegroundColorPicker.SelectedColor = AppSettings.PanelWindowForeground;
            PanelWindowScreenTextBox.Text = AppSettings.PanelWindowScreen.ToString();
            TimerWindowScreenTextBox.Text = AppSettings.TimerWindowScreen.ToString();
            UIUpdateIntervalTextBox.Text = AppSettings.UIUpdateIntervalMs.ToString();

            dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(AppSettings.UIUpdateIntervalMs), DispatcherPriority.Normal, dispatcherTimer_Tick, this.Dispatcher);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timerValue = timer.CurrentValue;
            TimeSpan stopwatchValue = stopwatch.CurrentValue;

            TimerReflectionLabel.Content = timerValue.ToString(@"hh\:mm\:ss");
            StopwatchReflectionLabel.Content = stopwatchValue.ToString(@"hh\:mm\:ss");

            bleeper.Play(timerValue, new TimeSpan(0, 0, 10));

            if (timerValue.Equals(TimeSpan.Zero))
                timer.Reset();
        }

        private void TimerStartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                TimerControlPanel.Background = new SolidColorBrush(Colors.MistyRose);
            }
            else
            {
                timer.Start();
                TimerControlPanel.Background = new SolidColorBrush(Colors.Honeydew);
            }
        }

        private void TimerResetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Reset();
            TimerControlPanel.Background = new SolidColorBrush(Colors.MistyRose);
        }

        private void StopwatchStartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsEnabled)
            {
                stopwatch.Stop();
                StopwatchControlPanel.Background = new SolidColorBrush(Colors.MistyRose);
            }
            else
            {
                stopwatch.Start();
                StopwatchControlPanel.Background = new SolidColorBrush(Colors.Honeydew);
            }
        }

        private void StopwatchResetButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            StopwatchControlPanel.Background = new SolidColorBrush(Colors.MistyRose);
        }

        private void AcceptSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            AppSettings.TimerLimit = SettingsHelper.GetValueOrDefault(TimerLimitTextBox.Text, TimeSpan.Zero);
            AppSettings.PanelWindowBackground = PanelWindowBackgroundColorPicker.SelectedColor;
            AppSettings.PanelWindowForeground = PanelWindowForegroundColorPicker.SelectedColor;
            AppSettings.PanelWindowScreen = SettingsHelper.GetValueOrDefault(PanelWindowScreenTextBox.Text, 0);
            AppSettings.TimerWindowScreen = SettingsHelper.GetValueOrDefault(TimerWindowScreenTextBox.Text, 0);
            AppSettings.UIUpdateIntervalMs = SettingsHelper.GetValueOrDefault(UIUpdateIntervalTextBox.Text, 200);

            TimerLimitTextBox.Text = AppSettings.TimerLimit.ToString();
            PanelWindowBackgroundColorPicker.SelectedColor = AppSettings.PanelWindowBackground;
            PanelWindowForegroundColorPicker.SelectedColor = AppSettings.PanelWindowForeground;
            PanelWindowScreenTextBox.Text = AppSettings.PanelWindowScreen.ToString();
            TimerWindowScreenTextBox.Text = AppSettings.TimerWindowScreen.ToString();
            UIUpdateIntervalTextBox.Text = AppSettings.UIUpdateIntervalMs.ToString();

            timer.InitialValue = AppSettings.TimerLimit;
            // PanelWindowBackground
            // PanelWindowForeground
            // PanelWindowScreen
            // TimerWindowScreen
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(AppSettings.UIUpdateIntervalMs);
            // panelwindow dispatcher timer
            // timerwindow dispatcher timer
        }

        private void CancelSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            TimerLimitTextBox.Text = AppSettings.TimerLimit.ToString();
            PanelWindowBackgroundColorPicker.SelectedColor = AppSettings.PanelWindowBackground;
            PanelWindowForegroundColorPicker.SelectedColor = AppSettings.PanelWindowForeground;
            PanelWindowScreenTextBox.Text = AppSettings.PanelWindowScreen.ToString();
            TimerWindowScreenTextBox.Text = AppSettings.TimerWindowScreen.ToString();
            UIUpdateIntervalTextBox.Text = AppSettings.UIUpdateIntervalMs.ToString();
        }
    }
}
