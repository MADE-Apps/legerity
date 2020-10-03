namespace Legerity.Exceptions
{
    /// <summary>
    /// Defines an exception for when an element is not shown.
    /// </summary>
    public class ElementNotShownException : LegerityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementNotShownException"/> class.
        /// </summary>
        /// <param name="elementName">
        /// The name of the element that was not shown.
        /// </param>
        public ElementNotShownException(string elementName)
            : base($"'{elementName}' is not shown when it should")
        {
            this.ElementName = elementName;
        }

        /// <summary>
        /// Gets the name of the element that was not shown.
        /// </summary>
        public string ElementName { get; }
    }
}