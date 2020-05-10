namespace XamlControlsGallery.Tests.DateAndTime
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.DateAndTime;

    [TestClass]
    public class CalendarViewTests : BaseTestClass
    {
        private static CalendarViewPage CalendarViewPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CalendarViewPage = new NavigationMenu().GoToCalendarViewPage();
        }

        [TestMethod]
        public void SetCalendarViewDate()
        {
            // Arrange
            var expectedDate = new DateTime(2020, 4, 14);

            // Act
            CalendarViewPage.SetCalendarViewDate(expectedDate);

            // Assert
            CalendarViewPage.VerifyCalendarViewDate(expectedDate);
        }
    }
}