namespace Legerity.Infrastructure.Extensions;

using System.Linq;

internal static class StringExtensions
{
    internal static string Capitalize(this string value)
    {
        return value.First().ToString().ToUpper() + value.Substring(1);
    }
}
