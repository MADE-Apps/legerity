namespace Legerity.Windows.Elements.MADE
{
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the MADE.NET UWP InputValidator control.
    /// </summary>
    public class InputValidator : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputValidator"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InputValidator(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the <see cref="TextBlock"/> associated with the validation feedback message.
        /// </summary>
        public TextBlock ValidationFeedback => this.Element.FindElement(WindowsByExtras.AutomationId("ValidatorFeedbackMessage"));

        /// <summary>
        /// Gets the validation feedback message associated with the <see cref="ValidationFeedback"/> element.
        /// </summary>
        public string Message => this.ValidationFeedback?.Text;

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InputValidator"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InputValidator"/>.
        /// </returns>
        public static implicit operator InputValidator(WindowsElement element)
        {
            return new InputValidator(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InputValidator"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InputValidator"/>.
        /// </returns>
        public static implicit operator InputValidator(AppiumWebElement element)
        {
            return new InputValidator(element as WindowsElement);
        }

        /// <summary>
        /// Retrieves the input element with the given locator.
        /// </summary>
        /// <param name="locator">The locator to find the input element.</param>
        /// <returns>The <see cref="AppiumWebElement"/> if found; otherwise, throws <see cref="WebDriverException"/>.</returns>
        public AppiumWebElement Input(By locator)
        {
            return this.Element.FindElement(locator);
        }

        /// <summary>
        /// Retrieves the feedback message text if the <see cref="ValidationFeedback"/> is shown.
        /// </summary>
        /// <returns>The feedback message text of the <see cref="ValidationFeedback"/> element.</returns>
        public string FeedbackMessage()
        {
            string message;

            try
            {
                message = this.ValidationFeedback.Text;
            }
            catch (WebDriverException ex) when (ex.Message.Contains("element could not be located"))
            {
                message = null;
            }

            return message;
        }
    }
}