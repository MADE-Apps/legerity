namespace Legerity.Templates.Web.NUnit.Tests;

using Pages;
using OpenQA.Selenium.Remote;

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
        var app = this.StartApp();
        new SamplePage(app).VerifyPageLoaded();
    }
}
