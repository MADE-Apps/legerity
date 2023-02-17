namespace Legerity.Android.Elements.Core;

using Legerity.Android.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android View base control.
/// </summary>
public class View : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/> reference.
    /// </param>
    public View(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="View"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="View"/>.
    /// </returns>
    public static implicit operator View(AndroidElement element)
    {
        return new View(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Button"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Button"/>.
    /// </returns>
    public static implicit operator View(AppiumWebElement element)
    {
        return new View(element as AndroidElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="View"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="View"/>.
    /// </returns>
    public static implicit operator View(RemoteWebElement element)
    {
        return new View(element as AndroidElement);
    }
}