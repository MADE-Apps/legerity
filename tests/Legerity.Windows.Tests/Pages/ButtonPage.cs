namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class ButtonPage : BaseNavigationPage
{
    public ButtonPage(WebDriver app) : base(app)
    {
    }

    public Button StandardXamlButton => FindElement(WindowsByExtras.AutomationId("Button1"));

    public ButtonPage ClickStandardXamlButton()
    {
        StandardXamlButton.Click();
        return this;
    }
}