namespace MADESampleApp.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages;
    using Shouldly;

    [TestClass]
    public class InputValidatorTests : BaseTestClass
    {
        private static AppPage AppPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            AppPage = new AppPage();
        }

        [TestMethod]
        public void SetEmailTextBoxValid()
        {
            // Arrange
            const string email = "me@jamescroft.co.uk";

            // Act
            AppPage.SetTextBoxText(email);

            // Assert
            AppPage.TextInput.Text.ShouldBe(email);
            AppPage.TextInputValidator.FeedbackMessage().ShouldBeNull();
        }

        [TestMethod]
        public void SetEmailTextBoxInvalid()
        {
            // Arrange
            const string email = "me@james@croft.co.uk";

            // Act
            AppPage.SetTextBoxText(email);

            // Assert
            AppPage.TextInput.Text.ShouldBe(email);
            AppPage.TextInputValidator.FeedbackMessage().ShouldNotBeNull();
        }

        [TestMethod]
        public void SetDatePickerValid()
        {
            // Arrange
            DateTime date = DateTime.Now;

            // Act
            AppPage.SetDatePickerDate(date);

            // Assert
            AppPage.DateInputValidator.FeedbackMessage().ShouldBeNull();
        }

        [TestMethod]
        public void SetDatePickerInvalid()
        {
            // Arrange
            DateTime date = DateTime.Now.AddDays(-7);

            // Act
            AppPage.SetDatePickerDate(date);

            // Assert
            AppPage.DateInputValidator.FeedbackMessage().ShouldNotBeNull();
        }
    }
}