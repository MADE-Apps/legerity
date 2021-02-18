namespace XamlControlsGallery.Tests.Navigation
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.Navigation;

    [TestClass]
    public class TabViewTests : BaseTestClass
    {
        private static TabViewPage TabViewPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            TabViewPage = new NavigationMenu().GoToTabViewPage();
        }

        [TestMethod]
        public void SelectDocumentTab()
        {
            // Arrange
            string expectedItem = "Document 1";

            // Act
            TabViewPage.SelectTab(expectedItem);

            // Assert
            TabViewPage.VerifyTabSelected(expectedItem);
        }

        [TestMethod]
        public void CloseDocumentTab()
        {
            // Arrange
            string expectedItem = "Document 1";

            // Act
            TabViewPage.CloseTab(expectedItem);

            // Assert
            TabViewPage.VerifyTabCount(2);
        }

        [TestMethod]
        public void AddDocumentTab()
        {
            // Act
            TabViewPage.CreateTab();

            // Assert
            TabViewPage.VerifyTabCount(4);
        }
    }
}