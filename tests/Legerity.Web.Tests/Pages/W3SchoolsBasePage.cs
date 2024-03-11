namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using Legerity.Extensions;
using Legerity.Web.Tests.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal abstract class W3SchoolsBasePage : BasePage
{
    private readonly By contentFrameLocator = By.Id("iframeResult");
    private readonly By acceptCookiesButtonLocator = By.Id("accept-choices");

    protected W3SchoolsBasePage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => this.contentFrameLocator;

    public Button AcceptCookiesButton => this.FindElement(this.acceptCookiesButtonLocator);

    public WebElement ContentFrame => this.FindElement(this.contentFrameLocator);

    public T AcceptCookies<T>() where T : W3SchoolsBasePage
    {
        this.WaitUntil(page => page.AcceptCookiesButton.IsVisible, this.WaitTimeout);
        this.AcceptCookiesButton.Click();
        return (T)this;
    }

    public T SwitchToContentFrame<T>() where T : W3SchoolsBasePage
    {
        this.WaitUntil(page => page.ContentFrame.Displayed, this.WaitTimeout);
        this.App.SwitchTo().Frame(this.ContentFrame);
        return (T)this;
    }
}