using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using SpeechTime.Extensions;

namespace SpeechTime.Clocks
{
    public class Stopwatch : IClockable
    {
        public TimeSpan CurrentValue => GetCurrentValue();

        public bool IsEnabled { get; private set; } = false;

        private long startTimeTicks;
        private long endTimeTicks;
        private long temp;

        private static Stopwatch instance;
        public static Stopwatch Instance => GetInstance();

        public Stopwatch()
        {
            startTimeTicks = 0;
            endTimeTicks = 0;
            temp = 0;
        }

        public void Start()
        {
            IsEnabled = true;
            startTimeTicks = DateTime.Now.Ticks;
        }

        public void Start(long syncDiff)
        {
            IsEnabled = true;
            startTimeTicks = DateTime.Now.Ticks - syncDiff;
            endTimeTicks = 0;
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

            return currentValue;
        }

        private static Stopwatch GetInstance()
        {
            if (instance == null)
                instance = new Stopwatch();
            return instance;
        }
    }
}
