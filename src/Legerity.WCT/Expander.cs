namespace Legerity.Windows.Elements.WCT;

using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit Expander control.
/// </summary>
public class Expander : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Expander"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public Expander(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the expander has the content expanded (visible).
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsExpanded => this.GetToggleState() == ToggleState.Checked;

    /// <summary>
    /// Gets the <see cref="ToggleButton"/> associated with the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton ToggleButton => this.FindElement(WindowsByExtras.AutomationId("PART_ExpanderToggleButton"));

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Expander"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Expander"/>.
    /// </returns>
    public static implicit operator Expander(WindowsElement element)
    {
        return new Expander(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Expander"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Expander"/>.
    /// </returns>
    public static implicit operator Expander(AppiumWebElement element)
    {
        return new Expander(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Expander"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Expander"/>.
    /// </returns>
    public static implicit operator Expander(RemoteWebElement element)
    {
        return new Expander(element as WindowsElement);
    }

    /// <summary>
    /// Expands the content of the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Expand()
    {
        if (this.IsExpanded)
        {
            return;
        }

        this.ToggleButton.Click();
    }

    /// <summary>
    /// Collapses the content of the expander.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Collapse()
    {
        if (!this.IsExpanded)
        {
            return;
        }

        this.ToggleButton.Click();
    }
}