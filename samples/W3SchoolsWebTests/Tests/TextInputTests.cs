namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class TextInputTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_text";

        [Test]
        public void ShouldSetText()
        {
            TextInput firstName = AppManager.WebApp.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.Text.ShouldBe("James");
        }

        [Test]
        public void ShouldAppendText()
        {
            TextInput firstName = AppManager.WebApp.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.AppendText(" Croft");
            firstName.Text.ShouldBe("James Croft");
        }

        [Test]
        public void ShouldClearText()
        {
            TextInput firstName = AppManager.WebApp.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.ClearText();
            firstName.Text.ShouldBe(string.Empty);
        }
    }
}