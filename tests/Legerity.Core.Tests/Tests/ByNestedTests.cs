// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using Legerity.Core.Tests.Pages;
using Legerity.Web.Extensions;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class ByNestedTests : BaseTestClass
{
    [Test]
    public void ShouldFindElementByNested()
    {
        // Arrange
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

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
        var options = CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio");

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