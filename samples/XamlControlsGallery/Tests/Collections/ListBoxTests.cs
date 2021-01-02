namespace XamlControlsGallery.Tests.Collections
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.Collections;

    [TestClass]
    public class ListBoxTests : BaseTestClass
    {
        private static ListBoxPage ListBoxPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ListBoxPage = new NavigationMenu().GoToListBox();
        }

        [TestMethod]
        public void SetColorItem()
        {
            // Arrange
            const string expectedItem = "Green";

            // Act
            ListBoxPage.SetColorItem(expectedItem);

            // Assert
            ListBoxPage.VerifyColorItem(expectedItem);
        }
    }
}