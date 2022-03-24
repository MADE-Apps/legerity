namespace WindowsCommunityToolkitSampleApp.Pages
{
    using Legerity.Windows;
    using Legerity.Windows.Elements.WCT;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Expander page of the Windows Community Toolkit sample application.
    /// </summary>
    public class ExpanderPage : AppPage
    {
        public Expander VerticalExpander => this.WindowsApp.FindElement(WindowsByExtras.AutomationId("Expander1"));

        public Expander HorizontalExpander => this.WindowsApp.FindElement(WindowsByExtras.AutomationId("Expander2"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='Expander']");

        /// <summary>
        /// Toggles the expander content.
        /// </summary>
        /// <param name="expanded">
        /// A value indicating whether to toggle expanded.
        /// </param>
        /// <returns>
        /// The <see cref="ExpanderPage"/>.
        /// </returns>
        public ExpanderPage ToggleVerticalExpander(bool expanded)
        {
            if (expanded)
            {
                this.VerticalExpander.Expand();
            }
            else
            {
                this.VerticalExpander.Collapse();
            }

            return this;
        }

        /// <summary>
        /// Toggles the expander content.
        /// </summary>
        /// <param name="expanded">
        /// A value indicating whether to toggle expanded.
        /// </param>
        /// <returns>
        /// The <see cref="ExpanderPage"/>.
        /// </returns>
        public ExpanderPage ToggleHorizontalExpander(bool expanded)
        {
            if (expanded)
            {
                this.HorizontalExpander.Expand();
            }
            else
            {
                this.HorizontalExpander.Collapse();
            }

            return this;
        }

        /// <summary>
        /// Verifies that the expanded state has been updated.
        /// </summary>
        /// <param name="expanded">
        /// A value indicating whether the expander should be expanded.
        /// </param>
        public void VerifyVerticalExpanderState(bool expanded)
        {
            Assert.AreEqual(expanded, this.VerticalExpander.IsExpanded);
        }

        /// <summary>
        /// Verifies that the expanded state has been updated.
        /// </summary>
        /// <param name="expanded">
        /// A value indicating whether the expander should be expanded.
        /// </param>
        public void VerifyHorizontalExpanderState(bool expanded)
        {
            Assert.AreEqual(expanded, this.HorizontalExpander.IsExpanded);
        }

    }
}
