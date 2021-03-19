namespace WindowsCommunityToolkitSampleApp.Pages
{
    using System;
    using System.Linq;
    using System.Threading;
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WinUI;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;

    public class AppPage : BasePage
    {
        private readonly By sampleSearchBoxQuery = ByExtensions.AutomationId("SearchBox");

        /// <summary>
        /// Gets the UI component associated with the sample picker.
        /// </summary>
        public GridView SamplePicker => this.WindowsApp.FindElement(ByExtensions.AutomationId("SamplePickerGridView"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("NavView");

        /// <summary>
        /// Selects a sample from the available options with the given name.
        /// </summary>
        /// <typeparam name="TPage">The type of page to return.</typeparam>
        /// <param name="name">The name of the sample to click.</param>
        /// <returns>The <see cref="TPage"/> instance.</returns>
        public TPage SelectSample<TPage>(string name) where TPage : BasePage
        {
            this.SearchForSample(name);

            AppiumWebElement item = this.SamplePicker.Items.FirstOrDefault(i =>
                i.FindElement(By.XPath($".//*[@ClassName='TextBlock'][@Name='{name}']")) != null);
            item.Click();

            return Activator.CreateInstance<TPage>();
        }

        private void SearchForSample(string sampleName)
        {
            NavigationView navigationView = this.WindowsApp.FindElement(this.Trait);
            AutoSuggestBox controlsSearchBox = navigationView.Element.FindElement(this.sampleSearchBoxQuery);
            controlsSearchBox.SetText(sampleName);

            Thread.Sleep(100);
        }
    }
}
