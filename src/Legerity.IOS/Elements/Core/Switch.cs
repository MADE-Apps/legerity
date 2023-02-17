namespace Legerity.IOS.Elements.Core;

using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IOSElement"/> wrapper for the core iOS Switch control.
/// </summary>
public class Switch : IOSElementWrapper
{
    private const string ToggleOnValue = "1";

    /// <summary>
    /// Initializes a new instance of the <see cref="Switch"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/> reference.
    /// </param>
    public Switch(IOSElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle switch is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetValue() == ToggleOnValue;

    /// <summary>
    /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="Switch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Switch"/>.
    /// </returns>
    public static implicit operator Switch(IOSElement element)
    {
        return new Switch(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Switch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Switch"/>.
    /// </returns>
    public static implicit operator Switch(AppiumWebElement element)
    {
        return new Switch(element as IOSElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Switch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Switch"/>.
    /// </returns>
    public static implicit operator Switch(RemoteWebElement element)
    {
        return new Switch(element as IOSElement);
    }

    /// <summary>
    /// Toggles the switch on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOn()
    {
        if (this.IsOn)
        {
            return;
        }

        this.Click();
    }

    /// <summary>
    /// Toggles the switch off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOff()
    {
        if (!this.IsOn)
        {
            return;
        }

        this.Click();
    }
}