namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Children)]
internal class NumberInputTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_number";

    public NumberInputTests(AppManagerOptions options)
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
    public void ShouldGetValueRange()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act
        double minValue = numberInputPage.QuantityNumberInput.Minimum;
        double maxValue = numberInputPage.QuantityNumberInput.Maximum;

        // Assert
        minValue.ShouldBe(1);
        maxValue.ShouldBe(5);
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act
        numberInputPage.QuantityNumberInput.SetValue(3);

        // Assert
        numberInputPage.QuantityNumberInput.Value.ShouldBe(3);
    }

    [Test]
    public void ShouldThrowOutOfRangeExceptionIfValueIsLessThanMinimum()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => numberInputPage.QuantityNumberInput.SetValue(0));
    }

    [Test]
    public void ShouldThrowOutOfRangeExceptionIfValueIsGreaterThanMaximum()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => numberInputPage.QuantityNumberInput.SetValue(6));
    }

    [Test]
    public void ShouldIncrementValue()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        numberInputPage.SetQuantity(3);

        // Act
        numberInputPage.QuantityNumberInput.Increment();

        // Assert
        numberInputPage.QuantityNumberInput.Value.ShouldBe(4);
    }

    [Test]
    public void ShouldDecrementValue()
    {
        // Arrange
        RemoteWebDriver app = this.StartApp();

        NumberInputPage numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        numberInputPage.SetQuantity(3);

        // Act
        numberInputPage.QuantityNumberInput.Decrement();

        // Assert
        numberInputPage.QuantityNumberInput.Value.ShouldBe(2);
    }
}