namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ButtonPage : BaseNavigationPage
{
    public ButtonPage(RemoteWebDriver app) : base(app)
    {
    }

    public Button StandardXamlButton => this.FindElement(WindowsByExtras.AutomationId("Button1"));

    public ButtonPage ClickStandardXamlButton()
    {
        this.StandardXamlButton.Click();
        return this;
    }
}