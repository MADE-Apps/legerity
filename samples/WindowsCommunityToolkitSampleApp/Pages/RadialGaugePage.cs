namespace WindowsCommunityToolkitSampleApp.Pages
{
    using Legerity.Windows;
    using Legerity.Windows.Elements.WCT;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the RadialGauge page of the Windows Community Toolkit sample application.
    /// </summary>
    public class RadialGaugePage : AppPage
    {
        private readonly By radialGauge;

        public RadialGaugePage()
        {
            this.radialGauge = WindowsByExtras.AutomationId("RadialGauge");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='RadialGauge']");

        public RadialGaugePage SetRadialGaugeValue(double value)
        {
            RadialGauge gauge = this.WindowsApp.FindElement(this.radialGauge);
            gauge.SetValue(value);
            return this;
        }

        public void VerifyRadialGaugeValue(double value)
        {
            RadialGauge gauge = this.WindowsApp.FindElement(this.radialGauge);
            Assert.AreEqual(value, gauge.Value);
        }
    }
}
