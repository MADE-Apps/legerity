namespace Legerity.IOS.Elements.Core;

using System;
using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IOSElement"/> wrapper for the core iOS Slider control.
/// </summary>
public class Slider : IOSElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Slider"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/> reference.
    /// </param>
    public Slider(IOSElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the slider as a percentage between 0 and 100.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual double Value => double.Parse(this.GetValue().TrimEnd('%'));

    /// <summary>
    /// Gets a value indicating whether the control is in a readonly state.
    /// </summary>
    public virtual bool IsReadonly => !this.IsEnabled;

    /// <summary>
    /// Allows conversion of a <see cref="IOSElement"/> to the <see cref="Slider"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IOSElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Slider"/>.
    /// </returns>
    public static implicit operator Slider(IOSElement element)
    {
        return new Slider(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Slider"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Slider"/>.
    /// </returns>
    public static implicit operator Slider(AppiumWebElement element)
    {
        return new Slider(element as IOSElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Slider"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Slider"/>.
    /// </returns>
    public static implicit operator Slider(RemoteWebElement element)
    {
        return new Slider(element as IOSElement);
    }

    /// <summary>
    /// Sets the value of the slider.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void SetValue(double value)
    {
        this.Click();

        double currentValue = this.Value;
        while (Math.Abs(currentValue - value) > double.Epsilon)
        {
            this.Element.SendKeys(currentValue < value ? Keys.ArrowRight : Keys.ArrowLeft);
            currentValue = this.Value;
        }
    }
}