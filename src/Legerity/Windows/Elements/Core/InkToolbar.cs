namespace Legerity.Windows.Elements.Core
{
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP InkToolbar control.
    /// </summary>
    public class InkToolbar : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbar"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InkToolbar(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the ballpoint pen button.
        /// </summary>
        public Button BallpointPenButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarBallpointPenButton"));

        /// <summary>
        /// Gets the element associated with the pencil button.
        /// </summary>
        public Button PencilButton => this.Element.FindElement(ByExtensions.AutomationId("InkToolbarPencilButton"));

        /// <summary>
        /// Gets the element associated with the highlighter button.
        /// </summary>
        public Button HighlighterButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarHighlighterButton"));

        /// <summary>
        /// Gets the element associated with the ruler button.
        /// </summary>
        public Button RulerButton => this.Element.FindElement(ByExtensions.AutomationId("InkToolbarStencilButton"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbar"/>.
        /// </returns>
        public static implicit operator InkToolbar(WindowsElement element)
        {
            return new InkToolbar(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbar"/>.
        /// </returns>
        public static implicit operator InkToolbar(AppiumWebElement element)
        {
            return new InkToolbar(element as WindowsElement);
        }
    }
}