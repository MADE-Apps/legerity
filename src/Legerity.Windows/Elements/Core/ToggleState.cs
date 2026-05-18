// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines the states of a toggle in a Windows element.
/// </summary>
public enum ToggleState
{
    /// <summary>
    /// The toggle is not checked.
    /// </summary>
    Unchecked = 0,

    /// <summary>
    /// The toggle is checked.
    /// </summary>
    Checked = 1,

    /// <summary>
    /// The toggle is indeterminate.
    /// </summary>
    Indeterminate = 2,
}