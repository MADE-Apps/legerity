namespace WindowsCommunityToolkitSampleApp.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class RadialGaugeTests : BaseTestClass
    {
        private static RadialGaugePage RadialGaugePage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            RadialGaugePage = new AppPage().SelectSample<RadialGaugePage>("RadialGauge");
        }

        [TestMethod]
        public void SetRadialGaugeValue()
        {
            // Arrange
            const int expectedValue = 180;

            // Act
            RadialGaugePage.SetRadialGaugeValue(expectedValue);

            // Assert
            RadialGaugePage.VerifyRadialGaugeValue(expectedValue);
        }
    }
}
