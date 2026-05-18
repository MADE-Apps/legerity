// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Core.Tests.Tests;
using Legerity.Extensions;
using OpenQA.Selenium;

namespace Legerity.Core.Tests.Pages;

internal class W3SchoolsPage : BasePage
{
    private readonly By contentFrameLocator = By.Id("iframeResult");
    private readonly By cmpFrameLocator = By.Id("fast-cmp-iframe");
    private readonly By acceptCookiesButtonLocator = By.TagName("button").WithText("Accept");

    public W3SchoolsPage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    protected override By Trait => this.cmpFrameLocator;

    public T AcceptCookies<T>() where T : W3SchoolsPage
    {
        try
        {
            WebElement cmpFrame = this.FindElement(this.cmpFrameLocator);
            this.App.SwitchTo().Frame(cmpFrame);

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.App, this.WaitTimeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverException));
            wait.Until(_ => this.App.FindElement(this.acceptCookiesButtonLocator).Displayed);

            this.App.FindElement(this.acceptCookiesButtonLocator).Click();
        }
        catch (Exception)
        {
            // Cookie banner may not appear or driver may be unresponsive; continue.
        }

        try
        {
            this.App.SwitchTo().DefaultContent();
        }
        catch (Exception)
        {
            // Driver may already be disposed.
        }

        return (T)this;
    }

    public T SwitchToContentFrame<T>() where T : W3SchoolsPage
    {
        this.WaitUntil(
            _ => this.App.FindElement(this.contentFrameLocator).Displayed,
            this.WaitTimeout);
        this.App.SwitchTo().Frame(this.App.FindElement(this.contentFrameLocator));
        return (T)this;
    }
}