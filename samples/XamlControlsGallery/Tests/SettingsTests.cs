namespace XamlControlsGallery.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;

    [TestClass]
    public class SettingsTests : BaseTestClass
    {
        private static SettingsPage SettingsPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            SettingsPage = new NavigationMenu().GoToSettingsPage();
        }

        [TestMethod]
        public void SetSoundToggleOn()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            SettingsPage.ToggleSoundOption(expectedState);

            // Assert
            SettingsPage.VerifyToggleSoundOption(expectedState);
        }

        [TestMethod]
        public void SetSoundToggleOff()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            SettingsPage.ToggleSoundOption(expectedState);

            // Assert
            SettingsPage.VerifyToggleSoundOption(expectedState);
        }
    }
}