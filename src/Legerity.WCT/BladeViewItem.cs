namespace Legerity.Windows.Elements.WCT;

using System;
using Legerity.Windows.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit BladeViewItem control.
/// </summary>
public class BladeViewItem : WindowsElementWrapper
{
    private readonly WeakReference parentBladeViewReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public BladeViewItem(WindowsElement element)
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
    /// The <see cref="WindowsElement"/> reference.
    /// </param>
    public BladeViewItem(
        BladeView parentBladeView,
        WindowsElement element)
        : base(element)
    {
        if (parentBladeView != null)
        {
            this.parentBladeViewReference = new WeakReference(parentBladeView);
        }
    }

    /// <summary>Gets the original parent <see cref="BladeView"/> reference object.</summary>
    public BladeView ParentMenuBar =>
        this.parentBladeViewReference is { IsAlive: true }
            ? this.parentBladeViewReference.Target as BladeView
            : null;

    /// <summary>
    /// Gets the <see cref="Button"/> element associated with the blade enlarge option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button EnlargeButton => this.FindElement(WindowsByExtras.AutomationId("EnlargeButton"));

    /// <summary>
    /// Gets the <see cref="Button"/> element associated with the blade close option.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button CloseButton => this.FindElement(WindowsByExtras.AutomationId("CloseButton"));

    /// <summary>
    /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="BladeViewItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WindowsElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="BladeViewItem"/>.
    /// </returns>
    public static implicit operator BladeViewItem(WindowsElement element)
    {
        return new BladeViewItem(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="BladeViewItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="BladeViewItem"/>.
    /// </returns>
    public static implicit operator BladeViewItem(AppiumWebElement element)
    {
        return new BladeViewItem(element as WindowsElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="BladeViewItem"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="BladeViewItem"/>.
    /// </returns>
    public static implicit operator BladeViewItem(RemoteWebElement element)
    {
        return new BladeViewItem(element as WindowsElement);
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
        this.CloseButton.Click();
    }
}