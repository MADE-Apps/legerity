namespace Legerity.Web.Elements.Core;

using System.Collections.Generic;
using System.Linq;
using Legerity.Extensions;
using Legerity.Web.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Table Row (tr) control.
/// </summary>
public class TableRow : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TableRow"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public TableRow(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TableRow"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public TableRow(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets all of the values for each column in the row.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual IEnumerable<string> Values => this.GetAllChildElements().Select(x => x.GetInnerHtml());
}