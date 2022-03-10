using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SpeechTime.Extensions
{
    public static class MyExtensions
    {
        public static int AsNumber(this bool b) => b ? 1 : 0;
        public static string ToHexString(this Color color) => string.Format("{0}{1:x2}{2:x2}{3:x2}", "#", color.R, color.G, color.B);
    }
}
