namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;

    [TestClass]
    public class ToggleSwitchTests : BaseTestClass
    {
        private static ToggleSwitchPage ToggleSwitchPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ToggleSwitchPage = new NavigationMenu().GoToToggleSwitch();
        }

        [TestMethod]
        public void SetSimpleToggleOn()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            ToggleSwitchPage.ToggleSimpleSwitch(expectedState);

            // Assert
            ToggleSwitchPage.VerifySimpleToggleSwitch(expectedState);
        }

        [TestMethod]
        public void SetSimpleToggleOff()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            ToggleSwitchPage.ToggleSimpleSwitch(expectedState);

            // Assert
            ToggleSwitchPage.VerifySimpleToggleSwitch(expectedState);
        }
    }
}