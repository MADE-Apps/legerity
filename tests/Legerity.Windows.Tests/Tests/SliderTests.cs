namespace Legerity.Windows.Tests.Tests;

using System;
using Pages;
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
        var sliderPage = StartAndNavigateToPage();

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
        var sliderPage = StartAndNavigateToPage();

        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => sliderPage.SetSimpleSliderValue(value));
    }

    [Test]
    public void ShouldGetIsReadonly()
    {
        // Arrange
        var sliderPage = StartAndNavigateToPage();

        // Act & Assert
        sliderPage.SimpleSlider.IsReadonly.ShouldBeFalse();
    }

    [Test]
    public void ShouldGetValueRange()
    {
        // Arrange
        var sliderPage = StartAndNavigateToPage();

        // Act & Assert
        sliderPage.RangeStepSlider.Minimum.ShouldBe(500);
        sliderPage.RangeStepSlider.Maximum.ShouldBe(1000);
    }

    [Test]
    public void ShouldGetSmallChangeValue()
    {
        // Arrange
        var sliderPage = StartAndNavigateToPage();

        // Act & Assert
        sliderPage.RangeStepSlider.SmallChange.ShouldBe(10);
    }

    private SliderPage StartAndNavigateToPage()
    {
        var app = StartApp();
        return new HomePage(app).NavigateTo<SliderPage>("Slider");
    }
}
