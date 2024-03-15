namespace Legerity.Windows.Elements.Core;

using System;
using Extensions;
using Legerity.Exceptions;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core UWP InkToolbar control.
/// </summary>
public partial class InkToolbar : WindowsElementWrapper
{
    private readonly By _ballpointPenFlyoutLocator = By.Name("Ballpoint pen flyout");

    private readonly By _pencilFlyoutLocator = By.Name("Pencil flyout");

    private readonly By _highlighterFlyoutLocator = By.Name("Highlighter flyout");

    /// <summary>
    /// Initializes a new instance of the <see cref="InkToolbar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public InkToolbar(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the ballpoint pen button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton BallpointPenButton =>
        FindElement(WindowsByExtras.AutomationId("InkToolbarBallpointPenButton"));

    /// <summary>
    /// Gets the currently selected ballpoint pen color.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedBallpointPenColor => BallpointPenButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the pencil button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton PencilButton =>
        FindElement(WindowsByExtras.AutomationId("InkToolbarPencilButton"));

    /// <summary>
    /// Gets the currently selected pencil color.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedPencilColor => PencilButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the highlighter button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton HighlighterButton =>
        FindElement(WindowsByExtras.AutomationId("InkToolbarHighlighterButton"));

    /// <summary>
    /// Gets the currently selected highlighter color.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string SelectedHighlighterColor => HighlighterButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the ruler button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton RulerButton =>
        FindElement(WindowsByExtras.AutomationId("InkToolbarStencilButton"));

    /// <summary>
    /// Gets the element associated with the ballpoint pen flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the ballpoint pen button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarBallpointPenFlyout BallpointPenFlyout =>
        Driver.FindElement(_ballpointPenFlyoutLocator);

    /// <summary>
    /// Gets the element associated with the pencil flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the pencil button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarPencilFlyout PencilFlyout => Driver.FindElement(_pencilFlyoutLocator);

    /// <summary>
    /// Gets the element associated with the highlighter flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the highlighter button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarHighlighterFlyout HighlighterFlyout =>
        Driver.FindElement(_highlighterFlyoutLocator);

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InkToolbar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InkToolbar"/>.
    /// </returns>
    public static implicit operator InkToolbar(WebElement element)
    {
        return new InkToolbar(element);
    }
    
    /// <summary>
    /// Selects the ballpoint pen option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public virtual void SelectBallpointPen()
    {
        if (!BallpointPenButton.IsSelected)
        {
            BallpointPenButton.Click();
        }
    }

    /// <summary>
    /// Opens the ballpoint pen flyout.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    public virtual void OpenBallpointPenFlyout()
    {
        SelectBallpointPen();

        BallpointPenButton.Click();
        VerifyDriverElementShown(_ballpointPenFlyoutLocator, TimeSpan.FromSeconds(2));
    }

    /// <summary>
    /// Sets the toolbar to the ballpoint pen with the given color.
    /// </summary>
    /// <param name="color">
    /// The color to set.
    /// </param>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetBallpointPenColor(string color)
    {
        OpenBallpointPenFlyout();
        BallpointPenFlyout.SetColor(color);
    }

    /// <summary>
    /// Sets the toolbar to the ballpoint pen with the given partial color name.
    /// </summary>
    /// <param name="color">
    /// The partial color name to set.
    /// </param>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetBallpointPenColorByPartialName(string color)
    {
        OpenBallpointPenFlyout();
        BallpointPenFlyout.SetColorByPartialName(color);
    }

    /// <summary>
    /// Selects the pencil option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectPencil()
    {
        if (!PencilButton.IsSelected)
        {
            PencilButton.Click();
        }
    }

    /// <summary>
    /// Opens the pencil flyout.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    public virtual void OpenPencilFlyout()
    {
        SelectPencil();

        PencilButton.Click();
        VerifyDriverElementShown(_pencilFlyoutLocator, TimeSpan.FromSeconds(2));
    }

    /// <summary>
    /// Sets the toolbar to the pencil with the given color.
    /// </summary>
    /// <param name="color">
    /// The color to set.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetPencilColor(string color)
    {
        OpenPencilFlyout();
        PencilFlyout.SetColor(color);
    }

    /// <summary>
    /// Sets the toolbar to the pencil with the given partial color name.
    /// </summary>
    /// <param name="color">
    /// The partial color name to set.
    /// </param>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetPencilColorByPartialName(string color)
    {
        OpenPencilFlyout();
        PencilFlyout.SetColorByPartialName(color);
    }

    /// <summary>
    /// Selects the highlighter option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SelectHighlighter()
    {
        if (!HighlighterButton.IsSelected)
        {
            HighlighterButton.Click();
        }
    }

    /// <summary>
    /// Opens the pencil flyout.
    /// </summary>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    public virtual void OpenHighlighterFlyout()
    {
        SelectHighlighter();

        HighlighterButton.Click();
        VerifyDriverElementShown(_highlighterFlyoutLocator, TimeSpan.FromSeconds(2));
    }

    /// <summary>
    /// Sets the toolbar to the highlighter with the given color.
    /// </summary>
    /// <param name="color">
    /// The color to set.
    /// </param>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetHighlighterColor(string color)
    {
        OpenHighlighterFlyout();
        HighlighterFlyout.SetColor(color);
    }

    /// <summary>
    /// Sets the toolbar to the highlighter with the given color.
    /// </summary>
    /// <param name="color">
    /// The color to set.
    /// </param>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SetHighlighterColorByPartialName(string color)
    {
        OpenHighlighterFlyout();
        HighlighterFlyout.SetColorByPartialName(color);
    }
}
