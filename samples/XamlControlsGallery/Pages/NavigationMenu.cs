namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a helper for navigating the application's menu.
    /// </summary>
    public class NavigationMenu : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationMenu"/> class.
        /// </summary>
        public NavigationMenu()
        {
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("NavigationViewControl");

        /// <summary>
        /// Navigates to the date and time page.
        /// </summary>
        /// <returns>
        /// The <see cref="DateAndTimePage"/>.
        /// </returns>
        public DateAndTimePage GoToDateAndTime()
        {
            NavigationView navigationMenu = this.WindowsApp.FindElement(this.Trait);
            navigationMenu.ClickMenuOption("Date and Time");
            return new DateAndTimePage();
        }

        /// <summary>
        /// Navigates to the basic input page.
        /// </summary>
        /// <returns>
        /// The <see cref="DateAndTimePage"/>.
        /// </returns>
        public BasicInputPage GoToBasicInput()
        {
            NavigationView navigationMenu = this.WindowsApp.FindElement(this.Trait);
            navigationMenu.ClickMenuOption("Basic Input");
            return new BasicInputPage();
        }
    }
}