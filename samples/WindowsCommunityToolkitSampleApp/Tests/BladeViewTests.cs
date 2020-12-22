namespace WindowsCommunityToolkitSampleApp.Tests
{
    using WindowsCommunityToolkitSampleApp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class BladeViewTests : BaseTestClass
    {
        private static BladeViewPage BladeViewPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            BladeViewPage = new AppPage().SelectSample<BladeViewPage>("BladeView");
        }

        [TestMethod]
        public void CloseBlade()
        {
            // Arrange
            string closeBlade = "Default Blade";

            // Act
            BladeViewPage.OpenBlades();

            // Assert
            BladeViewPage.CloseBlade(closeBlade);
        }

        [TestMethod]
        public void ToggleBladeSize()
        {
            // Arrange
            string toggleBlade = "Default Blade";

            // Act
            BladeViewPage.OpenBlades();

            // Assert
            BladeViewPage.ToggleBladeSize(toggleBlade);
        }
    }
}