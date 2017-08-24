﻿namespace Gu.Wpf.UiAutomation.UITests.Patterns
{
    using System.IO;
    using NUnit.Framework;

    public class GridPatternTests
    {
        private static readonly string ExeFileName = Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            @"..\..\TestApplications\WpfApplication\bin\WpfApplication.exe");

        [Test]
        public void GridTest()
        {
            using (var app = Application.Launch(ExeFileName, "DataGridWindow"))
            {
                var window = app.MainWindow();
                var dataGrid = window.FindDataGrid();
                Assert.NotNull(dataGrid);
                var gridPattern = dataGrid.Patterns.Grid.Pattern;
                Assert.AreEqual(2, gridPattern.ColumnCount.Value);
                Assert.AreEqual(4, gridPattern.RowCount.Value);

                var item = gridPattern.GetItem(1, 1);
                Assert.AreEqual("Item 2", item.Properties.Name.Value);
            }
        }
    }
}
