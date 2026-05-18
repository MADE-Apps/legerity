// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using Legerity.Core.Tests.Pages;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class ByAllTests : BaseTestClass
{
    [Test]
    public void ShouldFindElementByAll()
    {
        // Arrange
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

        WebDriver app = this.StartApp(options);

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

        WebDriver app = this.StartApp(options);

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

        WebDriver app = this.StartApp(options);

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

        WebDriver app = this.StartApp(options);

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