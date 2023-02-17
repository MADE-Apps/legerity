namespace Legerity.Android.Elements.Core;

using Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android CheckBox control.
/// </summary>
public class CheckBox : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/> reference.
    /// </param>
    public CheckBox(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the check box is in the checked state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsChecked => this.GetCheckedState();

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(AndroidElement element)
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
        return new CheckBox(element as AndroidElement);
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
        return new CheckBox(element as AndroidElement);
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