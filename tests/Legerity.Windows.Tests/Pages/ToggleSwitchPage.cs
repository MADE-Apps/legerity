namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ToggleSwitchPage : BaseNavigationPage
{
    public ToggleSwitchPage(WebDriver app) : base(app)
    {
    }

    public ToggleSwitch SimpleToggleSwitch => FindElement(By.Name("simple ToggleSwitch"));

    public ToggleSwitchPage ToggleSwitchOn()
    {
        SimpleToggleSwitch.ToggleOn();
        return this;
    }

    public ToggleSwitchPage ToggleSwitchOff()
    {
        SimpleToggleSwitch.ToggleOff();
        return this;
    }
}
