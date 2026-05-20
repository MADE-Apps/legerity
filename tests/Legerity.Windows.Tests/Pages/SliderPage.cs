
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class SliderPage : BaseNavigationPage
{
    public SliderPage(WebDriver app) : base(app)
    {
    }

    public Slider SimpleSlider => this.FindElement(By.Name("simple slider"));

    public Slider RangeStepSlider => this.FindElement(WindowsByExtras.AutomationId("Slider2"));

    public SliderPage SetSimpleSliderValue(double value)
    {
        this.SimpleSlider.SetValue(value);
        return this;
    }
}