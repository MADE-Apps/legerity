namespace Legerity.Windows.Elements.WCT;

using System.Collections.Generic;
using System.Linq;
using Legerity.Windows.Extensions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit BladeView control.
/// </summary>
public class BladeView : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BladeView"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public BladeView(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the UI components associated with the child blades.
    /// </summary>
    public virtual IEnumerable<BladeViewItem> Blades =>
        Element.FindElements(By.ClassName("BladeItem"))
            .Select(element => new BladeViewItem(this, element as WebElement));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="BladeView"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="BladeView"/>.
    /// </returns>
    public static implicit operator BladeView(WebElement element)
    {
        return new BladeView(element);
    }

    /// <summary>
    /// Retrieves a <see cref="BladeViewItem"/> by the given name.
    /// </summary>
    /// <param name="name">The name of the blade to retrieve.</param>
    /// <returns>A <see cref="BladeViewItem"/> instance if found; otherwise, null.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual BladeViewItem GetBlade(string name)
    {
        return Blades.FirstOrDefault(element => element.Element.VerifyNameOrAutomationIdEquals(name));
    }

    /// <summary>
    /// Retrieves a <see cref="BladeViewItem"/> by the given partial name.
    /// </summary>
    /// <param name="partialName">The partial name of the blade to retrieve.</param>
    /// <returns>A <see cref="BladeViewItem"/> instance if found; otherwise, null.</returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual BladeViewItem GetBladeByPartialName(string partialName)
    {
        return Blades.FirstOrDefault(element => element.Element.VerifyNameOrAutomationIdContains(partialName));
    }

    /// <summary>
    /// Closes an open blade by name.
    /// </summary>
    /// <param name="name">The name of the blade to close.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void CloseBlade(string name)
    {
        BladeViewItem blade = GetBlade(name);
        blade.Close();
    }

    /// <summary>
    /// Closes an open blade by partial name.
    /// </summary>
    /// <param name="partialName">The partial name of the blade to close.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void CloseBladeByPartialName(string partialName)
    {
        BladeViewItem blade = GetBladeByPartialName(partialName);
        blade.Close();
    }
}