namespace XamlControlsGallery.Tests.StatusAndInfo
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Pages.StatusAndInfo;

    [TestClass]
    public class InfoBarTests : BaseTestClass
    {
        private static InfoBarPage InfoBarPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            InfoBarPage = new NavigationMenu().GoToInfoBarPage();
        }

        [TestMethod]
        public void CloseClosableBarWithOptions()
        {
            InfoBarPage.CloseClosableBarWithOptions();
        }
    }
}