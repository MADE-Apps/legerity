namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP CommandBar control.
    /// </summary>
    public class CommandBar : WindowsElementWrapper
    {
        private readonly By secondaryOverflowButtonQuery = ByExtensions.AutomationId("MoreButton");

        private readonly By secondaryOverflowPopupQuery = ByExtensions.AutomationId("OverflowPopup");

        private readonly By appBarButtonItemQuery = By.ClassName("AppBarButton");

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBar"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public CommandBar(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the collection of primary buttons.
        /// </summary>
        public IEnumerable<AppBarButton> PrimaryButtons =>
            this.Element.FindElements(this.appBarButtonItemQuery)
                .Select<AppiumWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Gets the collection of secondary buttons.
        /// <para>
        /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
        /// </para>
        /// </summary>
        public IEnumerable<AppBarButton> SecondaryButtons =>
            this.Driver.FindElement(this.secondaryOverflowPopupQuery).FindElements(this.appBarButtonItemQuery)
                .Select<AppiumWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CommandBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CommandBar"/>.
        /// </returns>
        public static implicit operator CommandBar(WindowsElement element)
        {
            return new CommandBar(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CommandBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="CommandBar"/>.
        /// </returns>
        public static implicit operator CommandBar(AppiumWebElement element)
        {
            return new CommandBar(element as WindowsElement);
        }

        /// <summary>
        /// Clicks a primary button in the command bar with the specified button name.
        /// </summary>
        /// <param name="name">
        /// The name of the button to click.
        /// </param>
        public void ClickPrimaryButton(string name)
        {
            AppBarButton item = this.PrimaryButtons.FirstOrDefault(
                element => element.Element.VerifyNameOrAutomationIdEquals(name));

            item.Click();
        }

        /// <summary>
        /// Clicks a secondary button in the command bar with the specified button name.
        /// </summary>
        /// <param name="name">
        /// The name of the button to click.
        /// </param>
        public void ClickSecondaryButton(string name)
        {
            this.VerifyElementShown(this.secondaryOverflowButtonQuery, TimeSpan.FromSeconds(2));

            AppBarButton secondaryOverflowButton = this.Element.FindElement(this.secondaryOverflowButtonQuery);
            secondaryOverflowButton.Click();

            this.VerifyDriverElementShown(this.secondaryOverflowPopupQuery, TimeSpan.FromSeconds(2));

            AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
                button => button.Element.VerifyNameOrAutomationIdEquals(name));

            secondaryButton.Click();
        }
    }
}