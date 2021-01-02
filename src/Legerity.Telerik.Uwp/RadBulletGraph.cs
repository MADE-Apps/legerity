namespace Legerity.Windows.Elements.Telerik
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Telerik UWP RadBulletGraph control.
    /// </summary>
    public class RadBulletGraph : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadBulletGraph"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public RadBulletGraph(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the minimum value of the bullet graph.
        /// </summary>
        public double Minimum => double.Parse(this.Element.GetAttribute("RangeValue.Minimum"));

        /// <summary>
        /// Gets the maximum value of the bullet graph.
        /// </summary>
        public double Maximum => double.Parse(this.Element.GetAttribute("RangeValue.Maximum"));

        /// <summary>
        /// Gets the value of the bullet graph.
        /// </summary>
        public double Value => double.Parse(this.Element.GetAttribute("RangeValue.Value"));

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="RadBulletGraph"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadBulletGraph"/>.
        /// </returns>
        public static implicit operator RadBulletGraph(WindowsElement element)
        {
            return new RadBulletGraph(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="RadBulletGraph"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="RadBulletGraph"/>.
        /// </returns>
        public static implicit operator RadBulletGraph(AppiumWebElement element)
        {
            return new RadBulletGraph(element as WindowsElement);
        }
    }
}