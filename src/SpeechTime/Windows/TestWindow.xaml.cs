using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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

namespace SpeechTime.Windows
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window, INotifyPropertyChanged
    {
        public TestWindow()
        {
            InitializeComponent();

            StopwatchLabel.SetBinding(ContentProperty, new Binding("StopwatchLabelText"));
            TimerLabel.SetBinding(ContentProperty, new Binding("TimerLabelText"));
            DataContext = this;

            guiTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(200), DispatcherPriority.Normal, guiTimer_Tick, this.Dispatcher);
            guiTimer.Start();
        }

        private DispatcherTimer guiTimer;

        private void guiTimer_Tick(object sender, EventArgs e)
        {
            StopwatchLabelText = Stopwatch.Instance.CurrentValue.ToString(@"hh\:mm\:ss");
            TimerLabelText = Timer.Instance.CurrentValue.ToString(@"hh\:mm\:ss");
        }

        private string stopwatchLabelText;
        public string StopwatchLabelText
        {
            get
            {
                return stopwatchLabelText;
            }
            set
            {
                if (value != stopwatchLabelText)
                {
                    stopwatchLabelText = value;
                    OnPropertyChanged("StopwatchLabelText");
                }
            }
        }

        private string timerLabelText;
        public string TimerLabelText
        {
            get
            {
                return timerLabelText;
            }
            set
            {
                if (value != timerLabelText)
                {
                    timerLabelText = value;
                    OnPropertyChanged("TimerLabelText");
                }
            }
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!Stopwatch.Instance.IsEnabled)
                {
                    Stopwatch.Instance.Start();
                }
                else
                {
                    Stopwatch.Instance.Stop();
                }
            }

            if (e.Key == Key.Escape)
            {
                Stopwatch.Instance.Reset();
            }

            if (e.Key == Key.F1)
            {
                MessageBox.Show(AppSettings.TargetTimeZone);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Stopwatch.Instance.IsEnabled)
            {
                Stopwatch.Instance.Start();
            }
            else
            {
                Stopwatch.Instance.Stop();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Timer.Instance.IsEnabled)
            {
                Timer.Instance.Start();
            }
            else
            {
                Timer.Instance.Stop();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SystemSounds.Question.Play();
        }
    }
}
