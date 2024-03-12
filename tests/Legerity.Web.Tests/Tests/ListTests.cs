namespace Legerity.Web.Tests.Tests;

using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class ListTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_lists";

    public ListTests(AppManagerOptions options)
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
    public void ShouldContainItems()
    {
        // Arrange
        var app = StartApp();

        var listPage = new ListPage(app)
            .AcceptCookies<ListPage>()
            .SwitchToContentFrame<ListPage>();

        // Act 
        var items = listPage.OrderedList.Items.Select(i => i.Text);

        // Assert
        items.ShouldContain("Coffee");
        items.ShouldContain("Tea");
        items.ShouldContain("Milk");
    }
}
