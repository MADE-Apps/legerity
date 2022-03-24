namespace WindowsAlarmsAndClock.Pages
{
    using System;
    using Legerity.Pages;
    using Legerity.Windows;
    using Legerity.Windows.Elements.WinUI;
    using OpenQA.Selenium;

    public class AppPage : BasePage
    {
        public NavigationView NavigationView => this.WindowsApp.FindElement(this.Trait);

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => WindowsByExtras.AutomationId("NavView");

        /// <summary>
        /// Selects a sample from the available options with the given name.
        /// </summary>
        /// <typeparam name="TPage">The type of page to return.</typeparam>
        /// <param name="name">The name of the sample to click.</param>
        /// <returns>The <see cref="TPage"/> instance.</returns>
        public TPage SelectPage<TPage>(string name) where TPage : BasePage
        {
            this.NavigationView.ClickMenuOption(name);
            return Activator.CreateInstance<TPage>();
        }
    }
}
