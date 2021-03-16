namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using W3SchoolsWebTests;

    [TestFixture]
    public class ButtonTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_button_test";

        [Test]
        public void ShouldClickButton()
        {
            Button button = AppManager.WebApp.FindElementByTagName("button") as RemoteWebElement;
            button.Click();
        }
    }
}