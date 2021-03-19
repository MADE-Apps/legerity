namespace WindowsCommunityToolkitSampleApp.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;

    [TestClass]
    public class CarouselTests : BaseTestClass
    {
        private static CarouselPage CarouselPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CarouselPage = new AppPage().SelectSample<CarouselPage>("Carousel");
        }

        [TestMethod]
        public void SetCarouselItemByName()
        {
            // Arrange
            string expectedItem = "November hike waterfall";

            // Act
            CarouselPage.SelectCarouselItem(expectedItem);

            // Assert
            CarouselPage.VerifySelectedCarouselItem(expectedItem);
        }

        [TestMethod]
        public void SetCarouselItemByIndex()
        {
            // Arrange
            int expectedIndex = 1;

            // Act
            CarouselPage.SelectCarouselItem(expectedIndex);

            // Assert
            CarouselPage.VerifySelectedCarouselItem(expectedIndex);
        }

    }

}
