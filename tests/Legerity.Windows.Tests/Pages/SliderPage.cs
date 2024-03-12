namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class SliderPage : BaseNavigationPage
{
    public SliderPage(WebDriver app) : base(app)
    {
    }

    public Slider SimpleSlider => FindElement(By.Name("simple slider"));

    public Slider RangeStepSlider => FindElement(WindowsByExtras.AutomationId("Slider2"));

    public SliderPage SetSimpleSliderValue(double value)
    {
        SimpleSlider.SetValue(value);
        return this;
    }
}
