namespace XamlControlsGallery.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;

    [TestClass]
    public class SliderTests : BaseTestClass
    {
        private static SliderPage SliderPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            SliderPage = new NavigationMenu().GoToBasicInput().GoToSlider();
        }

        [TestMethod]
        public void SetSliderValue()
        {
            // Arrange
            const int expectedValue = 62;

            // Act
            SliderPage.SetSimpleSliderValue(expectedValue);

            // Assert
            SliderPage.VerifySimpleSliderValue(expectedValue);
        }
    }
}