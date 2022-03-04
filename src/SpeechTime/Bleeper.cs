using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

using SpeechTime.Clocks;

namespace SpeechTime
{
    public class Bleeper
    {
        private SoundPlayer soundPlayer;
        private bool wasFired = false;

        public Bleeper(string filePath)
        {
            soundPlayer = new SoundPlayer(filePath);
            soundPlayer.Load();
        }

        public void Play(TimeSpan currentValue, TimeSpan timeBeforeFiring)
        {
            if (currentValue.Ticks < timeBeforeFiring.Ticks)
            {
                if (!wasFired)
                {
                    wasFired = true;
                    soundPlayer.Play();
                }
            }
            else
            {
                wasFired = false;
            }
        }
    }
}
