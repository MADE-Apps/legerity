namespace TelerikUwpSdkSample.Pages.BusyIndicator
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.Telerik;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using Shouldly;

    public class ConfigurationsPage : BasePage
    {
        public RadBusyIndicator Indicator => this.WindowsApp.FindElementByAutomationId("indicator");

        public Button SwitchButton => this.WindowsApp.FindElementByName("Switch ON/OFF");

        protected override By Trait => By.XPath(".//*[@Name='Configurations']");

        public ConfigurationsPage ToggleIndicatorOn()
        {
            if (!this.Indicator.IsOn)
            {
                this.SwitchButton.Click();
            }

            return this;
        }

        public ConfigurationsPage ToggleIndicatorOff()
        {
            if (this.Indicator.IsOn)
            {
                this.SwitchButton.Click();
            }

            return this;
        }

        public void VerifyIndicatorState(bool isOn)
        {
            this.Indicator.IsOn.ShouldBe(isOn);
        }
    }
}
