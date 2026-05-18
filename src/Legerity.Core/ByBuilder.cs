// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Legerity;
/// <summary>
/// Defines a fluent builder for composing complex <see cref="By"/> locator queries.
/// <para>
/// Use <see cref="ByBuilder"/> to build element queries with same-element constraints (intersection)
/// and nested/scoped constraints (hierarchy) in a clear, composable way.
/// </para>
/// </summary>
/// <example>
/// <code>
/// // Same-element constraints (intersection)
/// By.TagName("button").That(by => by.HasText("Accept"))
/// By.TagName("div").That(by => by.HasAttribute("role", "dialog").HasAttribute("aria-modal", "true"))
///
/// // Nested scope - find children within matched parents
/// By.Id("nav").ThenFind(by => by.TagName("a").HasText("Home"))
///
/// // Complex composition
/// By.TagName("form").That(by => by.HasAttribute("id", "login"))
///     .ThenFind(by => by.TagName("input").HasAttribute("type", "email"))
/// </code>
/// </example>
public class ByBuilder : By
{
    private readonly List<By> constraints = new();
    private ByBuilder nestedBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="ByBuilder"/> class.
    /// </summary>
    internal ByBuilder()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ByBuilder"/> class with an initial locator.
    /// </summary>
    /// <param name="initial">The initial locator constraint.</param>
    internal ByBuilder(By initial)
    {
        this.constraints.Add(initial);
    }

    /// <summary>
    /// Adds a tag name constraint to the builder.
    /// </summary>
    /// <param name="tagName">The HTML/UI tag name to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder TagName(string tagName)
    {
        this.constraints.Add(By.TagName(tagName));
        return this;
    }

    /// <summary>
    /// Adds an ID constraint to the builder.
    /// </summary>
    /// <param name="id">The element ID to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder Id(string id)
    {
        this.constraints.Add(By.Id(id));
        return this;
    }

    /// <summary>
    /// Adds a class name constraint to the builder.
    /// </summary>
    /// <param name="className">The CSS class name to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder ClassName(string className)
    {
        this.constraints.Add(By.ClassName(className));
        return this;
    }

    /// <summary>
    /// Adds a CSS selector constraint to the builder.
    /// </summary>
    /// <param name="cssSelector">The CSS selector to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder CssSelector(string cssSelector)
    {
        this.constraints.Add(By.CssSelector(cssSelector));
        return this;
    }

    /// <summary>
    /// Adds an XPath constraint to the builder.
    /// </summary>
    /// <param name="xpath">The XPath expression to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder XPath(string xpath)
    {
        this.constraints.Add(By.XPath(xpath));
        return this;
    }

    /// <summary>
    /// Adds a name attribute constraint to the builder.
    /// </summary>
    /// <param name="name">The name attribute value to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public new ByBuilder Name(string name)
    {
        this.constraints.Add(By.Name(name));
        return this;
    }

    /// <summary>
    /// Adds an exact text content constraint to the builder.
    /// </summary>
    /// <param name="text">The exact text to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public ByBuilder HasText(string text)
    {
        this.constraints.Add(ByExtras.Text(text));
        return this;
    }

    /// <summary>
    /// Adds a partial text content constraint to the builder.
    /// </summary>
    /// <param name="text">The partial text to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public ByBuilder HasPartialText(string text)
    {
        this.constraints.Add(ByExtras.PartialText(text));
        return this;
    }

    /// <summary>
    /// Adds an exact attribute value constraint to the builder.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <param name="attributeValue">The exact value to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public ByBuilder HasAttribute(string attributeName, string attributeValue)
    {
        this.constraints.Add(By.XPath($".//*[@{attributeName}='{attributeValue}']"));
        return this;
    }

    /// <summary>
    /// Adds a partial attribute value constraint to the builder.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <param name="partialValue">The partial value to match.</param>
    /// <returns>This builder instance for chaining.</returns>
    public ByBuilder HasPartialAttribute(string attributeName, string partialValue)
    {
        this.constraints.Add(By.XPath($".//*[contains(@{attributeName},'{partialValue}')]"));
        return this;
    }

    /// <summary>
    /// Adds an arbitrary <see cref="By"/> constraint to the builder.
    /// </summary>
    /// <param name="locator">The locator constraint to add.</param>
    /// <returns>This builder instance for chaining.</returns>
    public ByBuilder Matching(By locator)
    {
        this.constraints.Add(locator);
        return this;
    }

    /// <summary>Finds the first element matching the composed criteria.</summary>
    /// <param name="context">An <see cref="ISearchContext"/> to search within.</param>
    /// <returns>The first matching <see cref="IWebElement"/>.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the criteria.</exception>
    public override IWebElement FindElement(ISearchContext context)
    {
        ReadOnlyCollection<IWebElement> elements = this.FindElements(context);
        if (elements.Count == 0)
        {
            throw new NoSuchElementException($"No element could be located using locator: {this}");
        }

        return elements[0];
    }

    /// <summary>Finds all elements matching the composed criteria.</summary>
    /// <param name="context">An <see cref="ISearchContext"/> to search within.</param>
    /// <returns>A collection of matching elements, or empty if none match.</returns>
    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
    {
        By resolved = this.Build();
        ReadOnlyCollection<IWebElement> results = resolved.FindElements(context);

        if (this.nestedBuilder == null)
        {
            return results;
        }

        By nestedLocator = this.nestedBuilder.Build();
        var nestedResults = new List<IWebElement>();
        foreach (IWebElement parent in results)
        {
            nestedResults.AddRange(nestedLocator.FindElements(parent));
        }

        return nestedResults.AsReadOnly();
    }

    internal ByBuilder SetNested(ByBuilder nested)
    {
        if (this.nestedBuilder != null)
        {
            this.nestedBuilder.SetNested(nested);
        }
        else
        {
            this.nestedBuilder = nested;
        }

        return this;
    }

    private By Build()
    {
        return this.constraints.Count switch
        {
            0 => By.XPath(".//*"),
            1 => this.constraints[0],
            _ => new ByAll(this.constraints.ToArray())
        };
    }
}