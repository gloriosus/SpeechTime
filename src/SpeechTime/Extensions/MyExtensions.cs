using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTime.Extensions
{
    public static class MyExtensions
    {
        public static int AsNumber(this bool b) => b ? 1 : 0;
    }
}
