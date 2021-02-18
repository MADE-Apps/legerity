namespace XamlControlsGallery.Pages.Text
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the NumberBox page of the XAML Controls Gallery application.
    /// </summary>
    public class NumberBoxPage : BasePage
    {
        private readonly By spinnerNumberBoxQuery = ByExtensions.AutomationId("NumberBoxSpinButtonPlacementExample");

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBoxPage"/> class.
        /// </summary>
        public NumberBoxPage()
        {
        }

        /// <summary>
        /// Gets the element associated with the spinner number box.
        /// </summary>
        public NumberBox SpinnerNumberBox => this.WindowsApp.FindElement(this.spinnerNumberBoxQuery);

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='NumberBox'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the spinner number box value to the specified value.
        /// </summary>
        /// <param name="value">
        /// The value to set.
        /// </param>
        /// <returns>
        /// The <see cref="NumberBoxPage"/>.
        /// </returns>
        public NumberBoxPage SetSpinnerNumberBoxValue(double value)
        {
            this.SpinnerNumberBox.SetValue(value);
            return this;
        }

        /// <summary>
        /// Increases the spinner number box value.
        /// </summary>
        /// <returns>
        /// The <see cref="NumberBoxPage"/>.
        /// </returns>
        public NumberBoxPage IncrementSpinnerNumberBoxValue()
        {
            this.SpinnerNumberBox.Increment();
            return this;
        }

        /// <summary>
        /// Decreases the spinner number box value.
        /// </summary>
        /// <returns>
        /// The <see cref="NumberBoxPage"/>.
        /// </returns>
        public NumberBoxPage DecrementSpinnerNumberBoxValue()
        {
            this.SpinnerNumberBox.Decrement();
            return this;
        }

        /// <summary>
        /// Verifies that the spinner number box has been updated.
        /// </summary>
        /// <param name="expectedValue">
        /// The value of the spinner number box to verify updated.
        /// </param>
        public void VerifySpinnerNumberBoxValue(double expectedValue)
        {
            Assert.AreEqual(expectedValue, this.SpinnerNumberBox.Value);
        }
    }
}