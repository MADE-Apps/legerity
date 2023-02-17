namespace Legerity.IOS.Elements.Core;

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

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
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Percentage => double.Parse(this.GetValue().TrimEnd('%'));

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

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ProgressView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ProgressView"/>.
    /// </returns>
    public static implicit operator ProgressView(RemoteWebElement element)
    {
        return new ProgressView(element as IOSElement);
    }
}