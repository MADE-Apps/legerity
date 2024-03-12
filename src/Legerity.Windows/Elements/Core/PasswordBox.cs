namespace Legerity.Windows.Elements.Core;

using Legerity.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP PasswordBox control.
/// </summary>
public class PasswordBox : TextBox
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public PasswordBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the reveal password button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton RevealButton => FindElement(WindowsByExtras.AutomationId("RevealButton"));

    /// <summary>
    /// Gets the password text value in the password box.
    /// </summary>
    /// <remarks>
    /// To get the password text value, the password box must be revealed using the <see cref="RevealPassword"/> method. Otherwise, the text value will be hidden characters.
    /// </remarks>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Password => Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="PasswordBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="PasswordBox"/>.
    /// </returns>
    public static implicit operator PasswordBox(WebElement element)
    {
        return new PasswordBox(element);
    }
    
    /// <summary>
    /// Reveals the password text in the password box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void RevealPassword()
    {
        RevealButton.ClickAndHold();
    }

    /// <summary>
    /// Hides the password text in the password box.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void HidePassword()
    {
        RevealButton.ReleaseHold();
    }
}