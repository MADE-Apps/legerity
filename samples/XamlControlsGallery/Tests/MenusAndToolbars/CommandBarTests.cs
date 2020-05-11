namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;
    using XamlControlsGallery.Pages.MenusAndToolbars;

    [TestClass]
    public class CommandBarTests : BaseTestClass
    {
        private static CommandBarPage CommandBarPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CommandBarPage = new NavigationMenu().GoToCommandBarPage();
        }

        [TestMethod]
        public void ClickAddButton()
        {
            CommandBarPage.ClickAddButton();
        }

        [TestMethod]
        public void ClickEditButton()
        {
            CommandBarPage.ClickEditButton();
        }

        [TestMethod]
        public void ClickSettingsButton()
        {
            CommandBarPage.ClickSettingsButton();
        }
    }
}