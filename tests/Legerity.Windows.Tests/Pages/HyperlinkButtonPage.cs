namespace Legerity.Windows.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium.Remote;

internal class HyperlinkButtonPage : BaseNavigationPage
{
    public HyperlinkButtonPage(RemoteWebDriver app) : base(app)
    {
    }

    public HyperlinkButton HyperlinkButton => this.FindElement(WindowsByExtras.AutomationId("Control1"));

    public HyperlinkButtonPage ClickHyperlinkButton()
    {
        this.HyperlinkButton.Click();
        return this;
    }
}