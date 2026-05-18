// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Extensions;
using OpenQA.Selenium;

namespace Legerity.Web.Elements.Core;
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
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateInput"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public DateInput(WebElement element)
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
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="DateInput"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="DateInput"/>.
    /// </returns>
    public static implicit operator DateInput(WebElement element)
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
        ((IJavaScriptExecutor)this.ElementDriver).ExecuteScript(
            "arguments[0].setAttribute('value', arguments[1])",
            this.Element,
            date.ToString("yyyy-MM-dd"));
    }

    private DateTime? GetSelectedDate()
    {
        var value = this.Value;
        return string.IsNullOrEmpty(value) ? default :
            DateTime.TryParse(value, out DateTime date) ? date : default(DateTime?);
    }
}