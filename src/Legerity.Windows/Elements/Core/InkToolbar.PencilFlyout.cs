namespace Legerity.Windows.Elements.Core;

/// <summary>
/// Defines the pencil flyout components of the <see cref="InkToolbar"/>.
/// </summary>
public partial class InkToolbar
{
    /// <summary>
    /// Defines a color flyout for the pencil in the <see cref="InkToolbar"/>.
    /// </summary>
    public class InkToolbarPencilFlyout : InkToolbarColorFlyoutBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Legerity.Windows.Elements.Core.InkToolbar.InkToolbarPencilFlyout"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WebElement"/> reference.
        /// </param>
        public InkToolbarPencilFlyout(WebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WebElement"/> to the <see cref="InkToolbarPencilFlyout"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbarPencilFlyout"/>.
        /// </returns>
        public static implicit operator InkToolbarPencilFlyout(WebElement element)
        {
            return new InkToolbarPencilFlyout(element);
        }
    }
}