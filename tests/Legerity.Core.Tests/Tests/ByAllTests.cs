namespace Legerity.Core.Tests.Tests;

using System;
using System.Collections.ObjectModel;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class ByAllTests : BaseTestClass
{
    [Test]
    public void ShouldFindElementByAll()
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

        WebDriver app = StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        WebElement element = page.FindElement(new ByAll(By.TagName("p"), ByExtras.PartialText("Please select")));

        // Assert
        element.ShouldNotBeNull();
        element.Text.ShouldBe("Please select your favorite Web language:");
    }

    [Test]
    public void ShouldFindElementsByAll()
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

        WebDriver app = StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(new ByAll(By.TagName("p"), ByExtras.PartialText("Please select")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBe(2);
    }

    [Test]
    public void ShouldThrowNoSuchElementExceptionIfFindElementReturnsNoResult()
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

        WebDriver app = StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act & Assert
        Should.Throw<NoSuchElementException>(() =>
            page.FindElement(new ByAll(By.TagName("p"), ByExtras.PartialText("This text does not exist"))));
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

        WebDriver app = StartApp(options);

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(new ByAll(By.TagName("p"), ByExtras.PartialText("This text does not exist")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBe(0);
    }
}