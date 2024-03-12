namespace Legerity.Windows.Elements.WCT;

using System.Linq;
using Extensions;
using Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the Windows Community Toolkit InAppNotification control.
/// </summary>
public class InAppNotification : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InAppNotification"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public InAppNotification(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the dismiss button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button DismissButton => FindElement(WindowsByExtras.AutomationId("PART_DismissButton"));

    /// <summary>
    /// Gets the message displayed.
    /// <para>
    /// Note, this only works if the Content is based on a <see cref="string"/> or if the ContentTemplate includes a TextBlock element with the message.
    /// </para>
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Message => Element.FindElementsByClassName("TextBlock").FirstOrDefault()?.Text;

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InAppNotification"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InAppNotification"/>.
    /// </returns>
    public static implicit operator InAppNotification(WebElement element)
    {
        return new InAppNotification(element);
    }
    
    /// <summary>
    /// Dismissed the in-app notification.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Dismiss()
    {
        DismissButton.Click();
    }
}