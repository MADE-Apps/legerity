namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class RangeInputTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_range";

    public RangeInputTests(AppManagerOptions options)
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

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        // Act
        var minValue = rangeInputPage.VolumeRangeInput.Minimum;
        var maxValue = rangeInputPage.VolumeRangeInput.Maximum;

        // Assert
        minValue.ShouldBe(0);
        maxValue.ShouldBe(50);
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        var app = StartApp();

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        // Act
        rangeInputPage.VolumeRangeInput.SetValue(10);

        // Assert
        rangeInputPage.VolumeRangeInput.Value.ShouldBe(10);
    }

    [Test]
    public void ShouldThrowOutOfRangeExceptionIfValueIsLessThanMinimum()
    {
        // Arrange
        var app = StartApp();

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => rangeInputPage.VolumeRangeInput.SetValue(-1));
    }

    [Test]
    public void ShouldThrowOutOfRangeExceptionIfValueIsGreaterThanMaximum()
    {
        // Arrange
        var app = StartApp();

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => rangeInputPage.VolumeRangeInput.SetValue(51));
    }

    [Test]
    public void ShouldIncrementValue()
    {
        // Arrange
        var app = StartApp();

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        rangeInputPage.SetVolume(25);

        // Act
        rangeInputPage.VolumeRangeInput.Increment();

        // Assert
        rangeInputPage.VolumeRangeInput.Value.ShouldBe(26);
    }

    [Test]
    public void ShouldDecrementValue()
    {
        // Arrange
        var app = StartApp();

        var rangeInputPage = new RangeInputPage(app)
            .AcceptCookies<RangeInputPage>()
            .SwitchToContentFrame<RangeInputPage>();

        rangeInputPage.SetVolume(25);

        // Act
        rangeInputPage.VolumeRangeInput.Decrement();

        // Assert
        rangeInputPage.VolumeRangeInput.Value.ShouldBe(24);
    }
}
