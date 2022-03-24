namespace XamlControlsGallery.Pages.BasicInput
{
    using Legerity.Pages;
    using Legerity.Windows;
    using Legerity.Windows.Elements.WinUI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the RatingControl page of the XAML Controls Gallery application.
    /// </summary>
    public class RatingControlPage : BasePage
    {
        private readonly By simpleRatingControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingControlPage"/> class.
        /// </summary>
        public RatingControlPage()
        {
            this.simpleRatingControl = WindowsByExtras.AutomationId("RatingControl1");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='RatingControl'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the simple slider value.
        /// </summary>
        /// <param name="value">
        /// The value to set.
        /// </param>
        /// <returns>
        /// The <see cref="SliderPage"/>.
        /// </returns>
        public RatingControlPage SetSimpleRatingValue(double value)
        {
            RatingControl ratingControl = this.WindowsApp.FindElement(this.simpleRatingControl);
            ratingControl.SetValue(value);
            return this;
        }

        /// <summary>
        /// Verifies that the simple slider value has been updated.
        /// </summary>
        /// <param name="value">
        /// The value of the slider to verify updated.
        /// </param>
        public void VerifySimpleRatingValue(double value)
        {
            RatingControl ratingControl = this.WindowsApp.FindElement(this.simpleRatingControl);
            Assert.AreEqual(value, ratingControl.Value);
        }
    }
}