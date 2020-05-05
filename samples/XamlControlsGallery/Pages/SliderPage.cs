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
    /// Defines the SliderPage page of the XAML Controls Gallery application.
    /// </summary>
    public class SliderPage : BasePage
    {
        private readonly By simpleSlider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SliderPage"/> class.
        /// </summary>
        public SliderPage()
        {
            this.simpleSlider = By.Name("simple slider");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='Slider'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the simple slider value.
        /// </summary>
        /// <param name="value">
        /// The value to set.
        /// </param>
        /// <returns>
        /// The <see cref="SliderPage"/>.
        /// </returns>
        public SliderPage SetSimpleSliderValue(double value)
        {
            Slider slider = this.WindowsApp.FindElement(this.simpleSlider);
            slider.SetValue(value);
            return this;
        }

        /// <summary>
        /// Verifies that the simple slider value has been updated.
        /// </summary>
        /// <param name="value">
        /// The value of the slider to verify updated.
        /// </param>
        public void VerifySimpleSliderValue(double value)
        {
            Slider slider = this.WindowsApp.FindElement(this.simpleSlider);
            Assert.AreEqual(value, slider.Value);
        }
    }
}