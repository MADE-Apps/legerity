namespace Legerity.Core.Tests.Tests;

using System;
using System.IO;
using Extensions;
using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages;
using Web.Elements.Core;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
internal class WaitUntilElementIsVisibleTests : BaseTestClass
{
    [Test]
    public void ShouldWaitUntilElementIsVisible()
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

        RemoteWebDriver app = this.StartApp(options);

        new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        app.WaitUntil(WaitUntilConditions.ElementIsVisible(By.TagName("input")), ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsVisibleInElement()
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

        RemoteWebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        RemoteWebElement element = page.FindElement(By.TagName("form"));

        // Act & Assert
        element.WaitUntil(WaitUntilConditions.ElementIsVisibleInElement<RemoteWebElement>(By.TagName("input")),
            ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsVisibleInElementWrapper()
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

        RemoteWebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        Form form = page.FindElement(By.TagName("form"));

        // Act & Assert
        form.WaitUntil(WaitUntilConditions.ElementIsVisibleInElementWrapper<RemoteWebElement>(By.TagName("input")),
            ImplicitWait);
    }

    [Test]
    public void ShouldWaitUntilElementIsVisibleInPageObject()
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

        RemoteWebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        page.WaitUntil(WaitUntilConditions.ElementIsVisibleInPage<W3SchoolsPage>(By.TagName("input")), ImplicitWait);
    }
}