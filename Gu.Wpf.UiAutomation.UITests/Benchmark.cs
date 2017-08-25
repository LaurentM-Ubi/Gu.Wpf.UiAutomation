﻿namespace Gu.Wpf.UiAutomation.UITests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using NUnit.Framework;

    public class Benchmark
    {
        private static readonly string ExeFileName = Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            @"..\..\TestApplications\WpfApplication\bin\WpfApplication.exe");

        [Test]
        public void EmptyWindow()
        {
            var sw = Stopwatch.StartNew();
            using (var app = Application.Launch(ExeFileName, "EmptyWindow"))
            {
                var launch = sw.Elapsed;
                var window1 = app.MainWindow();
                var firstWindow = sw.Elapsed;
                var window2 = app.MainWindow();
                sw.Stop();
                Assert.NotNull(window1);
                Assert.AreNotSame(window1, window2);
                Console.WriteLine($"Launch       {launch.TotalMilliseconds:F0} ms");
                Console.WriteLine($"MainWindow 1 {firstWindow.TotalMilliseconds - launch.TotalMilliseconds:F0} ms ({sw.ElapsedMilliseconds})");
                Console.WriteLine($"MainWindow 2 {sw.ElapsedMilliseconds - firstWindow.TotalMilliseconds:F0} ms ({sw.ElapsedMilliseconds})");
            }
        }
    }
}