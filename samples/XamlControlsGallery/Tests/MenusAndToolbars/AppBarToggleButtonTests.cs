namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.MenusAndToolbars;

    [TestClass]
    public class AppBarToggleButtonTests : BaseTestClass
    {
        private static AppBarToggleButtonPage AppBarToggleButtonPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            AppBarToggleButtonPage = new NavigationMenu().GoToAppBarToggleButton();
        }

        [TestMethod]
        public void SetToggleSymbolIconButtonOn()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            AppBarToggleButtonPage.ToggleSymbolIconButton(expectedState);

            // Assert
            AppBarToggleButtonPage.VerifySymbolIconButton(expectedState);
        }

        [TestMethod]
        public void SetToggleSymbolIconButtonOff()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            AppBarToggleButtonPage.ToggleSymbolIconButton(expectedState);

            // Assert
            AppBarToggleButtonPage.VerifySymbolIconButton(expectedState);
        }
    }
}