namespace Legerity.Windows.Elements.WinUI
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the WinUI InfoBar control.
    /// </summary>
    public class InfoBar : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoBar"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InfoBar(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the title of the info bar.
        /// </summary>
        public string Title => this.TitleTextBlock.Text;

        /// <summary>
        /// Gets the message of the info bar.
        /// </summary>
        public string Message => this.MessageTextBlock.Text;

        /// <summary>
        /// Gets a value indicating whether the info bar is open.
        /// </summary>
        public bool IsOpen => !bool.Parse(this.Element.GetAttribute("IsOffscreen"));

        /// <summary>
        /// Gets the element associated with the title <see cref="TextBlock"/>.
        /// </summary>
        public TextBlock TitleTextBlock => this.FindElement(ByExtensions.AutomationId("Title"));

        /// <summary>
        /// Gets the element associated with the message <see cref="TextBlock"/>.
        /// </summary>
        public TextBlock MessageTextBlock => this.FindElement(ByExtensions.AutomationId("Message"));

        /// <summary>
        /// Gets the element associated with the close <see cref="Button"/>.
        /// </summary>
        public Button CloseButton => this.FindElement(ByExtensions.AutomationId("CloseButton"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InfoBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InfoBar"/>.
        /// </returns>
        public static implicit operator InfoBar(WindowsElement element)
        {
            return new InfoBar(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InfoBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InfoBar"/>.
        /// </returns>
        public static implicit operator InfoBar(AppiumWebElement element)
        {
            return new InfoBar(element as WindowsElement);
        }

        /// <summary>
        /// Closes the info bar.
        /// </summary>
        public void Close()
        {
            this.CloseButton.Click();
        }
    }
}