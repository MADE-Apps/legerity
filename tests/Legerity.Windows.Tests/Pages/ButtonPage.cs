using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class ButtonPage : BaseNavigationPage
{
    public ButtonPage(WebDriver app) : base(app)
    {
    }

    public Button StandardXamlButton => this.FindElement(WindowsByExtras.AutomationId("Button1"));

    public ButtonPage ClickStandardXamlButton()
    {
        this.StandardXamlButton.Click();
        return this;
    }
}