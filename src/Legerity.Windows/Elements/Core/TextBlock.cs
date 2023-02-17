namespace Legerity.Windows.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP TextBlock control.
/// </summary>
public class TextBlock : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBlock"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public TextBlock(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text block.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.Element.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="TextBlock"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBlock"/>.
    /// </returns>
    public static implicit operator TextBlock(WindowsElement element)
    {
        return new TextBlock(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TextBlock"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBlock"/>.
    /// </returns>
    public static implicit operator TextBlock(AppiumWebElement element)
    {
        return new TextBlock(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TextBlock"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBlock"/>.
    /// </returns>
    public static implicit operator TextBlock(RemoteWebElement element)
    {
        return new TextBlock(element as WindowsElement);
    }
}