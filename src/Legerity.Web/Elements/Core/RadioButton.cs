namespace Legerity.Web.Elements.Core;

using Legerity.Web.Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input radio control.
/// </summary>
public class RadioButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RadioButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public RadioButton(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RadioButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public RadioButton(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the radio button is selected.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsSelected => Element.Selected;

    /// <summary>
    /// Gets the name of the group for the radio button.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Group => this.GetName();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="RadioButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="RadioButton"/>.
    /// </returns>
    public static implicit operator RadioButton(WebElement element)
    {
        return new RadioButton(element);
    }
}