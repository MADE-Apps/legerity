namespace W3SchoolsWebTests.Tests
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class RadioButtonTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio";

        [TestCase("male")]
        [TestCase("female")]
        [TestCase("other")]
        [TestCase("age1")]
        [TestCase("age2")]
        [TestCase("age3")]
        public void ShouldSelect(string radioId)
        {
            RadioButton radioButton = AppManager.WebApp.FindElementById(radioId) as RemoteWebElement;
            radioButton.Click();
            radioButton.IsSelected.ShouldBeTrue();
        }

        [TestCase("gender", "male", "female")]
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