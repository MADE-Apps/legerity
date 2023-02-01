namespace Legerity.Windows.Elements.Core
{
    using System;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ProgressBar control.
    /// </summary>
    public class ProgressBar : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public ProgressBar(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the value of the progress bar.
        /// </summary>
        public virtual double Percentage => this.GetRangeValue();

        /// <summary>
        /// Gets a value indicating whether the control is in an indeterminate state.
        /// </summary>
        public bool IsIndeterminate =>
            this.GetAttribute("IsRangeValuePatternAvailable").Equals(
                "False",
                StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ProgressBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressBar"/>.
        /// </returns>
        public static implicit operator ProgressBar(WindowsElement element)
        {
            return new ProgressBar(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ProgressBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressBar"/>.
        /// </returns>
        public static implicit operator ProgressBar(AppiumWebElement element)
        {
            return new ProgressBar(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ProgressBar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressBar"/>.
        /// </returns>
        public static implicit operator ProgressBar(RemoteWebElement element)
        {
            return new ProgressBar(element as WindowsElement);
        }
    }
}