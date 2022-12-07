namespace Legerity.Templates.IOS.NUnit.Pages;

using Legerity;
using Legerity.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class SamplePage : BasePage
{
    public SamplePage()
        : base(AppManager.App, BaseTestClass.ImplicitWait)
    {
    }

    public SamplePage(RemoteWebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    /// <summary>
    /// Gets a given trait of the page to verify that the page is in view.
    /// </summary>
    protected override By Trait => By.Name("sampleButton");

    internal SamplePage VerifyPageLoaded()
    {
        this.VerifyElementShown(this.Trait);
        return this;
    }
}