using Legerity.Templates.Android.NUnit.Pages;
using OpenQA.Selenium;

namespace Legerity.Templates.Android.NUnit.Tests;

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