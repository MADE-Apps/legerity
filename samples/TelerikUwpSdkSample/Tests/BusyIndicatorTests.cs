namespace TelerikUwpSdkSample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.BusyIndicator;

    [TestClass]
    public class BusyIndicatorTests : BaseTestClass
    {
        private static ConfigurationsPage ConfigurationsPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ConfigurationsPage = new ControlsPage().GoToBusyIndicator().GoToConfigurations();
        }

        [TestMethod]
        public void ToggleOn()
        {
            ConfigurationsPage.ToggleIndicatorOn().VerifyIndicatorState(true);
        }

        [TestMethod]
        public void ToggleOff()
        {
            ConfigurationsPage.ToggleIndicatorOff().VerifyIndicatorState(false);
        }
    }
}