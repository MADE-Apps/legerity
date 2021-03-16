namespace W3SchoolsWebTests.Tests
{
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class RangeInputTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_range";

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