namespace Legerity.Web.Elements.Core;

using Legerity.Web.Elements;
using Legerity.Web.Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Option control.
/// </summary>
public class Option : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Option"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public Option(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Option"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Option(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the option.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => this.GetValue();

    /// <summary>
    /// Gets the display value of the option.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string DisplayValue => Element.Text;

    /// <summary>
    /// Gets a value indicating whether the option is selected.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsSelected => Element.Selected;

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Option"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Option"/>.
    /// </returns>
    public static implicit operator Option(WebElement element)
    {
        return new Option(element);
    }

    /// <summary>
    /// Selects the option.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void Select()
    {
        Click();
    }
}