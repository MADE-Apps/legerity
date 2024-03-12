namespace Legerity.Core.Tests.Pages;

using Extensions;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Tests;

internal class W3SchoolsPage : BasePage
{
    private readonly By contentFrameLocator = By.Id("iframeResult");
    private readonly By acceptCookiesButtonLocator = By.Id("accept-choices");

    public W3SchoolsPage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => contentFrameLocator;

    public Button AcceptCookiesButton => FindElement(acceptCookiesButtonLocator);

    public WebElement ContentFrame => FindElement(contentFrameLocator);

    public T AcceptCookies<T>() where T : W3SchoolsPage
    {
        this.WaitUntil(page => page.AcceptCookiesButton.IsVisible, WaitTimeout);
        AcceptCookiesButton.Click();
        return (T)this;
    }

    public T SwitchToContentFrame<T>() where T : W3SchoolsPage
    {
        this.WaitUntil(page => page.ContentFrame.Displayed, WaitTimeout);
        App.SwitchTo().Frame(ContentFrame);
        return (T)this;
    }
}
