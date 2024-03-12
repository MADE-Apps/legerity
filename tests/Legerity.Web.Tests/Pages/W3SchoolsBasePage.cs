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

    protected override By Trait => contentFrameLocator;

    public Button AcceptCookiesButton => FindElement(acceptCookiesButtonLocator);

    public WebElement ContentFrame => FindElement(contentFrameLocator);

    public T AcceptCookies<T>() where T : W3SchoolsBasePage
    {
        this.WaitUntil(page => page.AcceptCookiesButton.IsVisible, WaitTimeout);
        AcceptCookiesButton.Click();
        return (T)this;
    }

    public T SwitchToContentFrame<T>() where T : W3SchoolsBasePage
    {
        this.WaitUntil(page => page.ContentFrame.Displayed, WaitTimeout);
        App.SwitchTo().Frame(ContentFrame);
        return (T)this;
    }
}