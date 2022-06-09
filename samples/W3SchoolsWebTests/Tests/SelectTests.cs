namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Legerity;
    using Legerity.Web;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class SelectTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select";

        public SelectTests(AppManagerOptions options)
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
        public void ShouldGetItems()
        {
            Select carsSelect = this.App.FindElementById("cars") as RemoteWebElement;
            carsSelect.Options.Count().ShouldBe(4);

            var itemValues = carsSelect.Options.Select(e => e.Value).ToList();
            itemValues.ShouldContain("volvo");
            itemValues.ShouldContain("saab");
            itemValues.ShouldContain("opel");
            itemValues.ShouldContain("audi");
        }

        [Test]
        public void ShouldGetIsMultiple()
        {
            Select carsSelect = this.App.FindElementById("cars") as RemoteWebElement;
            carsSelect.IsMultiple.ShouldBe(false);
        }

        [TestCase("volvo")]
        [TestCase("saab")]
        [TestCase("opel")]
        [TestCase("audi")]
        public void ShouldSelectOptionByValue(string value)
        {
            Select carsSelect = this.App.FindElementById("cars") as RemoteWebElement;
            carsSelect.SelectOptionByValue(value);

            Option selectedOption = carsSelect.SelectedOption;
            selectedOption.Value.ShouldBe(value);
        }

        [TestCase("Volvo")]
        [TestCase("Saab")]
        [TestCase("Opel")]
        [TestCase("Audi")]
        public void ShouldSelectOptionByDisplayValue(string value)
        {
            Select carsSelect = this.App.FindElementById("cars") as RemoteWebElement;
            carsSelect.SelectOptionByDisplayValue(value);

            Option selectedOption = carsSelect.SelectedOption;
            selectedOption.DisplayValue.ShouldBe(value);
        }
    }
}