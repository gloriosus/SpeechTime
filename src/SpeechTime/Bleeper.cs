using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SpeechTime.Clocks;

namespace SpeechTime
{
    public class Bleeper
    {
        private MediaPlayer mediaPlayer;
        private bool wasFired = false;

        public Bleeper(string filePath)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(filePath));
        }

        public void Play(TimeSpan currentValue, TimeSpan timeBeforeFiring)
        {
            if (currentValue.Ticks < timeBeforeFiring.Ticks)
            {
                if (!wasFired)
                {
                    wasFired = true;

                    if (mediaPlayer.HasAudio)
                    {
                        mediaPlayer.Position = TimeSpan.Zero;
                        mediaPlayer.Play();
                    }
                }
            }
            else
            {
                wasFired = false;
            }
        }
    }
}
