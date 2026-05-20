using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Windows.Tests.Pages;

internal class HyperlinkButtonPage : BaseNavigationPage
{
    public HyperlinkButtonPage(WebDriver app) : base(app)
    {
    }

    public HyperlinkButton HyperlinkButton => this.FindElement(WindowsByExtras.AutomationId("Control1"));

    public HyperlinkButtonPage ClickHyperlinkButton()
    {
        this.HyperlinkButton.Click();
        return this;
    }
}