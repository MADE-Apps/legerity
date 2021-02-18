namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.MenusAndToolbars;

    [TestClass]
    public class MenuBarTests : BaseTestClass
    {
        private static MenuBarPage MenuBarPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            MenuBarPage = new NavigationMenu().GoToMenuBarPage();
        }

        [TestMethod]
        public void ClickSimpleFileNewButton()
        {
            MenuBarPage.SelectSimpleMenuBarOption("File", "New");
        }

        [TestMethod]
        public void ClickSimpleEditCopyButton()
        {
            MenuBarPage.SelectSimpleMenuBarOption("Edit", "Copy");
        }

        [TestMethod]
        public void ClickSimpleHelpAboutButton()
        {
            MenuBarPage.SelectSimpleMenuBarOption("Help", "About");
        }

        [TestMethod]
        public void ClickSubMenusFileNewPlainTextDocumentButton()
        {
            MenuBarPage.SelectMenuBarWithSubMenusOption("File", "New", "Plain Text Document");
        }
    }
}