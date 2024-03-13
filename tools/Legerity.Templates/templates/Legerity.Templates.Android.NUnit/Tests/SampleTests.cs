namespace Legerity.Templates.Android.NUnit.Tests;

using Pages;

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
        var app = this.StartApp();
        new SamplePage(app).VerifyPageLoaded();
    }
}
