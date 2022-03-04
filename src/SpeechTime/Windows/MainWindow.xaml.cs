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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Bleeper bleeper;

        public MainWindow()
        {
            InitializeComponent();

            WindowHelper.PlaceWindowOnScreen(this);

            CurrentDateTimeLabel.SetBinding(ContentProperty, new Binding("CurrentDateTimeLabelText"));
            SpeechTimeLimitLabel.SetBinding(ContentProperty, new Binding("SpeechTimeLimitLabelText"));
            TotalTimeLabel.SetBinding(ContentProperty, new Binding("TotalTimeLabelText"));
            DataContext = this;

            Timer.Instance.InitialValue = AppSettings.SpeechTimeLimit;

            bleeper = new Bleeper(AppSettings.SignalSound);

            uiUpdateTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(AppSettings.UIUpdateIntervalMs), DispatcherPriority.Normal, uiUpdateTimer_Tick, this.Dispatcher);
            uiUpdateTimer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref this.PropertyChanged, null, null);

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private DispatcherTimer uiUpdateTimer;

        private string currentDateTimeLabelText;
        public string CurrentDateTimeLabelText
        {
            get
            {
                return currentDateTimeLabelText;
            }
            set
            {
                if (value != currentDateTimeLabelText)
                {
                    currentDateTimeLabelText = value;
                    OnPropertyChanged("CurrentDateTimeLabelText");
                }
            }
        }

        private string speechTimeLimitLabelText;
        public string SpeechTimeLimitLabelText
        {
            get
            {
                return speechTimeLimitLabelText;
            }
            set
            {
                if (value != speechTimeLimitLabelText)
                {
                    speechTimeLimitLabelText = value;
                    OnPropertyChanged("SpeechTimeLimitLabelText");
                }
            }
        }

        private string totalTimeLabelText;
        public string TotalTimeLabelText
        {
            get
            {
                return totalTimeLabelText;
            }
            set
            {
                if (value != totalTimeLabelText)
                {
                    totalTimeLabelText = value;
                    OnPropertyChanged("TotalTimeLabelText");
                }
            }
        }

        private void uiUpdateTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTimeValue = synchronizer.CurrentDateTime;
            TimeSpan timerValue = Timer.Instance.CurrentValue;
            TimeSpan stopwatchValue = Stopwatch.Instance.CurrentValue;

            CurrentDateTimeLabelText = AppSettings.TargetTimeZoneLabel + dateTimeValue.ToString("HH:mm:ss dd.MM.yyyy");
            SpeechTimeLimitLabelText = "Время доклада: " + timerValue.ToString(@"hh\:mm\:ss");
            TotalTimeLabelText = "Время совещания: " + stopwatchValue.ToString(@"hh\:mm\:ss");

            bleeper.Play(timerValue, new TimeSpan(0, 0, 10));

            if (timerValue.Equals(TimeSpan.Zero))
                Timer.Instance.Reset();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                if (!Timer.Instance.IsEnabled)
                    Timer.Instance.Start();
                else
                    Timer.Instance.Stop();
            }

            if (e.Key == Key.F2)
            {
                if (!Stopwatch.Instance.IsEnabled)
                    synchronizer.Start(Stopwatch.Instance);
                else
                    Stopwatch.Instance.Stop();
            }

            if (e.Key == Key.F3)
            {
                var d1 = new DateTime(2022, 03, 04, 17, 19, 23, 300);
                var d2 = new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second);
                var t1 = d1.Ticks;

                var cut = t1 / 10000000L;

                var result = d1.Ticks - d2.Ticks;

                MessageBox.Show(d1.Subtract(d2).ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
            }
        }

        private Synchronizer synchronizer = new Synchronizer(true);
    }
}
