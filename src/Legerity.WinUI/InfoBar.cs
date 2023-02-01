namespace Legerity.Windows.Elements.WinUI
{
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

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
        public virtual string Title => this.TitleTextBlock.Text;

        /// <summary>
        /// Gets the message of the info bar.
        /// </summary>
        public virtual string Message => this.MessageTextBlock.Text;

        /// <summary>
        /// Gets a value indicating whether the info bar is open.
        /// </summary>
        public virtual bool IsOpen => !bool.Parse(this.GetAttribute("IsOffscreen"));

        /// <summary>
        /// Gets the element associated with the title <see cref="TextBlock"/>.
        /// </summary>
        public virtual TextBlock TitleTextBlock => this.FindElement(WindowsByExtras.AutomationId("Title"));

        /// <summary>
        /// Gets the element associated with the message <see cref="TextBlock"/>.
        /// </summary>
        public virtual TextBlock MessageTextBlock => this.FindElement(WindowsByExtras.AutomationId("Message"));

        /// <summary>
        /// Gets the element associated with the close <see cref="Button"/>.
        /// </summary>
        public virtual Button CloseButton => this.FindElement(WindowsByExtras.AutomationId("CloseButton"));

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
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InfoBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InfoBar"/>.
        /// </returns>
        public static implicit operator InfoBar(RemoteWebElement element)
        {
            return new InfoBar(element as WindowsElement);
        }

        /// <summary>
        /// Closes the info bar.
        /// </summary>
        public virtual void Close()
        {
            this.CloseButton.Click();
        }
    }
}