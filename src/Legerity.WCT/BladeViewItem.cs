namespace Legerity.Windows.Elements.WCT;

using System;
using Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit BladeViewItem control.
/// </summary>
public class BladeViewItem : WindowsElementWrapper
{
    private readonly WeakReference parentBladeViewReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public BladeViewItem(WebElement element)
        : this(null, element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
    /// </summary>
    /// <param name="parentBladeView">
    /// The parent <see cref="BladeView"/>.
    /// </param>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public BladeViewItem(
        BladeView parentBladeView,
        WebElement element)
        : base(element)
    {
        if (parentBladeView != null)
        {
            parentBladeViewReference = new WeakReference(parentBladeView);
        }
    }

    /// <summary>Gets the original parent <see cref="BladeView"/> reference object.</summary>
    public BladeView ParentMenuBar =>
        parentBladeViewReference is { IsAlive: true }
            ? parentBladeViewReference.Target as BladeView
            : null;

    /// <summary>
    /// Gets the <see cref="Button"/> element associated with the blade enlarge option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button EnlargeButton => FindElement(WindowsByExtras.AutomationId("EnlargeButton"));

    /// <summary>
    /// Gets the <see cref="Button"/> element associated with the blade close option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button CloseButton => FindElement(WindowsByExtras.AutomationId("CloseButton"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="BladeViewItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="BladeViewItem"/>.
    /// </returns>
    public static implicit operator BladeViewItem(WebElement element)
    {
        return new BladeViewItem(element);
    }

    /// <summary>
    /// Closes the blade item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Close()
    {
        CloseButton.Click();
    }
}