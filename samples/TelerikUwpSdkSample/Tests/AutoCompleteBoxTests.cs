namespace TelerikUwpSdkSample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.AutoCompleteBox;

    [TestClass]
    public class AutoCompleteBoxTests : BaseTestClass
    {
        private static FilterSettingsPage FilterSettingsPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            FilterSettingsPage = new ControlsPage().GoToAutoCompleteBox().GoToFilterSettings();
        }

        [TestMethod]
        public void SetAutoCompleteBoxText()
        {
            // Arrange
            const string expectedItem = "Green";

            // Act
            FilterSettingsPage.SetText(expectedItem);

            // Assert
            FilterSettingsPage.VerifyValue(expectedItem);
        }

        [TestMethod]
        public void SelectAutoComplexBoxSuggestion()
        {
            // Arrange
            const string value = "a";
            const string expectedItem = "Alon";

            // Act
            FilterSettingsPage.SelectSuggestion(value, expectedItem);

            // Assert
            FilterSettingsPage.VerifyValue(expectedItem);
        }
    }
}