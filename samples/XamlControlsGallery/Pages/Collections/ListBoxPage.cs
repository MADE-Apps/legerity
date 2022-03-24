namespace XamlControlsGallery.Pages.Collections
{
    using Legerity.Pages;
    using Legerity.Windows;
    using Legerity.Windows.Elements.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the ListBox page of the XAML Controls Gallery application.
    /// </summary>
    public class ListBoxPage : BasePage
    {
        private readonly By colorListBox = WindowsByExtras.AutomationId("ListBox1");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='ListBox'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the colors combo-box selected item to the specified item..
        /// </summary>
        /// <param name="expectedItem">
        /// The expected item.
        /// </param>
        /// <returns>
        /// The <see cref="ListBoxPage"/>.
        /// </returns>
        public ListBoxPage SetColorItem(string expectedItem)
        {
            ListBox listBox = this.WindowsApp.FindElement(this.colorListBox);
            listBox.ClickItem(expectedItem);
            return this;
        }

        /// <summary>
        /// Verifies that the colors combo-box has been updated.
        /// </summary>
        /// <param name="expectedItem">
        /// The selected item of the combo-box to verify updated.
        /// </param>
        public void VerifyColorItem(string expectedItem)
        {
            ListBox listBox = this.WindowsApp.FindElement(this.colorListBox);
            Assert.AreEqual(expectedItem, listBox.SelectedItem.Text);
        }
    }
}