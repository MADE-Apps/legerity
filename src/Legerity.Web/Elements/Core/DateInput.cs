namespace Legerity.Web.Elements.Core;

using System;
using Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Input date control.
/// </summary>
public class DateInput : TextInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public DateInput(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public DateInput(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the value of the date picker.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Value => this.GetValue();

    /// <summary>
    /// Gets the value of the date picker as a <see cref="DateTime"/>.
    /// </summary>
    public virtual DateTime? SelectedDate => this.GetSelectedDate();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="DateInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DateInput"/>.
    /// </returns>
    public static implicit operator DateInput(RemoteWebElement element)
    {
        return new DateInput(element);
    }

    /// <summary>
    /// Sets the date to the specified date.
    /// </summary>
    /// <param name="date">The date to set.</param>
    /// <exception cref="WebDriverException">Thrown when this <see cref="IWebDriver" /> instance does not implement <see cref="IJavaScriptExecutor" />.</exception>
    public virtual void SetDate(DateTime date)
    {
        this.ElementDriver.ExecuteJavaScript(
            "arguments[0].setAttribute('value', arguments[1])",
            this.Element,
            date.ToString("yyyy-MM-dd"));
    }

    private DateTime? GetSelectedDate()
    {
        string value = this.Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out DateTime date) ? date : default(DateTime?);
    }
}