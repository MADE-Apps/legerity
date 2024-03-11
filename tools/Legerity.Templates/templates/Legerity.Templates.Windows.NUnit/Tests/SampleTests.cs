namespace Legerity.Templates.Windows.NUnit.Tests;

using Legerity.Templates.Windows.NUnit.Pages;
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