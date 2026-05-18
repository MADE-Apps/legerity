using Legerity.Templates.IOS.NUnit.Pages;
using OpenQA.Selenium.Remote;

namespace Legerity.Templates.IOS.NUnit.Tests;

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