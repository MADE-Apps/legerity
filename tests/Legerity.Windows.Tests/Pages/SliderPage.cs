namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class SliderPage : BaseNavigationPage
{
    public SliderPage(RemoteWebDriver app) : base(app)
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