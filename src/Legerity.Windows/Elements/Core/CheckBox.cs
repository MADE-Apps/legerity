namespace Legerity.Windows.Elements.Core;

using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP CheckBox control.
/// </summary>
public class CheckBox : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public CheckBox(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the check box is in the checked state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsChecked => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Gets a value indicating whether the check box is in the indeterminate state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsIndeterminate => this.GetToggleState() == ToggleState.Indeterminate;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(WindowsElement element)
    {
        return new CheckBox(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(AppiumWebElement element)
    {
        return new CheckBox(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(RemoteWebElement element)
    {
        return new CheckBox(element as WindowsElement);
    }

    /// <summary>
    /// Checks the check box on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOn()
    {
        if (this.IsChecked)
        {
            return;
        }

        this.Click();
    }

    /// <summary>
    /// Checks the check box off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOff()
    {
        if (!this.IsChecked)
        {
            return;
        }

        this.Click();
    }
}