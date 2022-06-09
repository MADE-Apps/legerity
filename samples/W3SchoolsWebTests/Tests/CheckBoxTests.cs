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
    [Parallelizable(ParallelScope.Fixtures)]
    public class CheckBoxTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_checkbox";

        public CheckBoxTests(AppManagerOptions options)
            : base(options)
        {
            this.IsParallelized = true;
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

        [TestCase("vehicle1")]
        [TestCase("vehicle2")]
        [TestCase("vehicle3")]
        [Parallelizable(ParallelScope.Children)]
        public void ShouldCheckOn(string checkboxId)
        {
            RemoteWebDriver app = this.StartApp();

            CheckBox checkbox = app.FindElementById(checkboxId) as RemoteWebElement;
            checkbox.CheckOn();
            checkbox.IsChecked.ShouldBeTrue();

            this.StopApp(app);
        }

        [TestCase("vehicle1")]
        [TestCase("vehicle2")]
        [TestCase("vehicle3")]
        [Parallelizable(ParallelScope.Children)]
        public void ShouldCheckOff(string checkboxId)
        {
            RemoteWebDriver app = this.StartApp();

            CheckBox checkbox = app.FindElementById(checkboxId) as RemoteWebElement;
            checkbox.CheckOff();
            checkbox.IsChecked.ShouldBeFalse();

            this.StopApp(app);
        }
    }
}