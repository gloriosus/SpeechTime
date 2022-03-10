using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using SpeechTime.Helpers;
using System.Windows.Media;

namespace SpeechTime.Tests
{
    [TestClass]
    public class SettingsHelperTest
    {
        [TestMethod]
        public void GetAbsolutePath_Null_ReturnsAppDirectory()
        {
            var expected = AppDomain.CurrentDomain.BaseDirectory;

            var actual = SettingsHelper.GetAbsolutePath(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAbsolutePath_Empty_ReturnsAppDirectory()
        {
            var expected = AppDomain.CurrentDomain.BaseDirectory;

            var actual = SettingsHelper.GetAbsolutePath(String.Empty);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAbsolutePath_WithSlash_ReturnsPathWithoutSlashDuplicates()
        {
            var expected = AppDomain.CurrentDomain.BaseDirectory + @"Resources\bleeper.wav";

            var actual = SettingsHelper.GetAbsolutePath(@"\Resources\bleeper.wav");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_SomeText_Returns1()
        {
            var expected = 1;

            var actual = SettingsHelper.GetValueOrDefault("SomeText", 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_5_Returns5()
        {
            var expected = 5;

            var actual = SettingsHelper.GetValueOrDefault("5", 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_SomeText_ReturnsTimeSpanZero()
        {
            var expected = TimeSpan.Zero;

            var actual = SettingsHelper.GetValueOrDefault("SomeText", TimeSpan.Zero);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_TimeSpan000530_ReturnsTimeSpan000530()
        {
            var expected = new TimeSpan(0, 5, 30);

            var actual = SettingsHelper.GetValueOrDefault("00:05:30", TimeSpan.Zero);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_SomeText_ReturnsColorAqua()
        {
            var expected = Colors.Aqua;

            var actual = SettingsHelper.GetValueOrDefault("SomeText", Colors.Aqua);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_00ffff_ReturnsColorAqua()
        {
            var expected = Colors.Aqua;

            var actual = SettingsHelper.GetValueOrDefault("#00ffff", Colors.Red);

            Assert.AreEqual(expected, actual);
        }
    }
}
