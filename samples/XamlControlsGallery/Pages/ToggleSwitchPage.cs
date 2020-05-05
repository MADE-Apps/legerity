namespace XamlControlsGallery.Pages
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines the ToggleSwitch page of the XAML Controls Gallery application.
    /// </summary>
    public class ToggleSwitchPage : BasePage
    {
        private readonly By simpleToggleSwitch;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleSwitchPage"/> class.
        /// </summary>
        public ToggleSwitchPage()
        {
            this.simpleToggleSwitch = By.Name("simple ToggleSwitch");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='ToggleSwitch'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Toggles the simple switch.
        /// </summary>
        /// <param name="on">
        /// A value indicating whether to toggle on.
        /// </param>
        /// <returns>
        /// The <see cref="SliderPage"/>.
        /// </returns>
        public ToggleSwitchPage ToggleSimpleSwitch(bool on)
        {
            ToggleSwitch toggle = this.WindowsApp.FindElement(this.simpleToggleSwitch);

            if (on)
            {
                toggle.ToggleOn();
            }
            else
            {
                toggle.ToggleOff();
            }

            return this;
        }

        /// <summary>
        /// Verifies that the simple toggle switch state has been updated.
        /// </summary>
        /// <param name="on">
        /// A value indicating whether the toggle should be on.
        /// </param>
        public void VerifySimpleToggleSwitch(bool on)
        {
            ToggleSwitch toggle = this.WindowsApp.FindElement(this.simpleToggleSwitch);
            Assert.AreEqual(on, toggle.IsOn);
        }
    }
}