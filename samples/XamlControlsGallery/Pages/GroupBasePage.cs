namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines a base page for the XAML Controls Gallery group page.
    /// </summary>
    public abstract class GroupBasePage : BasePage
    {
        /// <summary>
        /// Gets the query associated with the control list.
        /// </summary>
        public By ControlList => By.Name("Items In Group");

        /// <summary>
        /// Navigates to a page within the control list.
        /// </summary>
        /// <param name="page">
        /// The page name.
        /// </param>
        public void NavigateTo(string page)
        {
            GridView gridView = this.WindowsApp.FindElement(this.ControlList);
            gridView.ClickItem(page);
        }
    }
}
