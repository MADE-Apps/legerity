namespace WindowsCommunityToolkitSampleApp.Pages
{
    using Legerity.Windows.Elements.WCT;
    using Legerity.Windows.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the Expander page of the Windows Community Toolkit sample application.
    /// </summary>
    public class ExpanderPage : AppPage
    {
        private readonly By verticalExpanderQuery;
        private readonly By horizontalExpanderQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderPage"/> class.
        /// </summary>
        public ExpanderPage()
        {
            this.verticalExpanderQuery = ByExtensions.AutomationId("Expander1");
            this.horizontalExpanderQuery = ByExtensions.AutomationId("Expander2");
        }

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
            Expander expander = this.WindowsApp.FindElement(this.verticalExpanderQuery);

            if (expanded)
            {
                expander.Expand();
            }
            else
            {
                expander.Collapse();
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
            Expander expander = this.WindowsApp.FindElement(this.horizontalExpanderQuery);

            if (expanded)
            {
                expander.Expand();
            }
            else
            {
                expander.Collapse();
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
            Expander expander = this.WindowsApp.FindElement(this.verticalExpanderQuery);
            Assert.AreEqual(expanded, expander.IsExpanded);
        }

        /// <summary>
        /// Verifies that the expanded state has been updated.
        /// </summary>
        /// <param name="expanded">
        /// A value indicating whether the expander should be expanded.
        /// </param>
        public void VerifyHorizontalExpanderState(bool expanded)
        {
            Expander expander = this.WindowsApp.FindElement(this.horizontalExpanderQuery);
            Assert.AreEqual(expanded, expander.IsExpanded);
        }

    }
}
