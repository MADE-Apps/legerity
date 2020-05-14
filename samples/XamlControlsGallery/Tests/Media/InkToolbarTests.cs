namespace XamlControlsGallery.Tests.Media
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.DateAndTime;
    using XamlControlsGallery.Pages.Media;

    [TestClass]
    public class InkToolbarTests : BaseTestClass
    {
        private static InkToolbarPage InkToolbarPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            InkToolbarPage = new NavigationMenu().GoToInkToolbarPage();
        }

        [TestMethod]
        public void SetBallpointPenWithGreenInk()
        {
            InkToolbarPage.SelectBallpointPenColor("Green");
        }

        [TestMethod]
        public void SetPencilWithBlueInk()
        {
            InkToolbarPage.SelectPencilColor("Blue");
        }

        [TestMethod]
        public void SetHighlighterWithPinkInk()
        {
            InkToolbarPage.SelectHighlighterColor("Pink");
        }
    }
}