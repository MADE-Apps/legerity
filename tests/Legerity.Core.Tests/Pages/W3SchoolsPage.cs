namespace Legerity.Core.Tests.Pages;

using Legerity.Extensions;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Tests;

internal class W3SchoolsPage : BasePage
{
    private readonly By contentFrameLocator = By.Id("iframeResult");
    private readonly By acceptCookiesButtonLocator = By.Id("accept-choices");

    public W3SchoolsPage(RemoteWebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => this.contentFrameLocator;

    public Button AcceptCookiesButton => this.FindElement(this.acceptCookiesButtonLocator);

    public RemoteWebElement ContentFrame => this.FindElement(this.contentFrameLocator);

    public T AcceptCookies<T>() where T : W3SchoolsPage
    {
        this.WaitUntil(page => page.AcceptCookiesButton.IsVisible, this.WaitTimeout);
        this.AcceptCookiesButton.Click();
        return (T)this;
    }

    public T SwitchToContentFrame<T>() where T : W3SchoolsPage
    {
        this.WaitUntil(page => page.ContentFrame.Displayed, this.WaitTimeout);
        this.App.SwitchTo().Frame(this.ContentFrame);
        return (T)this;
    }
}