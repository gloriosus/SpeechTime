using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SpeechTime.Helpers;
using SpeechTime.Clocks;

namespace SpeechTime.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PanelWindow : Window
    {
        private Timer timer = Timer.Instance;
        private Stopwatch stopwatch = Stopwatch.Instance;
        private Bleeper bleeper;
        private DispatcherTimer dispatcherTimer;

        public PanelWindow()
        {
            InitializeComponent();

            WindowHelper.PlaceWindowOnScreen(this);

            timer.InitialValue = AppSettings.TimerLimit;
            bleeper = new Bleeper(AppSettings.Bleeper);

            dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(AppSettings.UIUpdateIntervalMs), DispatcherPriority.Normal, dispatcherTimer_Tick, this.Dispatcher);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTimeValue = DateTime.Now;
            TimeSpan timerValue = timer.CurrentValue;
            TimeSpan stopwatchValue = stopwatch.CurrentValue;

            CurrentDateTimeLabel.Content = "Время местное: " + dateTimeValue.ToString("HH:mm:ss dd.MM.yyyy");
            TimerValueLabel.Content = "Время доклада: " + timerValue.ToString(@"hh\:mm\:ss");
            StopwatchValueLabel.Content = "Время совещания: " + stopwatchValue.ToString(@"hh\:mm\:ss");

            bleeper.Play(timerValue, new TimeSpan(0, 0, 10));

            if (timerValue.Equals(TimeSpan.Zero))
                timer.Reset();
        }
    }
}
