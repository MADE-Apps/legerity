namespace Legerity.Windows.Elements.Core;

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP Hub control.
/// </summary>
public class Hub : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hub"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public Hub(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the hub.
    /// </summary>
    public virtual ReadOnlyCollection<AppiumWebElement> Items => this.Element.FindElements(By.ClassName("HubSection"));

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="Hub"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Hub"/>.
    /// </returns>
    public static implicit operator Hub(WindowsElement element)
    {
        return new Hub(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Hub"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Hub"/>.
    /// </returns>
    public static implicit operator Hub(AppiumWebElement element)
    {
        return new Hub(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Hub"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Hub"/>.
    /// </returns>
    public static implicit operator Hub(RemoteWebElement element)
    {
        return new Hub(element as WindowsElement);
    }
}