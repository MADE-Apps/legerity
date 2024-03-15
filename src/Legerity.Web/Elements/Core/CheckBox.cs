namespace Legerity.Web.Elements.Core;

using Elements;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input checkbox control.
/// </summary>
public class CheckBox : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public CheckBox(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public CheckBox(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the check box is in the checked state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsChecked => Element.Selected;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(WebElement element)
    {
        return new CheckBox(element);
    }

    /// <summary>
    /// Checks the check box on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOn()
    {
        if (IsChecked)
        {
            return;
        }

        Click();
    }

    /// <summary>
    /// Checks the check box off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOff()
    {
        if (!IsChecked)
        {
            return;
        }

        Click();
    }
}
