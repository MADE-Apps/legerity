// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using Legerity.Core.Tests.Pages;
using Legerity.Extensions;
using OpenQA.Selenium;
using Shouldly;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class ByExtensionsTests : BaseTestClass
{
    [Test]
    public void ShouldFindElementWithText()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        WebElement element = page.FindElement(By.TagName("p").WithPartialText("Please select"));

        // Assert
        element.ShouldNotBeNull();
        element.Text.ShouldBe("Please select your favorite Web language:");
    }

    [Test]
    public void ShouldFindElementsWithPartialText()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(By.TagName("p").WithPartialText("Please select"));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBe(2);
    }

    [Test]
    public void ShouldFindNestedElementWithThenFind()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        ReadOnlyCollection<WebElement> elements =
            page.FindElements(By.TagName("form").ThenFind(By.TagName("input")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBeGreaterThan(0);
    }

    [Test]
    public void ShouldFindElementWithAttribute()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        WebElement element = page.FindElement(By.TagName("input").WithAttribute("type", "radio"));

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldFindElementWithAndChaining()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act - find a paragraph that also contains specific text
        WebElement element = page.FindElement(By.TagName("p").And(ByExtras.PartialText("Please select")));

        // Assert
        element.ShouldNotBeNull();
        element.Text.ShouldContain("Please select");
    }

    [Test]
    public void ShouldFindElementWithThatBuilder()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act
        WebElement element = page.FindElement(
            By.TagName("p").That(by => by.HasPartialText("Please select")));

        // Assert
        element.ShouldNotBeNull();
        element.Text.ShouldContain("Please select");
    }

    [Test]
    public void ShouldFindElementWithThatBuilderMultipleConstraints()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act - find input that has type=radio AND name=fav_language
        WebElement element = page.FindElement(
            By.TagName("input").That(by => by
                .HasAttribute("type", "radio")
                .HasAttribute("name", "fav_language")));

        // Assert
        element.ShouldNotBeNull();
    }

    [Test]
    public void ShouldFindElementWithThenFindBuilder()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act - find input elements within form using builder
        ReadOnlyCollection<WebElement> elements = page.FindElements(
            By.TagName("form").ThenFind(by => by.TagName("input")));

        // Assert
        elements.ShouldNotBeNull();
        elements.Count.ShouldBeGreaterThan(0);
    }

    [Test]
    public void ShouldFindElementWithThenFindBuilderAndConstraints()
    {
        // Arrange
        WebDriver app = this.StartW3SchoolsRadioApp();

        W3SchoolsPage page = new W3SchoolsPage(app)
            .AcceptCookies<W3SchoolsPage>()
            .SwitchToContentFrame<W3SchoolsPage>();

        // Act - find radio inputs within form using builder
        WebElement element = page.FindElement(
            By.TagName("form").ThenFind(by => by
                .TagName("input")
                .HasAttribute("type", "radio")));

        // Assert
        element.ShouldNotBeNull();
    }

    private WebDriver StartW3SchoolsRadioApp()
    {
        return this.StartApp(CreateChromeOptions("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio"));
    }
}