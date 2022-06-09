namespace Legerity.Web
{
    using OpenQA.Selenium;

    /// <summary>
    /// Defines a collection of extra locator constraints for <see cref="By"/>.
    /// </summary>
    public static class WebByExtras
    {
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
    }
}