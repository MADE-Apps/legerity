namespace Legerity.Android.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android TextView control.
/// </summary>
public class TextView : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/> reference.
    /// </param>
    public TextView(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text view.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.Element.Text;

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="TextView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextView"/>.
    /// </returns>
    public static implicit operator TextView(AndroidElement element)
    {
        return new TextView(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextView"/>.
    /// </returns>
    public static implicit operator TextView(AppiumWebElement element)
    {
        return new TextView(element as AndroidElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TextView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextView"/>.
    /// </returns>
    public static implicit operator TextView(RemoteWebElement element)
    {
        return new TextView(element as AndroidElement);
    }
}