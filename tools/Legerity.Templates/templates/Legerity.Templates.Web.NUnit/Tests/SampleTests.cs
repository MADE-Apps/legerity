namespace Legerity.Templates.Web.NUnit.Tests;

using Legerity;
using OpenQA.Selenium.Remote;
using Pages;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.Fixtures)]
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