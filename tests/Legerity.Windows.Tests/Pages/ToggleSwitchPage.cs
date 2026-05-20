
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ToggleSwitchPage : BaseNavigationPage
{
    public ToggleSwitchPage(WebDriver app) : base(app)
    {
    }

    public ToggleSwitch SimpleToggleSwitch => this.FindElement(By.Name("simple ToggleSwitch"));

    public ToggleSwitchPage ToggleSwitchOn()
    {
        this.SimpleToggleSwitch.ToggleOn();
        return this;
    }

    public ToggleSwitchPage ToggleSwitchOff()
    {
        this.SimpleToggleSwitch.ToggleOff();
        return this;
    }
}