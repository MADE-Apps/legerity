namespace Legerity.Templates.CrossPlatform.NUnit.Pages;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

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
    protected override By Trait => this.DetermineTrait();

    internal SamplePage VerifyPageLoaded()
    {
        this.VerifyElementShown(this.Trait);
        return this;
    }

    private By DetermineTrait()
    {
        return this.App switch
        {
            WindowsDriver => WindowsByExtras.AutomationId("sampleButton"),
            AndroidDriver => By.Id("sampleButton"),
            IOSDriver => By.Name("sampleButton"),
            _ => By.TagName("button")
        };
    }
}