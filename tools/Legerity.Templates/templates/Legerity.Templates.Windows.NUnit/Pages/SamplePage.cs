namespace Legerity.Templates.Windows.NUnit.Pages;

using OpenQA.Selenium;

internal class SamplePage : BasePage
{
    public SamplePage()
        : base(AppManager.App, BaseTestClass.ImplicitWait)
    {
    }

    public SamplePage(WebDriver app)
        : base(app, BaseTestClass.ImplicitWait)
    {
    }

    /// <summary>
    /// Gets a given trait of the page to verify that the page is in view.
    /// </summary>
    protected override By Trait => WindowsByExtras.AutomationId("StartButton");

    internal SamplePage VerifyPageLoaded()
    {
        this.VerifyElementShown(this.Trait);
        return this;
    }
}
