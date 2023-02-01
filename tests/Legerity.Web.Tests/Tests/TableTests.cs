namespace Legerity.Web.Tests.Tests;

using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Elements.Core;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Children)]
internal class TableTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_table_intro";

    public TableTests(AppManagerOptions options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the platform options to run tests on.
    /// </summary>
    protected static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait, DriverOptions = ConfigureChromeOptions()
        }
    };

    [Test]
    public void ShouldGetTableHeaders()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IEnumerable<string> headers = tablePage.Table.Headers;

        // Assert
        headers.Count().ShouldBe(3);
        headers.ShouldContain("Company");
        headers.ShouldContain("Contact");
        headers.ShouldContain("Country");
    }

    [Test]
    public void ShouldGetTableRows()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IEnumerable<TableRow> rows = tablePage.Table.Rows;

        // Assert
        rows.Count().ShouldBe(7);
    }

    [Test]
    public void ShouldGetDataTableRows()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IEnumerable<TableRow> rows = tablePage.Table.DataRows;

        // Assert
        rows.Count().ShouldBe(6);
    }

    [Test]
    public void ShouldGetRowDataByIndex()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IReadOnlyDictionary<string, string> rowData = tablePage.Table.GetRowDataByIndex(0);

        // Assert
        rowData.Count.ShouldBe(3);
        rowData["Company"].ShouldBe("Alfreds Futterkiste");
        rowData["Contact"].ShouldBe("Maria Anders");
        rowData["Country"].ShouldBe("Germany");
    }

    [Test]
    public void ShouldGetColumnDataByIndex()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IEnumerable<string> columnData = tablePage.Table.GetColumnDataByIndex(0);

        // Assert
        columnData.Count().ShouldBe(6);
        columnData.ShouldContain("Alfreds Futterkiste");
        columnData.ShouldContain("Centro comercial Moctezuma");
        columnData.ShouldContain("Ernst Handel");
        columnData.ShouldContain("Island Trading");
        columnData.ShouldContain("Laughing Bacchus Winecellars");
        columnData.ShouldContain("Magazzini Alimentari Riuniti");
    }

    [Test]
    public void ShouldGetColumnDataByHeader()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        TablePage tablePage = new TablePage(app)
            .AcceptCookies<TablePage>()
            .SwitchToContentFrame<TablePage>();

        // Act
        IEnumerable<string> columnData = tablePage.Table.GetColumnDataByHeader("Company");

        // Assert
        columnData.Count().ShouldBe(6);
        columnData.ShouldContain("Alfreds Futterkiste");
        columnData.ShouldContain("Centro comercial Moctezuma");
        columnData.ShouldContain("Ernst Handel");
        columnData.ShouldContain("Island Trading");
        columnData.ShouldContain("Laughing Bacchus Winecellars");
        columnData.ShouldContain("Magazzini Alimentari Riuniti");
    }
}