namespace Legerity.Templates.Android.NUnit.Tests;

using Legerity.Templates.Android.NUnit.Pages;
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
        RemoteWebDriver app = this.StartApp();
        new SamplePage(app).VerifyPageLoaded();
    }
}