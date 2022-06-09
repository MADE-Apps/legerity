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
    public class TextInputTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_text";

        public TextInputTests(AppManagerOptions options)
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
            TextInput firstName = this.App.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.Text.ShouldBe("James");
        }

        [Test]
        public void ShouldAppendText()
        {
            TextInput firstName = this.App.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.AppendText(" Croft");
            firstName.Text.ShouldBe("James Croft");
        }

        [Test]
        public void ShouldClearText()
        {
            TextInput firstName = this.App.FindElementById("fname") as RemoteWebElement;
            firstName.SetText("James");
            firstName.ClearText();
            firstName.Text.ShouldBe(string.Empty);
        }
    }
}