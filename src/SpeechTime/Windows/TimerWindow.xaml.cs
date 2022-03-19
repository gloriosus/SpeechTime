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
    /// Interaction logic for TimerWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        private Timer timer = Timer.Instance;

        internal DispatcherTimer DispatcherTimer;

        public TimerWindow()
        {
            InitializeComponent();

            WindowHelper.PlaceWindowOnScreen(this, AppSettings.TimerWindowScreen);

            var backgroundImage = new ImageBrush(new BitmapImage(new Uri(AppSettings.TimerWindowBackgroundImage, UriKind.Absolute)));
            backgroundImage.Stretch = Stretch.Fill;

            this.Background = backgroundImage;

            DispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(AppSettings.UIUpdateIntervalMs), DispatcherPriority.Normal, dispatcherTimer_Tick, this.Dispatcher);
            DispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timerValue = timer.CurrentValue;
            TimerValueLabel.Content = timerValue.ToString(@"hh\:mm\:ss");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
