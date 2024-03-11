namespace Legerity.Core.Tests.Tests;

using System;
using System.Collections.ObjectModel;
using System.IO;
using Legerity.Core.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Shouldly;
using Web.Extensions;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class ByNestedTests : BaseTestClass
{
    [Test]
    public void ShouldFindElementByNested()
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

        // Act
        WebElement element = page.FindElement(new ByNested(By.TagName("form"), By.TagName("input")));

        // Assert
        element.ShouldNotBeNull();
        element.GetValue().ShouldBe("HTML");
    }

    [Test]
    public void ShouldFindElementsByNested()
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

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(new ByNested(By.TagName("form"), WebByExtras.InputType("radio")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBe(6);
    }

    [Test]
    public void ShouldThrowNoSuchElementExceptionIfFindElementReturnsNoResult()
    {
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
        Should.Throw<NoSuchElementException>(
            () => page.FindElement(new ByNested(By.TagName("form"), By.TagName("div"))));
    }

    [Test]
    public void ShouldReturnEmptyCollectionIfFindElementsReturnsNoResult()
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

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(new ByNested(By.TagName("form"), By.TagName("div")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBe(0);
    }
}