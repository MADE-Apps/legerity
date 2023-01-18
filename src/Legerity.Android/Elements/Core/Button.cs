namespace Legerity.Android.Elements.Core
{
    using Legerity.Android.Elements;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android Button control.
    /// </summary>
    public class Button : AndroidElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public Button(AndroidElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(AndroidElement element)
        {
            return new Button(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(AppiumWebElement element)
        {
            return new Button(element as AndroidElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(RemoteWebElement element)
        {
            return new Button(element as AndroidElement);
        }
    }
}