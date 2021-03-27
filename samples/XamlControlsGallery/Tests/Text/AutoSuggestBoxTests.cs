namespace XamlControlsGallery.Tests.Text
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.Text;

    [TestClass]
    public class AutoSuggestBoxTests : BaseTestClass
    {
        private static AutoSuggestBoxPage AutoSuggestBoxPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            AutoSuggestBoxPage = new NavigationMenu().GoToAutoSuggestBox();
        }

        [TestMethod]
        public void SetBasicAutoSuggestBoxText()
        {
            // Arrange
            string expectedItem = "Burmese";

            // Act
            AutoSuggestBoxPage.SetBasicAutoSuggestBoxText(expectedItem);

            // Assert
            AutoSuggestBoxPage.VerifyBasicAutoSuggestBoxValue(expectedItem);
        }

        [TestMethod]
        public void SetBasicAutoSuggestBoxSuggestion()
        {
            // Arrange
            string value = "Amer";
            string expectedItem = "American Bobtail";

            // Act
            AutoSuggestBoxPage.SelectBasicAutoSuggestBoxSuggestion(value, expectedItem);

            // Assert
            AutoSuggestBoxPage.VerifyBasicAutoSuggestBoxValue(expectedItem);
        }
    }
}