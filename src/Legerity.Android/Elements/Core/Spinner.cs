namespace Legerity.Android.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="AndroidElement"/> wrapper for the core Android Spinner control.
/// </summary>
public class Spinner : AndroidElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Spinner"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/> reference.
    /// </param>
    public Spinner(AndroidElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedItem => this.GetSelectedItem();

    /// <summary>
    /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="Spinner"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AndroidElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Spinner"/>.
    /// </returns>
    public static implicit operator Spinner(AndroidElement element)
    {
        return new Spinner(element);
    }

    /// <summary>
    /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="Spinner"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="AppiumWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Spinner"/>.
    /// </returns>
    public static implicit operator Spinner(AppiumWebElement element)
    {
        return new Spinner(element as AndroidElement);
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Spinner"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Spinner"/>.
    /// </returns>
    public static implicit operator Spinner(RemoteWebElement element)
    {
        return new Spinner(element as AndroidElement);
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
        this.Click();

        var locator =
            new ByAndroidUIAutomator(
                $"new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().text(\"{name}\"));");
        AndroidElement item = this.Driver.FindElement(locator);

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
        this.Click();

        var locator =
            new ByAndroidUIAutomator(
                $"new UiScrollable(new UiSelector()).scrollIntoView(new UiSelector().textContains(\"{partialName}\"));");
        AndroidElement item = this.Driver.FindElement(locator);

        item.Click();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private string GetSelectedItem()
    {
        TextView textElement = this.FindElement(By.ClassName("android.widget.TextView"));
        return textElement.Text;
    }
}