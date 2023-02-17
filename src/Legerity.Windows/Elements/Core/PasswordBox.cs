namespace Legerity.Windows.Elements.Core;

using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP PasswordBox control.
/// </summary>
public class PasswordBox : TextBox
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public PasswordBox(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the reveal password button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton RevealButton => this.FindElement(WindowsByExtras.AutomationId("RevealButton"));

    /// <summary>
    /// Gets the password text value in the password box.
    /// </summary>
    /// <remarks>
    /// To get the password text value, the password box must be revealed using the <see cref="RevealPassword"/> method. Otherwise, the text value will be hidden characters.
    /// </remarks>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Password => this.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="PasswordBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="PasswordBox"/>.
    /// </returns>
    public static implicit operator PasswordBox(WindowsElement element)
    {
        return new PasswordBox(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="PasswordBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="PasswordBox"/>.
    /// </returns>
    public static implicit operator PasswordBox(AppiumWebElement element)
    {
        return new PasswordBox(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="PasswordBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="PasswordBox"/>.
    /// </returns>
    public static implicit operator PasswordBox(RemoteWebElement element)
    {
        return new PasswordBox(element as WindowsElement);
    }

    /// <summary>
    /// Reveals the password text in the password box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void RevealPassword()
    {
        this.RevealButton.ClickAndHold();
    }

    /// <summary>
    /// Hides the password text in the password box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void HidePassword()
    {
        this.RevealButton.ReleaseHold();
    }
}