namespace XamlControlsGallery.Pages.Navigation
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the TabView page of the XAML Controls Gallery application.
    /// </summary>
    public class TabViewPage : BasePage
    {
        public TabView TabView => this.WindowsApp.FindElement(ByExtensions.AutomationId("TabView1"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='TabView'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Selects a tab on the page's tab view with the specified name.
        /// </summary>
        /// <param name="name">The name of the tab.</param>
        /// <returns>The <see cref="TabViewPage"/>.</returns>
        public TabViewPage SelectTab(string name)
        {
            this.TabView.SelectTab(name);
            return this;
        }

        /// <summary>
        /// Closes a tab on the page's tab view with the specified name.
        /// </summary>
        /// <param name="name">The name of the tab.</param>
        /// <returns>The <see cref="TabViewPage"/>.</returns>
        public TabViewPage CloseTab(string name)
        {
            this.TabView.CloseTab(name);
            return this;
        }

        /// <summary>
        /// Creates a new tab on the page's tab view.
        /// </summary>
        /// <returns>
        /// The <see cref="TabViewPage"/>.
        /// </returns>
        public TabViewPage CreateTab()
        {
            this.TabView.CreateTab();
            return this;
        }

        /// <summary>
        /// Verifies the tab view item.
        /// </summary>
        /// <param name="expectedItem">
        /// The expected item.
        /// </param>
        public void VerifyTabSelected(string expectedItem)
        {
            Assert.AreEqual(expectedItem, this.TabView.SelectedItem.Text);
        }

        /// <summary>
        /// Verifies the count of tabs.
        /// </summary>
        /// <param name="count">
        /// The count.
        /// </param>
        public void VerifyTabCount(int count)
        {
            Assert.AreEqual(count, this.TabView.Tabs.Count);
        }
    }
}