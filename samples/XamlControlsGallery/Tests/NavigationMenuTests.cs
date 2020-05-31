namespace XamlControlsGallery.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;

    [TestClass]
    public class NavigationMenuTests : BaseTestClass
    {
        private static NavigationMenu NavigationMenu { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            NavigationMenu = new NavigationMenu();
        }

        [TestMethod]
        public void SetPaneOpen()
        {
            // Arrange
            const bool expectedState = true;

            // Act
            NavigationMenu.ToggleNavigationPane(expectedState);

            // Assert
            NavigationMenu.VerifyToggleNavigationPane(expectedState);
        }

        [TestMethod]
        public void SetPaneClosed()
        {
            // Arrange
            const bool expectedState = false;

            // Act
            NavigationMenu.ToggleNavigationPane(expectedState);

            // Assert
            NavigationMenu.VerifyToggleNavigationPane(expectedState);
        }

        [TestMethod]
        public void ClickComboBoxMenuOption()
        {
            // Arrange
            const string expectedGroupOption = "Basic Input";
            const string expectedOption = "ComboBox";

            // Act
            NavigationMenu.SelectControlOption(expectedGroupOption, expectedOption);

            // Assert
            var comboBoxPage = new ComboBoxPage();
        }
    }
}