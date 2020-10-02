namespace Legerity.Android.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android EditText control.
    /// </summary>
    public class EditText : AndroidElementWrapper
    {
        public EditText(AndroidElement element) : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text box.
        /// </summary>
        public string Text => this.Element.Text;

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="EditText"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="EditText"/>.
        /// </returns>
        public static implicit operator EditText(AndroidElement element)
        {
            return new EditText(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="EditText"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="EditText"/>.
        /// </returns>
        public static implicit operator EditText(AppiumWebElement element)
        {
            return new EditText(element as AndroidElement);
        }

        /// <summary>
        /// Sets the text of the text box to the specified text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void SetText(string text)
        {
            this.ClearText();
            this.AppendText(text);
        }

        /// <summary>
        /// Appends the specified text to the text box.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendText(string text)
        {
            this.Element.Click();
            this.Element.SendKeys(text);
        }

        /// <summary>
        /// Clears the text from the text box.
        /// </summary>
        public void ClearText()
        {
            this.Element.Click();
            this.Element.Clear();
        }
    }
}