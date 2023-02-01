namespace Legerity.Windows.Tests.Pages;

using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ToggleSwitchPage : BaseNavigationPage
{
    public ToggleSwitchPage(RemoteWebDriver app) : base(app)
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