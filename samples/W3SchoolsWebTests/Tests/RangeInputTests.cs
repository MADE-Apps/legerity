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
    public class RangeInputTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_range";

        public RangeInputTests(AppManagerOptions options) : base(options)
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
            RangeInput volume = AppManager.WebApp.FindElementById("vol") as RemoteWebElement;
            volume.Minimum.ShouldBe(0);
            volume.Maximum.ShouldBe(50);
        }

        [Test]
        public void ShouldSetValue()
        {
            RangeInput volume = AppManager.WebApp.FindElementById("vol") as RemoteWebElement;
            volume.SetValue(20);
            volume.Value.ShouldBe(20);
        }

        [Test]
        public void ShouldIncrement()
        {
            RangeInput volume = AppManager.WebApp.FindElementById("vol") as RemoteWebElement;
            volume.SetValue(30);
            volume.Increment();
            volume.Value.ShouldBe(31);
        }

        [Test]
        public void ShouldDecrement()
        {
            RangeInput volume = AppManager.WebApp.FindElementById("vol") as RemoteWebElement;
            volume.SetValue(20);
            volume.Decrement();
            volume.Value.ShouldBe(19);
        }
    }
}