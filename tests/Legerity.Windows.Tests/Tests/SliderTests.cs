namespace Legerity.Windows.Tests.Tests;

using System;
using Legerity.Windows.Tests.Pages;
using OpenQA.Selenium.Remote;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class SliderTests : BaseTestClass
{
    public SliderTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldSetValue()
    {
        // Arrange
        SliderPage sliderPage = this.StartAndNavigateToPage();

        // Act
        sliderPage.SetSimpleSliderValue(10);

        // Assert
        sliderPage.SimpleSlider.Value.ShouldBe(10);
    }

    [TestCase(-1)]
    [TestCase(101)]
    public void ShouldThrowArgumentOutOfRangeExceptionWhenSettingValueOutOfRange(int value)
    {
        // Arrange
        SliderPage sliderPage = this.StartAndNavigateToPage();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => sliderPage.SetSimpleSliderValue(value));
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        SliderPage sliderPage = this.StartAndNavigateToPage();

        // Act & Assert
        sliderPage.SimpleSlider.IsReadonly.ShouldBeFalse();
    }

    [Test]
    public void ShouldGetValueRange()
    {
        // Arrange
        SliderPage sliderPage = this.StartAndNavigateToPage();

        // Act & Assert
        sliderPage.RangeStepSlider.Minimum.ShouldBe(500);
        sliderPage.RangeStepSlider.Maximum.ShouldBe(1000);
    }

    [Test]
    public void ShouldGetSmallChangeValue()
    {
        // Arrange
        SliderPage sliderPage = this.StartAndNavigateToPage();

        // Act & Assert
        sliderPage.RangeStepSlider.SmallChange.ShouldBe(10);
    }

    private SliderPage StartAndNavigateToPage()
    {
        WebDriver app = this.StartApp();
        return new HomePage(app).NavigateTo<SliderPage>("Slider");
    }
}