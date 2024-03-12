namespace Legerity.Android.Elements.Core;

/// <summary>
/// Defines a <see cref="WebElement"/> wrapper for the core Android Spinner control.
/// </summary>
public class Spinner : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Spinner"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/> reference.
    /// </param>
    public Spinner(WebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedItem => GetSelectedItem();

    /// <summary>
    /// Allows conversion of a <see cref="WebElement"/> to the <see cref="Spinner"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="WebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Spinner"/>.
    /// </returns>
    public static implicit operator Spinner(WebElement element)
    {
        return new Spinner(element);
    }
    
    /// <summary>
    /// Selects an item in the combo-box with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to select.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SelectItem(string name)
    {
        Click();

        var locator =
            new ByAndroidUIAutomator(
                $"new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().text(\"{name}\"));");
        WebElement item = Driver.FindElement(locator);

        item.Click();
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified partial item name.
    /// </summary>
    /// <param name="partialName">The partial name match for the item to select.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SelectItemByPartialName(string partialName)
    {
        Click();

        var locator =
            new ByAndroidUIAutomator(
                $"new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().textContains(\"{partialName}\"));");
        WebElement item = Driver.FindElement(locator);

        item.Click();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private string GetSelectedItem()
    {
        TextView textElement = FindElement(By.ClassName("android.widget.TextView"));
        return textElement.Text;
    }
}