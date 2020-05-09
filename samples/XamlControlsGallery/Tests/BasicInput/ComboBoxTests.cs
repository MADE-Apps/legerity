namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;

    [TestClass]
    public class ComboBoxTests : BaseTestClass
    {
        private static ComboBoxPage ComboBoxPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ComboBoxPage = new NavigationMenu().GoToBasicInput().GoToComboBox();
        }

        [TestMethod]
        public void SetColorsComboBoxItem()
        {
            // Arrange
            var expectedItem = "Green";

            // Act
            ComboBoxPage.SetColorsComboBoxItem(expectedItem);

            // Assert
            ComboBoxPage.VerifyColorsComboBoxItem(expectedItem);
        }
    }
}