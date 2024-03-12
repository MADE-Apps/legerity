namespace Legerity;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/// <summary>
/// Defines a <see cref="By"/> locator that can be used to find all elements that match all locators in sequence.
/// </summary>
/// <remarks>
/// The order of the locators is run in sequence which means that results of <see cref="FindElements"/> may not be in order of their location on screen.
/// </remarks>
/// <example>
/// The following example shows how to find all elements that match the class name and then the text. All locators must match for the element to be returned.
/// <code>
/// driver.FindElement(new ByAll(By.ClassName("my-class"), By.Text("My Text")));
/// </code>
/// </example>
public class ByAll : By
{
    private readonly By[] locators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ByAll"/> class.
    /// </summary>
    /// <param name="locators">The locators to find all references of.</param>
    public ByAll(params By[] locators)
    {
        this.locators = locators;
    }

    /// <summary>Finds the first element matching the criteria.</summary>
    /// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
    /// <returns>The first matching <see cref="T:OpenQA.Selenium.IWebElement" /> on the current context.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public override IWebElement FindElement(ISearchContext context)
    {
        ReadOnlyCollection<IWebElement> elements = FindElements(context);
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
        if (locators.Length == 0)
        {
            return new List<IWebElement>().AsReadOnly();
        }

        IEnumerable<IWebElement> elements = null;
        foreach (By locator in locators)
        {
            ReadOnlyCollection<IWebElement> foundElements = locator.FindElements(context);
            if (foundElements.Count == 0)
            {
                return new List<IWebElement>().AsReadOnly();
            }

            elements = elements == null ? foundElements : elements.Intersect(locator.FindElements(context));
        }

        return (elements ?? new List<IWebElement>()).ToList().AsReadOnly();
    }
}