using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using SpeechTime.Extensions;

namespace SpeechTime.Clocks
{
    public class Timer : IClockable
    {
        public TimeSpan InitialValue { get; set; }
        public TimeSpan CurrentValue => GetCurrentValue();

        public bool IsEnabled { get; private set; } = false;

        private long startTimeTicks;
        private long endTimeTicks;
        private long temp;

        private static Timer instance;
        public static Timer Instance => GetInstance();

        public Timer()
        {
            startTimeTicks = 0;
            endTimeTicks = 0;
            temp = 0;
            InitialValue = TimeSpan.Zero;
        }

        public void Start()
        {
            IsEnabled = true;
            startTimeTicks = DateTime.Now.Ticks;
        }

        public void Stop()
        {
            IsEnabled = false;
            endTimeTicks = DateTime.Now.Ticks;
            temp = temp + (endTimeTicks - startTimeTicks);
        }

        public void Reset()
        {
            IsEnabled = false;
            startTimeTicks = 0;
            endTimeTicks = 0;
            temp = 0;
        }

        private TimeSpan GetCurrentValue()
        {
            var n = IsEnabled.AsNumber();

            // When the stopwatch is stopped only the last endTimeTicks from the moment of stopping is taken for further calculation otherwise a new endTimeTicks is calculated from the current DateTime and the counting continues
            endTimeTicks = endTimeTicks * (1 - n) + DateTime.Now.Ticks * n;

            // When the stopwatch is stopped new ticks are not counted
            long diff = temp + (endTimeTicks - startTimeTicks) * n;

            TimeSpan currentValue = new TimeSpan(diff);

            return currentValue < InitialValue ? InitialValue - currentValue : TimeSpan.Zero;
        }

        private static Timer GetInstance()
        {
            if (instance == null)
                instance = new Timer();
            return instance;
        }
    }
}
