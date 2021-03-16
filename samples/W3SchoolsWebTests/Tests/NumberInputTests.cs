namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class NumberInputTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_input_number";

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