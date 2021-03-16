namespace WindowsCommunityToolkitSampleApp.Pages
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WCT;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the BladeView page of the Windows Community Toolkit sample application.
    /// </summary>
    public class BladeViewPage : AppPage
    {
        private readonly By bladeViewQuery = ByExtensions.AutomationId("BladeView");

        /// <summary>
        /// Initializes a new instance of the <see cref="BladeViewPage"/> class.
        /// </summary>
        public BladeViewPage()
        {
        }

        public BladeView BladeView => this.WindowsApp.FindElement(this.bladeViewQuery);

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='BladeView']");

        public BladeViewPage CloseBlade(string name)
        {
            this.BladeView.CloseBlade(name);
            return this;
        }

        public BladeViewPage ToggleBladeSize(string name)
        {
            BladeViewItem blade = this.BladeView.GetBlade(name);
            blade.EnlargeButton.Click();
            return this;
        }

        public BladeViewPage OpenBlades()
        {
            BladeViewItem firstBlade = this.BladeView.GetBlade("FirstBlade");
            FindFirstBladeButton(firstBlade, "ToggleButton", "Default Blade").Click();
            this.ScrollBack();

            FindFirstBladeButton(firstBlade, "ToggleButton", "Custom Titlebar").Click();
            this.ScrollBack();

            FindFirstBladeButton(firstBlade, "ToggleButton", "Custom Close Button").Click();
            this.ScrollBack();

            FindFirstBladeButton(firstBlade, "Button", "Add Blade").Click();
            this.ScrollBack();

            return this;
        }

        private void ScrollBack()
        {
            this.BladeView.Element.SendKeys(Keys.ArrowLeft);
            this.BladeView.Element.SendKeys(Keys.ArrowLeft);
            this.BladeView.Element.SendKeys(Keys.ArrowLeft);
        }

        private static Button FindFirstBladeButton(BladeViewItem blade, string type, string name)
        {
            return blade.Element.FindElement(By.XPath($".//*[@ClassName='{type}'][@Name='{name}']"));
        }
    }
}
