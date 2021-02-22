namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;

    [TestClass]
    public class RatingControlTests : BaseTestClass
    {
        private static RatingControlPage RatingControlPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            RatingControlPage = new NavigationMenu().GoToRatingControl();
        }

        [TestMethod]
        public void SetSliderValue()
        {
            // Arrange
            const int expectedValue = 3;

            // Act
            RatingControlPage.SetSimpleRatingValue(expectedValue);

            // Assert
            RatingControlPage.VerifySimpleRatingValue(expectedValue);
        }
    }
}