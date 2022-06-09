namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Legerity;
    using Legerity.Extensions;
    using Legerity.Web;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TableTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_table_intro";

        public TableTests(AppManagerOptions options)
            : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WebAppManagerOptions(
                WebAppDriverType.Chrome,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            }
        };

        [Test]
        public void ShouldGetHeaders()
        {
            // Arrange
            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            var headers = table.Headers.ToList();

            // Assert
            headers.ShouldBeEquivalentTo(new List<string> { "Company", "Contact", "Country" });
        }

        [Test]
        public void ShouldGetRows()
        {
            // Arrange
            var expectedRowValues = new List<IEnumerable<string>>
            {
                new List<string> {"Company", "Contact", "Country"},
                new List<string> {"Alfreds Futterkiste", "Maria Anders", "Germany"},
                new List<string> {"Centro comercial Moctezuma", "Francisco Chang", "Mexico"},
                new List<string> {"Ernst Handel", "Roland Mendel", "Austria"},
                new List<string> {"Island Trading", "Helen Bennett", "UK"},
                new List<string> {"Laughing Bacchus Winecellars", "Yoshi Tannamuri", "Canada"},
                new List<string> {"Magazzini Alimentari Riuniti", "Giovanni Rovelli", "Italy"},
            };

            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            var rows = table.Rows.ToList();

            // Assert
            for (int index = 0; index < rows.Count; index++)
            {
                TableRow row = rows[index];
                row.Values.ToList().ShouldBeEquivalentTo(expectedRowValues[index]);
            }
        }

        [Test]
        public void ShouldGetDataRows()
        {
            // Arrange
            var expectedRowValues = new List<IEnumerable<string>>
            {
                new List<string> {"Alfreds Futterkiste", "Maria Anders", "Germany"},
                new List<string> {"Centro comercial Moctezuma", "Francisco Chang", "Mexico"},
                new List<string> {"Ernst Handel", "Roland Mendel", "Austria"},
                new List<string> {"Island Trading", "Helen Bennett", "UK"},
                new List<string> {"Laughing Bacchus Winecellars", "Yoshi Tannamuri", "Canada"},
                new List<string> {"Magazzini Alimentari Riuniti", "Giovanni Rovelli", "Italy"},
            };

            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            var rows = table.DataRows.ToList();

            // Assert
            rows.Count.ShouldBe(expectedRowValues.Count);

            for (int index = 0; index < rows.Count; index++)
            {
                TableRow row = rows[index];
                row.Values.ToList().ShouldBeEquivalentTo(expectedRowValues[index]);
            }
        }

        [Test]
        public void ShouldGetRowValuesByRowIndex()
        {
            // Arrange
            var expectedRowValues = new Dictionary<string, string>
            {
                {"Company", "Alfreds Futterkiste"}, {"Contact", "Maria Anders"}, {"Country", "Germany"}
            };

            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            IReadOnlyDictionary<string, string> rowData = table.GetRowDataByIndex(0);

            // Assert
            rowData.Count.ShouldBe(expectedRowValues.Count);

            foreach (KeyValuePair<string, string> row in rowData)
            {
                expectedRowValues.ShouldContainKeyAndValue(row.Key, row.Value);
            }
        }


        [Test]
        public void ShouldGetColumnValuesByColumnHeader()
        {
            // Arrange
            var expectedColumnValues = new List<string>
            {
                "Alfreds Futterkiste",
                "Centro comercial Moctezuma",
                "Ernst Handel",
                "Island Trading",
                "Laughing Bacchus Winecellars",
                "Magazzini Alimentari Riuniti"
            };

            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            var columnData = table.GetColumnDataByHeader("Company").ToList();

            // Assert
            columnData.Count.ShouldBe(expectedColumnValues.Count);

            foreach (string columnValue in columnData)
            {
                expectedColumnValues.ShouldContain(columnValue);
            }
        }

        [Test]
        public void ShouldGetColumnValuesByColumnIndex()
        {
            // Arrange
            var expectedColumnValues = new List<string>
            {
                "Alfreds Futterkiste",
                "Centro comercial Moctezuma",
                "Ernst Handel",
                "Island Trading",
                "Laughing Bacchus Winecellars",
                "Magazzini Alimentari Riuniti"
            };

            Table table = this.App.FindWebElement(By.TagName("table"));

            // Act
            var columnData = table.GetColumnDataByIndex(0).ToList();

            // Assert
            columnData.Count.ShouldBe(expectedColumnValues.Count);

            foreach (string columnValue in columnData)
            {
                expectedColumnValues.ShouldContain(columnValue);
            }
        }
    }
}