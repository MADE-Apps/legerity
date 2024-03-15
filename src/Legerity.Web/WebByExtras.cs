namespace Legerity.Web;

/// <summary>
/// Defines a collection of extra locator constraints for <see cref="By"/>.
/// </summary>
public static class WebByExtras
{
    /// <summary>
    /// Gets a mechanism to find elements by the HTML input tag with a specified type.
    /// </summary>
    /// <param name="inputType">The input type to find.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By InputType(string inputType)
    {
        return By.XPath($"//input[@type='{inputType}']");
    }

    /// <summary>
    /// Gets a mechanism to find elements by the HTML li tag.
    /// </summary>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By ListItem()
    {
        return By.TagName("li");
    }

    /// <summary>
    /// Gets a mechanism to find elements by the HTML option tag.
    /// </summary>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By Option()
    {
        return By.TagName("option");
    }

    /// <summary>
    /// Gets a mechanism to find elements by the HTML th tag.
    /// </summary>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By TableHeaderCell()
    {
        return By.TagName("th");
    }

    /// <summary>
    /// Gets a mechanism to find elements by the HTML tr tag.
    /// </summary>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By TableRow()
    {
        return By.TagName("tr");
    }

    /// <summary>
    /// Gets a mechanism to find table row elements where a HTML tr tag has HTML td elements within it.
    /// </summary>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By TableDataRow()
    {
        return By.XPath("//tr[td]");
    }
}
