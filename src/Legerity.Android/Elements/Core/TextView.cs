namespace Legerity.Android.Elements.Core
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android TextView control.
    /// </summary>
    public class TextView : AndroidElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public TextView(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text view.
        /// </summary>
        public virtual string Text => this.Element.Text;

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="TextView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextView"/>.
        /// </returns>
        public static implicit operator TextView(AndroidElement element)
        {
            return new TextView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextView"/>.
        /// </returns>
        public static implicit operator TextView(AppiumWebElement element)
        {
            return new TextView(element as AndroidElement);
        }
    }
}