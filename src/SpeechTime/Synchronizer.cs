using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpeechTime.Clocks;

namespace SpeechTime
{
    public class Synchronizer
    {
        public bool IsSynchronized { get; set; } = false;
        public DateTime CurrentDateTime => DateTime.Now;

        private long GetSyncDiff()
        {
            //var cutDateTime = CurrentDateTime.ToString("HH:mm:ss dd.MM.yyyy");
            //var roundedDateTime = DateTime.Parse(cutDateTime);

            var withoutMs = new DateTime(CurrentDateTime.Year, CurrentDateTime.Month, CurrentDateTime.Day, CurrentDateTime.Hour, CurrentDateTime.Minute, CurrentDateTime.Second);

            return CurrentDateTime.Subtract(withoutMs).Ticks;
        }

        public Synchronizer() { }

        public Synchronizer(bool isSynchronized)
        {
            IsSynchronized = isSynchronized;
        }

        public void Start(IClockable clock)
        {
            if (IsSynchronized)
                clock.Start(GetSyncDiff());
            else
                clock.Start();
        }
    }
}
