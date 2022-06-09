namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class ImageTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_image_test";

        public ImageTests(AppManagerOptions options)
            : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WebAppManagerOptions(
                WebAppDriverType.Chrome,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            }
        };

        [Test]
        public void ShouldGetImageSource()
        {
            Image image = this.App.FindElementByTagName("img") as RemoteWebElement;
            image.Source.ShouldContain("img_girl.jpg");
        }

        [Test]
        public void ShouldGetAltText()
        {
            Image image = this.App.FindElementByTagName("img") as RemoteWebElement;
            image.AltText.ShouldBe("Girl in a jacket");
        }

        [Test]
        public void ShouldGetSize()
        {
            Image image = this.App.FindElementByTagName("img") as RemoteWebElement;
            image.Width.ShouldBe(500);
            image.Height.ShouldBe(600);
        }
    }
}