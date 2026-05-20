namespace Legerity.Infrastructure.Extensions;

internal static class StringExtensions
{
    internal static string Capitalize(this string value)
    {
        return value.First().ToString().ToUpper() + value[1..];
    }
}