namespace Legerity.Web.Elements.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="IWebElement"/> wrapper for the core web Form control.
/// </summary>
public class Form : WebElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Form"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public Form(IWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Form"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public Form(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Form"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Form"/>.
    /// </returns>
    public static implicit operator Form(RemoteWebElement element)
    {
        return new Form(element);
    }
}