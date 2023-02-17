namespace Legerity.Windows.Elements.Telerik;

using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Minimum => this.GetRangeMinimum();

    /// <summary>
    /// Gets the maximum value of the bullet graph.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Maximum => this.GetRangeMaximum();

    /// <summary>
    /// Gets the value of the bullet graph.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => this.GetRangeValue();

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

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="RadBulletGraph"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadBulletGraph"/>.
    /// </returns>
    public static implicit operator RadBulletGraph(RemoteWebElement element)
    {
        return new RadBulletGraph(element as WindowsElement);
    }
}