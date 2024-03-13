namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;

internal class HyperlinkButtonPage : BaseNavigationPage
{
    public HyperlinkButtonPage(WebDriver app) : base(app)
    {
    }

    public HyperlinkButton HyperlinkButton => FindElement(WindowsByExtras.AutomationId("Control1"));

    public HyperlinkButtonPage ClickHyperlinkButton()
    {
        HyperlinkButton.Click();
        return this;
    }
}
