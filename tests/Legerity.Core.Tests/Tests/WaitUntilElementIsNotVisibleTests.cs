using System;
using System.IO;
using Legerity.Core.Tests.Pages;
using Legerity.Extensions;
using Legerity.Helpers;
using Legerity.Web;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class WaitUntilElementIsNotVisibleTests : BaseTestClass
{
    [Test]
    public void ShouldWaitUntilElementIsNotVisible()
    {
        // Arrange
        var options = new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = new ChromeOptions()
        };

        var app = StartApp(options);

        new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        app.WaitUntil(WaitUntilConditions.ElementIsNotVisible(By.TagName("select")), ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsNotVisibleInElement()
    {
        // Arrange
        var options = new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = new ChromeOptions()
        };

        var app = StartApp(options);

        var page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        var element = page.FindElement(By.TagName("form"));

        // Act & Assert
        element.WaitUntil(WaitUntilConditions.ElementIsNotVisibleInElement<WebElement>(By.TagName("select")),
            ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsNotVisibleInElementWrapper()
    {
        // Arrange
        var options = new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = new ChromeOptions()
        };

        var app = StartApp(options);

        var page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        Form form = page.FindElement(By.TagName("form"));

        // Act & Assert
        form.WaitUntil(WaitUntilConditions.ElementIsNotVisibleInElementWrapper<WebElement>(By.TagName("select")),
            ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsNotVisibleInPageObject()
    {
        // Arrange
        var options = new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = new ChromeOptions()
        };

        var app = StartApp(options);

        var page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        page.WaitUntil(WaitUntilConditions.ElementIsNotVisibleInPage<W3SchoolsPage>(By.TagName("select")), ImplicitWait);
    }
}
