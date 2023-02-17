namespace Legerity.Android.Elements.Core;

using Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android ToggleButton control.
/// </summary>
public class ToggleButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToggleButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/> reference.
    /// </param>
    public ToggleButton(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle button is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetCheckedState();

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="ToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleButton"/>.
    /// </returns>
    public static implicit operator ToggleButton(AndroidElement element)
    {
        return new ToggleButton(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleButton"/>.
    /// </returns>
    public static implicit operator ToggleButton(AppiumWebElement element)
    {
        return new ToggleButton(element as AndroidElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleButton"/>.
    /// </returns>
    public static implicit operator ToggleButton(RemoteWebElement element)
    {
        return new ToggleButton(element as AndroidElement);
    }

    /// <summary>
    /// Toggles the button on.
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
    /// Toggles the button off.
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