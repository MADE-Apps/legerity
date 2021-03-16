namespace W3SchoolsWebTests.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;
    using List = Legerity.Web.Elements.Core.List;

    [TestFixture]
    public class OrderedListTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_lists";

        [Test]
        public void ShouldContainItems()
        {
            ReadOnlyCollection<IWebElement> lists = AppManager.WebApp.FindElementsByTagName("ol");

            List list = lists.FirstOrDefault() as RemoteWebElement;
            list.Items.Count.ShouldBe(3);

            IEnumerable<string> itemsText = list.Items.Select(i => i.Text);
            itemsText.ShouldContain("Coffee");
            itemsText.ShouldContain("Tea");
            itemsText.ShouldContain("Milk");
        }
    }
}