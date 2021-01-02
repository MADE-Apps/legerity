namespace TelerikUwpSdkSample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.NumericBox;
    using TelerikUwpSdkSample;

    [TestClass]
    public class NumericBoxTests : BaseTestClass
    {
        private static ConfigurationsPage ConfigurationsPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ConfigurationsPage = new ControlsPage().GoToNumericBox().GoToConfigurations();
        }

        [TestMethod]
        public void SetNumericBoxValue()
        {
            // Arrange
            const double expected = 50;

            // Act
            ConfigurationsPage.SetSpinnerNumberBoxValue(expected);

            // Assert
            ConfigurationsPage.VerifySpinnerNumberBoxValue(expected);
        }

        [TestMethod]
        public void IncrementNumericBox()
        {
            // Arrange
            const double initial = 0;
            double increment = ConfigurationsPage.NumericBox.SmallChange;
            double expected = initial + increment;

            ConfigurationsPage.SetSpinnerNumberBoxValue(initial);

            // Act
            ConfigurationsPage.IncrementSpinnerNumberBoxValue();

            // Assert
            ConfigurationsPage.VerifySpinnerNumberBoxValue(expected);
        }

        [TestMethod]
        public void DecrementNumericBox()
        {
            // Arrange
            const double initial = 0;
            double increment = ConfigurationsPage.NumericBox.SmallChange;
            double expected = initial - increment;

            ConfigurationsPage.SetSpinnerNumberBoxValue(initial);

            // Act
            ConfigurationsPage.DecrementSpinnerNumberBoxValue();

            // Assert
            ConfigurationsPage.VerifySpinnerNumberBoxValue(expected);
        }
    }
}