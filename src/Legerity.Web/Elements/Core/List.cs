// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Legerity.Web.Elements.Core;
/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web ol or ul control.
/// </summary>
public class List : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="List"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public List(IWebElement element)
        : this(element as WebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="List"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public List(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of items associated with the list.
    /// </summary>
    public virtual ReadOnlyCollection<IWebElement> Items => this.Element.FindElements(WebByExtras.ListItem());

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="List"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public static implicit operator List(WebElement element)
    {
        return new List(element);
    }
}