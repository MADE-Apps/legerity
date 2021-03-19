namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class TextAreaTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_textarea";

        [Test]
        public void ShouldSetText()
        {
            TextArea review = AppManager.WebApp.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.Text.ShouldBe("James");
        }

        [Test]
        public void ShouldAppendText()
        {
            TextArea review = AppManager.WebApp.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.AppendText(" Croft");
            review.Text.ShouldBe("James Croft");
        }

        [Test]
        public void ShouldClearText()
        {
            TextArea review = AppManager.WebApp.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.ClearText();
            review.Text.ShouldBe(string.Empty);
        }

        [Test]
        public void ShouldGetRows()
        {
            TextArea review = AppManager.WebApp.FindElementById("w3review") as RemoteWebElement;
            review.Rows.ShouldBe(4);
        }

        [Test]
        public void ShouldGetCols()
        {
            TextArea review = AppManager.WebApp.FindElementById("w3review") as RemoteWebElement;
            review.Cols.ShouldBe(50);
        }
    }
}