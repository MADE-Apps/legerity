namespace Legerity.IOS.Elements.Core
{
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Defines a <see cref="IOSElement"/> wrapper for the core iOS ProgressView control.
    /// </summary>
    public class ProgressView : IOSElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressView"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/> reference.
        /// </param>
        public ProgressView(IOSElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the value of the progress bar.
        /// </summary>
        public double Percentage => double.Parse(this.Element.GetValue().TrimEnd('%'));
        
        /// <summary>
        /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="ProgressView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IOSElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressView"/>.
        /// </returns>
        public static implicit operator ProgressView(IOSElement element)
        {
            return new ProgressView(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ProgressView"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ProgressView"/>.
        /// </returns>
        public static implicit operator ProgressView(AppiumWebElement element)
        {
            return new ProgressView(element as IOSElement);
        }
    }
}