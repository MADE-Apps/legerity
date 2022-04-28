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
        private readonly By moreButtonLocator = WindowsByExtras.AutomationId("MoreButton");

        private readonly By overflowPopupLocator = WindowsByExtras.AutomationId("OverflowPopup");

        private readonly By appBarButtonLocator = By.ClassName(nameof(AppBarButton));

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
        public virtual IEnumerable<AppBarButton> PrimaryButtons =>
            this.Element.FindElements(this.appBarButtonLocator)
                .Select<AppiumWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Gets the <see cref="AppBarButton"/> for opening the secondary button menu.
        /// </summary>
        public virtual AppBarButton SecondaryMenuButton => this.Element.FindElement(this.moreButtonLocator);

        /// <summary>
        /// Gets the collection of secondary buttons.
        /// <para>
        /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
        /// </para>
        /// </summary>
        public virtual IEnumerable<AppBarButton> SecondaryButtons =>
            this.Driver.FindElement(this.overflowPopupLocator).FindElements(this.appBarButtonLocator)
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
        /// Clicks a primary button in the command bar with the specified button name or Automation ID.
        /// </summary>
        /// <param name="name">
        /// The name of the button to click.
        /// </param>
        public virtual void ClickPrimaryButton(string name)
        {
            AppBarButton item = this.PrimaryButtons.FirstOrDefault(
                element => element.Element.VerifyNameOrAutomationIdEquals(name));

            item.Click();
        }

        /// <summary>
        /// Clicks a primary button in the command bar with the specified partial button name or Automation ID.
        /// </summary>
        /// <param name="partialName">
        /// The partial name of the button to click.
        /// </param>
        public virtual void ClickPrimaryButtonByPartialName(string partialName)
        {
            AppBarButton item = this.PrimaryButtons.FirstOrDefault(
                element => element.Element.VerifyNameOrAutomationIdContains(partialName));

            item.Click();
        }

        /// <summary>
        /// Clicks a secondary button in the command bar with the specified button name.
        /// </summary>
        /// <param name="name">
        /// The name of the button to click.
        /// </param>
        public virtual void ClickSecondaryButton(string name)
        {
            this.OpenSecondaryButtonMenu();

            AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
                button => button.Element.VerifyNameOrAutomationIdEquals(name));

            secondaryButton.Click();
        }

        /// <summary>
        /// Clicks a secondary button in the command bar with the specified partial button name.
        /// </summary>
        /// <param name="partialName">
        /// The partial name of the button to click.
        /// </param>
        public virtual void ClickSecondaryButtonByPartialName(string partialName)
        {
            this.OpenSecondaryButtonMenu();

            AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
                button => button.Element.VerifyNameOrAutomationIdContains(partialName));

            secondaryButton.Click();
        }

        /// <summary>
        /// Opens the menu associated with the secondary button options.
        /// </summary>
        public virtual void OpenSecondaryButtonMenu()
        {
            this.VerifyElementShown(this.moreButtonLocator, TimeSpan.FromSeconds(2));
            this.SecondaryMenuButton.Click();
            this.VerifyDriverElementShown(this.overflowPopupLocator, TimeSpan.FromSeconds(2));
        }
    }
}