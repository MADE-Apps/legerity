namespace XamlControlsGallery.Tests.DateAndTime
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.DateAndTime;

    [TestClass]
    public class TimePickerTests : BaseTestClass
    {
        private static TimePickerPage TimePickerPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            TimePickerPage = new NavigationMenu().GoToDateAndTime().GoToTimePicker();
        }

        [TestMethod]
        public void SetSimpleTimePickerTime()
        {
            // Arrange
            var expectedTime = new TimeSpan(7, 5, 0);

            // Act
            TimePickerPage.SetSimpleTimePickerTime(expectedTime);

            // Assert
            TimePickerPage.VerifySimpleTimePickerTime(expectedTime);
        }
    }
}