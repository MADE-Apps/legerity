namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using Legerity;
    using Legerity.Web;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;
    using List = Legerity.Web.Elements.Core.List;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class OrderedListTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_lists";

        public OrderedListTests(AppManagerOptions options)
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
        public void ShouldContainItems()
        {
            ReadOnlyCollection<IWebElement> lists = this.App.FindElementsByTagName("ol");

            List list = lists.FirstOrDefault() as RemoteWebElement;
            list.Items.Count.ShouldBe(3);

            IEnumerable<string> itemsText = list.Items.Select(i => i.Text);
            itemsText.ShouldContain("Coffee");
            itemsText.ShouldContain("Tea");
            itemsText.ShouldContain("Milk");
        }
    }
}