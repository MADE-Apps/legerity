namespace WebTests.Tests.Edge
{
    using Legerity;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using WebTests.Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HomePageTests : BaseTestClass
    {
        public HomePageTests(AppManagerOptions options)
            : base(options)
        {
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [Parallelizable(ParallelScope.Children)]
        public void ReadHeroPost(int idx)
        {
            RemoteWebDriver app = this.StartApp();
            new HomePage(app).NavigateToHeroPostByIndex(idx).ReadPost(0.25);
        }
    }
}