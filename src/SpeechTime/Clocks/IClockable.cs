using System;

namespace SpeechTime.Clocks
{
    public interface IClockable
    {
        TimeSpan CurrentValue { get; }
        bool IsEnabled { get; }

        void Start();
        void Start(long syncDiff);
        void Stop();
        void Reset();
    }
}