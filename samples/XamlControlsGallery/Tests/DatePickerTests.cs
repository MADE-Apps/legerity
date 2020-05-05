namespace XamlControlsGallery.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;

    [TestClass]
    public class DatePickerTests : BaseTestClass
    {
        private static DatePickerPage DatePickerPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            DatePickerPage = new NavigationMenu().GoToDateAndTime().GoToDatePicker();
        }

        [TestMethod]
        public void SetSimpleDatePickerDate()
        {
            // Arrange
            var expectedDate = new DateTime(2020, 4, 14);

            // Act
            DatePickerPage.SetSimpleDatePickerDate(expectedDate);

            // Assert
            DatePickerPage.VerifySimpleTimePickerTime(expectedDate);
        }
    }
}