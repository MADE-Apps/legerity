namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class ImageTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_image_test";

        [Test]
        public void ShouldGetImageSource()
        {
            Image image = AppManager.WebApp.FindElementByTagName("img") as RemoteWebElement;
            image.Source.ShouldContain("img_girl.jpg");
        }

        [Test]
        public void ShouldGetAltText()
        {
            Image image = AppManager.WebApp.FindElementByTagName("img") as RemoteWebElement;
            image.AltText.ShouldBe("Girl in a jacket");
        }

        [Test]
        public void ShouldGetSize()
        {
            Image image = AppManager.WebApp.FindElementByTagName("img") as RemoteWebElement;
            image.Width.ShouldBe(500);
            image.Height.ShouldBe(600);
        }
    }
}