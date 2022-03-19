namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using Legerity;
    using Legerity.Web;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class RadioButtonTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio";

        public RadioButtonTests(AppManagerOptions options) : base(options)
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

        [TestCase("html")]
        [TestCase("css")]
        [TestCase("javascript")]
        [TestCase("age1")]
        [TestCase("age2")]
        [TestCase("age3")]
        public void ShouldSelect(string radioId)
        {
            RadioButton radioButton = AppManager.WebApp.FindElementById(radioId) as RemoteWebElement;
            radioButton.Click();
            radioButton.IsSelected.ShouldBeTrue();
        }

        [TestCase("fav_language", "html", "javascript")]
        [TestCase("age", "age3", "age2")]
        public void ShouldOnlySelectOneInGroup(string groupName, string initialRadioId, string expectedRadioId)
        {
            ReadOnlyCollection<IWebElement> radioButtons = AppManager.WebApp.FindElements(By.Name(groupName));
            RadioButton initialRadioButton = radioButtons.FirstOrDefault(x => x.GetAttribute("id") == initialRadioId) as RemoteWebElement;
            initialRadioButton.Click();
            initialRadioButton.IsSelected.ShouldBeTrue();

            RadioButton expectedRadioButton = radioButtons.FirstOrDefault(x => x.GetAttribute("id") == expectedRadioId) as RemoteWebElement;
            expectedRadioButton.Click();
            expectedRadioButton.IsSelected.ShouldBeTrue();
            initialRadioButton.IsSelected.ShouldBeFalse();
        }
    }
}