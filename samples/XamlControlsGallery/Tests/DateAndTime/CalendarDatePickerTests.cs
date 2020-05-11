namespace XamlControlsGallery.Tests.DateAndTime
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.DateAndTime;

    [TestClass]
    public class CalendarDatePickerTests : BaseTestClass
    {
        private static CalendarDatePickerPage CalendarDatePickerPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CalendarDatePickerPage = new NavigationMenu().GoToCalendarDatePickerPage();
        }

        [TestMethod]
        public void SetCalendarDatePickerDate()
        {
            // Arrange
            var expectedDate = new DateTime(2020, 4, 14);

            // Act
            CalendarDatePickerPage.SetCalendarDatePickerDate(expectedDate);

            // Assert
            CalendarDatePickerPage.VerifyCalendarDatePickerDate(expectedDate);
        }
    }
}