namespace Legerity.Windows.Elements.WinUI;

using Legerity.Windows.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the WinUI InfoBar control.
/// </summary>
public class InfoBar : WindowsElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfoBar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public InfoBar(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the title of the info bar.
    /// </summary>
    public virtual string Title => this.TitleTextBlock.Text;

    /// <summary>
    /// Gets the message of the info bar.
    /// </summary>
    public virtual string Message => this.MessageTextBlock.Text;

    /// <summary>
    /// Gets a value indicating whether the info bar is open.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsOpen => !bool.Parse(this.GetAttribute("IsOffscreen"));

    /// <summary>
    /// Gets the element associated with the title <see cref="TextBlock"/>.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBlock TitleTextBlock => this.FindElement(WindowsByExtras.AutomationId("Title"));

    /// <summary>
    /// Gets the element associated with the message <see cref="TextBlock"/>.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextBlock MessageTextBlock => this.FindElement(WindowsByExtras.AutomationId("Message"));

    /// <summary>
    /// Gets the element associated with the close <see cref="Button"/>.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button CloseButton => this.FindElement(WindowsByExtras.AutomationId("CloseButton"));

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InfoBar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InfoBar"/>.
    /// </returns>
    public static implicit operator InfoBar(WebElement element)
    {
        return new InfoBar(element);
    }
    
    /// <summary>
    /// Closes the info bar.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void Close()
    {
        this.CloseButton.Click();
    }
}