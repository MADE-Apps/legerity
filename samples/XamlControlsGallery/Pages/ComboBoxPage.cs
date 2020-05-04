namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the ComboBox page of the XAML Controls Gallery application.
    /// </summary>
    public class ComboBoxPage : BasePage
    {
        private readonly By colorComboBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxPage"/> class.
        /// </summary>
        public ComboBoxPage()
        {
            this.colorComboBox = By.Name("Colors");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='ComboBox'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the colors combo-box selected item to the specified item..
        /// </summary>
        /// <param name="expectedItem">
        /// The expected item.
        /// </param>
        /// <returns>
        /// The <see cref="ComboBoxPage"/>.
        /// </returns>
        public ComboBoxPage SetColorsComboBoxItem(string expectedItem)
        {
            ComboBox comboBox = this.WindowsApp.FindElement(this.colorComboBox);
            comboBox.SelectItem(expectedItem);
            return this;
        }

        /// <summary>
        /// Verifies that the colors combo-box has been updated.
        /// </summary>
        /// <param name="expectedItem">
        /// The selected item of the combo-box to verify updated.
        /// </param>
        public void VerifyColorsComboBoxItem(string expectedItem)
        {
            ComboBox comboBox = this.WindowsApp.FindElement(this.colorComboBox);
            Assert.AreEqual(expectedItem, comboBox.GetSelectItem());
        }
    }
}