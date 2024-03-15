using Legerity.Extensions;
using Legerity.Pages;
using Legerity.Web.Elements.Core;
using Legerity.Web.Tests.Tests;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal abstract class W3SchoolsBasePage : BasePage
{
    private readonly By _contentFrameLocator = By.Id("iframeResult");
    private readonly By _acceptCookiesButtonLocator = By.Id("accept-choices");

    protected W3SchoolsBasePage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => _contentFrameLocator;

    public Button AcceptCookiesButton => FindElement(_acceptCookiesButtonLocator);

    public WebElement ContentFrame => FindElement(_contentFrameLocator);

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
