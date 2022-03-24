namespace XamlControlsGallery.Pages.MenusAndToolbars
{
    using Legerity.Pages;
    using Legerity.Windows;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WinUI;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the MenuBar page of the XAML Controls Gallery application.
    /// </summary>
    public class MenuBarPage : BasePage
    {
        public MenuBar SimpleMenuBar => this.WindowsApp.FindElement(WindowsByExtras.AutomationId("Example1"));

        public MenuBar MenuBarWithSubMenus => this.WindowsApp.FindElement(WindowsByExtras.AutomationId("Example3"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='MenuBar'][@AutomationId='TitleTextBlock']");

        public MenuBarPage SelectSimpleMenuBarOption(string name, string child = null)
        {
            MenuBarItem option = this.SimpleMenuBar.ClickOption(name);
            if (!string.IsNullOrWhiteSpace(child))
            {
                option.ClickChildOption(child);
            }
            return this;
        }

        public MenuBarPage SelectMenuBarWithSubMenusOption(string name, string child = null, string subChild = null)
        {
            MenuBarItem option = this.MenuBarWithSubMenus.ClickOption(name);
            if (string.IsNullOrWhiteSpace(child))
            {
                return this;
            }

            if (string.IsNullOrWhiteSpace(subChild))
            {
                option.ClickChildOption(child);
            }
            else
            {
                MenuFlyoutSubItem childSubItem = option.ClickChildSubOption(child);
                childSubItem.ClickChildOption(subChild);
            }

            return this;
        }
    }
}