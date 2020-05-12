namespace XamlControlsGallery.Tests.Collections
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.Collections;

    [TestClass]
    public class FlipViewTests : BaseTestClass
    {
        private static FlipViewPage FlipViewPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            FlipViewPage = new NavigationMenu().GoToFlipViewPage();
        }

        [TestMethod]
        public void SetXamlFlipViewItemToAppBarButton()
        {
            // Arrange
            var expectedItem = "AppBarButton";

            // Act
            FlipViewPage.SelectXamlFlipViewItem(expectedItem);

            // Assert
            FlipViewPage.VerifyXamlFlipViewItem(expectedItem);
        }
    }
}