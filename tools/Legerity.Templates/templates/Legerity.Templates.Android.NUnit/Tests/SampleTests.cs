namespace Legerity.Templates.Android.NUnit.Tests;

using Legerity.Templates.Android.NUnit.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

[TestFixtureSource(nameof(PlatformOptions))]
public class SampleTests : BaseTestClass
{
    public SampleTests(AppManagerOptions options)
        : base(options)
    {
    }

    [Test]
    public void ShouldLoadPage()
    {
        WebDriver app = this.StartApp();
        new SamplePage(app).VerifyPageLoaded();
    }
}