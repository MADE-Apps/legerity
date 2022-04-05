namespace Legerity.IOS.Elements.Core
{
    using Legerity.IOS.Elements;
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Defines a <see cref="IOSElement"/> wrapper for the core iOS TextField control.
    /// </summary>
    public class TextField : IOSElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextField"/> class.
        /// </summary>
        /// <param name="element">The <see cref="IOSElement"/> representing the <see cref="TextField"/> element.</param>
        public TextField(IOSElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text field.
        /// </summary>
        public string Text => this.Element.GetValue();

        /// <summary>
        /// Gets the element associated with the clear text button, if shown.
        /// </summary>
        public Button ClearTextButton => this.Element.FindElement(IOSByExtras.Label("Clear text"));

        /// <summary>
        /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="TextField"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextField"/>.
        /// </returns>
        public static implicit operator TextField(IOSElement element)
        {
            return new TextField(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextField"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextField"/>.
        /// </returns>
        public static implicit operator TextField(AppiumWebElement element)
        {
            return new TextField(element as IOSElement);
        }

        /// <summary>
        /// Sets the text of the text field to the specified text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void SetText(string text)
        {
            this.ClearText();
            this.AppendText(text);
        }

        /// <summary>
        /// Appends the specified text to the text field.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendText(string text)
        {
            this.Element.Click();
            this.Element.SendKeys(text);
        }

        /// <summary>
        /// Clears the text from the text field.
        /// </summary>
        public void ClearText()
        {
            this.Element.Click();
            this.Element.Clear();
        }
    }
}