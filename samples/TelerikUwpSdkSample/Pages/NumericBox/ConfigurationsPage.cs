namespace TelerikUwpSdkSample.Pages.NumericBox
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Telerik;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using Shouldly;

    public class ConfigurationsPage : BasePage
    {
        public RadNumericBox NumericBox => this.WindowsApp.FindElementByAutomationId("numericBox");

        protected override By Trait => By.XPath(".//*[@Name='Configurations']");

        public ConfigurationsPage SetSpinnerNumberBoxValue(double value)
        {
            this.NumericBox.SetValue(value);
            return this;
        }

        public ConfigurationsPage IncrementSpinnerNumberBoxValue()
        {
            this.NumericBox.Increment();
            return this;
        }

        public ConfigurationsPage DecrementSpinnerNumberBoxValue()
        {
            this.NumericBox.Decrement();
            return this;
        }

        public void VerifySpinnerNumberBoxValue(double expectedValue)
        {
            this.NumericBox.Value.ShouldBe(expectedValue);
        }
    }
}
