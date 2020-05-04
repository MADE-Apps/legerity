namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines a helper for navigating the application's menu.
    /// </summary>
    public class NavigationMenu : BasePage
    {
        private readonly By menuList;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationMenu"/> class.
        /// </summary>
        public NavigationMenu()
        {
            this.menuList = ByExtensions.AutomationId("MenuItemsHost");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("NavigationViewControl");

        /// <summary>
        /// Navigates to the basic input page.
        /// </summary>
        /// <returns>
        /// The <see cref="DateAndTimePage"/>.
        /// </returns>
        public DateAndTimePage GoToDateAndTime()
        {
            ListView listView = this.WindowsApp.FindElement(this.menuList);
            listView.ClickItem("Date and Time");
            return new DateAndTimePage();
        }
    }
}