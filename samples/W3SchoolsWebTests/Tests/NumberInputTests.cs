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
    public class NumberInputTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_number";

        public NumberInputTests(AppManagerOptions options) : base(options)
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
        public void ShouldGetValueRange()
        {
            NumberInput quantity = AppManager.WebApp.FindElementById("quantity") as RemoteWebElement;
            quantity.Minimum.ShouldBe(1);
            quantity.Maximum.ShouldBe(5);
        }

        [Test]
        public void ShouldSetValue()
        {
            NumberInput quantity = AppManager.WebApp.FindElementById("quantity") as RemoteWebElement;
            quantity.SetValue(4);
            quantity.Value.ShouldBe(4);
        }

        [Test]
        public void ShouldIncrement()
        {
            NumberInput quantity = AppManager.WebApp.FindElementById("quantity") as RemoteWebElement;
            quantity.SetValue(3);
            quantity.Increment();
            quantity.Value.ShouldBe(4);
        }

        [Test]
        public void ShouldDecrement()
        {
            NumberInput quantity = AppManager.WebApp.FindElementById("quantity") as RemoteWebElement;
            quantity.SetValue(3);
            quantity.Decrement();
            quantity.Value.ShouldBe(2);
        }
    }
}