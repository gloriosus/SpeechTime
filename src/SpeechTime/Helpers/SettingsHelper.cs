using System;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace SpeechTime.Helpers
{
    public static class SettingsHelper
    {
        public static string GetAbsolutePath(string relativePath)
        {
            while (relativePath[0].Equals(@"\"))
            {
                relativePath = relativePath.Substring(1);
            }

            return AppDomain.CurrentDomain.BaseDirectory + relativePath;
        }

        public static TimeSpan GetValueOrDefault(string value, TimeSpan defaultValue)
        {
            var temp = defaultValue;
            TimeSpan.TryParse(value, out temp);
            return temp;
        }

        public static int GetValueOrDefault(string value, int defaultValue)
        {
            var temp = defaultValue;
            Int32.TryParse(value, out temp);
            return temp;
        }

        public static Color GetValueOrDefault(string value, Color defaultValue)
        {
            if (Regex.Match(value, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
            {
                return (Color)ColorConverter.ConvertFromString(value);
            }

            return defaultValue;
        }
    }
}
