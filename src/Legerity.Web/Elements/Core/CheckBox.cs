namespace Legerity.Web.Elements.Core
{
    using Legerity.Web.Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Input checkbox control.
    /// </summary>
    public class CheckBox : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public CheckBox(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public CheckBox(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the check box is in the checked state.
        /// </summary>
        public bool IsChecked => this.Element.Selected;

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CheckBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public static implicit operator CheckBox(RemoteWebElement element)
        {
            return new CheckBox(element);
        }

        /// <summary>
        /// Checks the check box on.
        /// </summary>
        public void CheckOn()
        {
            if (this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }

        /// <summary>
        /// Checks the check box off.
        /// </summary>
        public void CheckOff()
        {
            if (!this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }
    }
}