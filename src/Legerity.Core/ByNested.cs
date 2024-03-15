namespace Legerity;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/// <summary>
/// Defines a <see cref="By"/> locator that can be used to find elements using a sequence of locators that are continuously nested until the final locator is run.
/// </summary>
/// <example>
/// The following example shows how to find all elements that match inputs that appear under divs, followed by forms.
/// <code>
/// driver.FindElements(new ByNested(By.TagName("div"), By.TagName("form"), By.TagName("input")));
/// </code>
/// </example>
public class ByNested : By
{
    private readonly By[] _locators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ByNested"/> class.
    /// </summary>
    /// <param name="locators">The locators in nesting sequence to find references of.</param>
    public ByNested(params By[] locators)
    {
        _locators = locators;
    }

    /// <summary>Finds the first element matching the criteria.</summary>
    /// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
    /// <returns>The first matching <see cref="T:OpenQA.Selenium.IWebElement" /> on the current context.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public override IWebElement FindElement(ISearchContext context)
    {
        var elements = FindElements(context);
        if (elements.Count == 0)
        {
            throw new NoSuchElementException($"No element could be located using locator: {this}");
        }

        return elements[0];
    }

    /// <summary>Finds all elements matching the criteria.</summary>
    /// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
    /// <returns>A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> of all <see cref="T:OpenQA.Selenium.IWebElement">WebElements</see>
    /// matching the current criteria, or an empty list if nothing matches.</returns>
    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
    {
        if (_locators.Length == 0)
        {
            return new List<IWebElement>().AsReadOnly();
        }

        IEnumerable<IWebElement> elements = null;
        foreach (var locator in _locators)
        {
            var nestedElements = new List<IWebElement>();

            if (elements == null)
            {
                nestedElements.AddRange(locator.FindElements(context));
            }
            else
            {
                foreach (var element in elements)
                {
                    nestedElements.AddRange(element.FindElements(locator));
                }
            }

            elements = nestedElements;
        }

        return (elements ?? new List<IWebElement>()).ToList().AsReadOnly();
    }
}
