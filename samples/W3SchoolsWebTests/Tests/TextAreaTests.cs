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
    public class TextAreaTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_textarea";

        public TextAreaTests(AppManagerOptions options)
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
        public void ShouldSetText()
        {
            TextArea review = this.App.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.Text.ShouldBe("James");
        }

        [Test]
        public void ShouldAppendText()
        {
            TextArea review = this.App.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.AppendText(" Croft");
            review.Text.ShouldBe("James Croft");
        }

        [Test]
        public void ShouldClearText()
        {
            TextArea review = this.App.FindElementById("w3review") as RemoteWebElement;
            review.SetText("James");
            review.ClearText();
            review.Text.ShouldBe(string.Empty);
        }

        [Test]
        public void ShouldGetRows()
        {
            TextArea review = this.App.FindElementById("w3review") as RemoteWebElement;
            review.Rows.ShouldBe(4);
        }

        [Test]
        public void ShouldGetCols()
        {
            TextArea review = this.App.FindElementById("w3review") as RemoteWebElement;
            review.Cols.ShouldBe(50);
        }
    }
}