namespace XamlControlsGallery.Pages.MenusAndToolbars
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the CommandBar page of the XAML Controls Gallery application.
    /// </summary>
    public class CommandBarPage : BasePage
    {
        public CommandBar PrimaryCommandBar => this.WindowsApp.FindElement(ByExtensions.AutomationId("PrimaryCommandBar"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='CommandBar'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Clicks the add button.
        /// </summary>
        /// <returns>
        /// The <see cref="CommandBarPage"/>.
        /// </returns>
        public CommandBarPage ClickAddButton()
        {
            this.PrimaryCommandBar.ClickPrimaryButton("addButton");
            return this;
        }

        /// <summary>
        /// Clicks the edit button.
        /// </summary>
        /// <returns>
        /// The <see cref="CommandBarPage"/>.
        /// </returns>
        public CommandBarPage ClickEditButton()
        {
            this.PrimaryCommandBar.ClickPrimaryButton("editButton");
            return this;
        }

        /// <summary>
        /// Clicks the settings button.
        /// </summary>
        /// <returns>The <see cref="CommandBarPage"/>.</returns>
        public CommandBarPage ClickSettingsButton()
        {
            this.PrimaryCommandBar.ClickSecondaryButton("settingsButton");
            return this;
        }
    }
}