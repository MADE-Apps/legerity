namespace Legerity.Extensions
{
    using System.Globalization;

    /// <summary>
    /// Defines a collection of extensions for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified value contains the comparison value by the specified culture and comparison option.
        /// </summary>
        /// <param name="value">
        /// The value to check contains the <paramref name="contains"/> value.
        /// </param>
        /// <param name="contains">
        /// The value that should be contained within the <paramref name="value"/>.
        /// </param>
        /// <param name="culture">
        /// The culture for comparison.
        /// </param>
        /// <param name="compareOption">
        /// The comparison option.
        /// </param>
        /// <returns>
        /// True if the <paramref name="value"/> contains the <paramref name="contains"/> value; otherwise, false.
        /// </returns>
        public static bool Contains(
            this string value,
            string contains,
            CultureInfo culture,
            CompareOptions compareOption)
        {
            if (value == null || contains == null)
            {
                return false;
            }

            return culture.CompareInfo.IndexOf(value, contains, compareOption) >= 0;
        }
    }
}