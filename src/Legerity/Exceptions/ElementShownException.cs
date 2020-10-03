namespace Legerity.Exceptions
{
    /// <summary>
    /// Defines an exception for when an element is shown when it shouldn't be.
    /// </summary>
    public class ElementShownException : LegerityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementShownException"/> class.
        /// </summary>
        /// <param name="elementName">
        /// The name of the element that was shown.
        /// </param>
        public ElementShownException(string elementName)
            : base($"'{elementName}' is shown when it shouldn't")
        {
            this.ElementName = elementName;
        }

        /// <summary>
        /// Gets the name of the element that was shown.
        /// </summary>
        public string ElementName { get; }
    }
}