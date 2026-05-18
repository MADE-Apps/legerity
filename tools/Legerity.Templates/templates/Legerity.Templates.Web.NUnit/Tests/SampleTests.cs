using Legerity.Templates.Web.NUnit.Pages;
using OpenQA.Selenium.Remote;

namespace Legerity.Templates.Web.NUnit.Tests;

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