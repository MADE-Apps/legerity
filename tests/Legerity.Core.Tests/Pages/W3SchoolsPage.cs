using Legerity.Core.Tests.Tests;
using Legerity.Extensions;
using Legerity.Pages;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Core.Tests.Pages;


internal class W3SchoolsPage : BasePage
{
    private readonly By _contentFrameLocator = By.Id("iframeResult");
    private readonly By _acceptCookiesButtonLocator = By.Id("accept-choices");

    public W3SchoolsPage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => _contentFrameLocator;

    public Button AcceptCookiesButton => FindElement(_acceptCookiesButtonLocator);

    public WebElement ContentFrame => FindElement(_contentFrameLocator);

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
