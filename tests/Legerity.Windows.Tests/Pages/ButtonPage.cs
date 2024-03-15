namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

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
