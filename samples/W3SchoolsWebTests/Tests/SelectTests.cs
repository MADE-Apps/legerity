namespace W3SchoolsWebTests.Tests
{
    using System.Linq;
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class SelectTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select";

        [Test]
        public void ShouldGetItems()
        {
            Select carsSelect = AppManager.WebApp.FindElementById("cars") as RemoteWebElement;
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
            Select carsSelect = AppManager.WebApp.FindElementById("cars") as RemoteWebElement;
            carsSelect.IsMultiple.ShouldBe(false);
        }

        [TestCase("volvo")]
        [TestCase("saab")]
        [TestCase("opel")]
        [TestCase("audi")]
        public void ShouldSelectOptionByValue(string value)
        {
            Select carsSelect = AppManager.WebApp.FindElementById("cars") as RemoteWebElement;
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
            Select carsSelect = AppManager.WebApp.FindElementById("cars") as RemoteWebElement;
            carsSelect.SelectOptionByDisplayValue(value);

            Option selectedOption = carsSelect.SelectedOption;
            selectedOption.DisplayValue.ShouldBe(value);
        }
    }
}