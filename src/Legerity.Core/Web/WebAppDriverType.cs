// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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
    /// Safari. Setting this will cause the application driver to launch for Apple's Safari.
    /// </summary>
    Safari,

    /// <summary>
    /// Edge. Setting this will cause the application driver to launch for Microsoft Edge.
    /// </summary>
    Edge,
}