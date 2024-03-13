using System;
using System.Collections.Generic;
using System.IO;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
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
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act
        var minValue = numberInputPage.QuantityNumberInput.Minimum;
        var maxValue = numberInputPage.QuantityNumberInput.Maximum;

        // Assert
        minValue.ShouldBe(1);
        maxValue.ShouldBe(5);
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
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
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => numberInputPage.QuantityNumberInput.SetValue(0));
    }

    [Test]
    public void ShouldThrowOutOfRangeExceptionIfValueIsGreaterThanMaximum()
    {
        // Arrange
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => numberInputPage.QuantityNumberInput.SetValue(6));
    }

    [Test]
    public void ShouldIncrementValue()
    {
        // Arrange
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
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
        var app = StartApp();

        var numberInputPage = new NumberInputPage(app)
            .AcceptCookies<NumberInputPage>()
            .SwitchToContentFrame<NumberInputPage>();

        numberInputPage.SetQuantity(3);

        // Act
        numberInputPage.QuantityNumberInput.Decrement();

        // Assert
        numberInputPage.QuantityNumberInput.Value.ShouldBe(2);
    }
}
