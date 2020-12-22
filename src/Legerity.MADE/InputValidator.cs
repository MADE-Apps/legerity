namespace Legerity.Windows.Elements.MADE
{
    using Core;
    using Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the MADE.NET UWP InputValidator control.
    /// </summary>
    public class InputValidator : WindowsElementWrapper
    {
        private readonly By validationFeedbackQuery = ByExtensions.AutomationId("ValidatorFeedbackMessage");

        /// <summary>
        /// Initializes a new instance of the <see cref="InputValidator"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InputValidator(WindowsElement element) : base(element)
        {
        }

        /// <summary>
        /// Gets the <see cref="TextBlock"/> associated with the validation feedback message.
        /// </summary>
        public TextBlock ValidationFeedback => this.Element.FindElement(this.validationFeedbackQuery);

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

        public AppiumWebElement Input(By query)
        {
            return this.Element.FindElement(query);
        }

        public string GetFeedbackMessage()
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