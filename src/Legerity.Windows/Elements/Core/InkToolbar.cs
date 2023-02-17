namespace Legerity.Windows.Elements.Core;

using System;
using Extensions;
using Legerity.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the core UWP InkToolbar control.
/// </summary>
public partial class InkToolbar : WindowsElementWrapper
{
    private readonly By ballpointPenFlyoutLocator = By.Name("Ballpoint pen flyout");

    private readonly By pencilFlyoutLocator = By.Name("Pencil flyout");

    private readonly By highlighterFlyoutLocator = By.Name("Highlighter flyout");

    /// <summary>
    /// Initializes a new instance of the <see cref="InkToolbar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public InkToolbar(WindowsElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the element associated with the ballpoint pen button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton BallpointPenButton =>
        this.FindElement(WindowsByExtras.AutomationId("InkToolbarBallpointPenButton"));

    /// <summary>
    /// Gets the currently selected ballpoint pen color.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedBallpointPenColor => this.BallpointPenButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the pencil button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton PencilButton =>
        this.FindElement(WindowsByExtras.AutomationId("InkToolbarPencilButton"));

    /// <summary>
    /// Gets the currently selected pencil color.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedPencilColor => this.PencilButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the highlighter button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RadioButton HighlighterButton =>
        this.FindElement(WindowsByExtras.AutomationId("InkToolbarHighlighterButton"));

    /// <summary>
    /// Gets the currently selected highlighter color.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string SelectedHighlighterColor => this.HighlighterButton.GetHelpText();

    /// <summary>
    /// Gets the element associated with the ruler button.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual ToggleButton RulerButton =>
        this.FindElement(WindowsByExtras.AutomationId("InkToolbarStencilButton"));

    /// <summary>
    /// Gets the element associated with the ballpoint pen flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the ballpoint pen button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarBallpointPenFlyout BallpointPenFlyout =>
        this.Driver.FindElement(this.ballpointPenFlyoutLocator);

    /// <summary>
    /// Gets the element associated with the pencil flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the pencil button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarPencilFlyout PencilFlyout => this.Driver.FindElement(this.pencilFlyoutLocator);

    /// <summary>
    /// Gets the element associated with the highlighter flyout.
    /// </summary>
    /// <remarks>
    /// This is only available when the highlighter button is selected.
    /// </remarks>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual InkToolbarHighlighterFlyout HighlighterFlyout =>
        this.Driver.FindElement(this.highlighterFlyoutLocator);

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InkToolbar"/>.
    /// </returns>
    public static implicit operator InkToolbar(WindowsElement element)
    {
        return new InkToolbar(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InkToolbar"/>.
    /// </returns>
    public static implicit operator InkToolbar(AppiumWebElement element)
    {
        return new InkToolbar(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="InkToolbar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="InkToolbar"/>.
    /// </returns>
    public static implicit operator InkToolbar(RemoteWebElement element)
    {
        return new InkToolbar(element as WindowsElement);
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
        if (!this.BallpointPenButton.IsSelected)
        {
            this.BallpointPenButton.Click();
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
        this.SelectBallpointPen();

        this.BallpointPenButton.Click();
        this.VerifyDriverElementShown(this.ballpointPenFlyoutLocator, TimeSpan.FromSeconds(2));
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
        this.OpenBallpointPenFlyout();
        this.BallpointPenFlyout.SetColor(color);
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
        this.OpenBallpointPenFlyout();
        this.BallpointPenFlyout.SetColorByPartialName(color);
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
        if (!this.PencilButton.IsSelected)
        {
            this.PencilButton.Click();
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
        this.SelectPencil();

        this.PencilButton.Click();
        this.VerifyDriverElementShown(this.pencilFlyoutLocator, TimeSpan.FromSeconds(2));
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
        this.OpenPencilFlyout();
        this.PencilFlyout.SetColor(color);
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
        this.OpenPencilFlyout();
        this.PencilFlyout.SetColorByPartialName(color);
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
        if (!this.HighlighterButton.IsSelected)
        {
            this.HighlighterButton.Click();
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
        this.SelectHighlighter();

        this.HighlighterButton.Click();
        this.VerifyDriverElementShown(this.highlighterFlyoutLocator, TimeSpan.FromSeconds(2));
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
        this.OpenHighlighterFlyout();
        this.HighlighterFlyout.SetColor(color);
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
        this.OpenHighlighterFlyout();
        this.HighlighterFlyout.SetColorByPartialName(color);
    }
}