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

        WebDriver app = this.StartApp(options);

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

        WebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        WebElement element = page.FindElement(By.TagName("form"));

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

        WebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
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

        WebDriver app = this.StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        page.WaitUntil(WaitUntilConditions.ElementIsNotVisibleInPage<W3SchoolsPage>(By.TagName("select")), ImplicitWait);
    }
}