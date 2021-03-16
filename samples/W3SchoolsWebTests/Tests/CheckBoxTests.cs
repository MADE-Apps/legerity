namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class CheckBoxTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_checkbox";

        [TestCase("vehicle1")]
        [TestCase("vehicle2")]
        [TestCase("vehicle3")]
        public void ShouldCheckOn(string checkboxId)
        {
            CheckBox checkbox = AppManager.WebApp.FindElementById(checkboxId) as RemoteWebElement;
            checkbox.CheckOn();
            checkbox.IsChecked.ShouldBeTrue();
        }

        [TestCase("vehicle1")]
        [TestCase("vehicle2")]
        [TestCase("vehicle3")]
        public void ShouldCheckOff(string checkboxId)
        {
            CheckBox checkbox = AppManager.WebApp.FindElementById(checkboxId) as RemoteWebElement;
            checkbox.CheckOff();
            checkbox.IsChecked.ShouldBeFalse();
        }
    }
}