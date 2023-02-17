namespace Legerity.Web;

/// <summary>
/// Defines the values associated with the web app driver type.
/// </summary>
public enum WebAppDriverType
{
    /// <summary>
    /// None. Setting this will cause the application driver to not start.
    /// </summary>
    None,

    /// <summary>
    /// Chrome. Setting this will cause the application driver to launch for Google Chrome.
    /// </summary>
    Chrome,

    /// <summary>
    /// Firefox. Setting this will cause the application driver to launch for Mozilla Firefox.
    /// </summary>
    Firefox,

    /// <summary>
    /// Opera. Setting this will cause the application driver to launch for Opera.
    /// </summary>
    Opera,

    /// <summary>
    /// Safari. Setting this will cause the application driver to launch for Apple's Safari.
    /// </summary>
    Safari,

    /// <summary>
    /// Edge. Setting this will cause the application driver to launch for Microsoft's Legacy Edge.
    /// </summary>
    Edge,

    /// <summary>
    /// Internet Explorer. This will cause the application driver to launch for Microsoft's Internet Explorer.
    /// </summary>
    InternetExplorer,

    /// <summary>
    /// Edge Chromium. Setting this will cause the application driver to launch for Microsoft's Chromium Edge.
    /// </summary>
    EdgeChromium,
}