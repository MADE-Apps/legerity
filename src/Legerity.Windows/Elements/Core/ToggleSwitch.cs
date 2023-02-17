namespace Legerity.Windows.Elements.Core;

using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP ToggleSwitch control.
/// </summary>
public class ToggleSwitch : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToggleSwitch"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public ToggleSwitch(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle switch is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOn => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="ToggleSwitch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleSwitch"/>.
    /// </returns>
    public static implicit operator ToggleSwitch(WindowsElement element)
    {
        return new ToggleSwitch(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="ToggleSwitch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleSwitch"/>.
    /// </returns>
    public static implicit operator ToggleSwitch(AppiumWebElement element)
    {
        return new ToggleSwitch(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ToggleSwitch"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ToggleSwitch"/>.
    /// </returns>
    public static implicit operator ToggleSwitch(RemoteWebElement element)
    {
        return new ToggleSwitch(element as WindowsElement);
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