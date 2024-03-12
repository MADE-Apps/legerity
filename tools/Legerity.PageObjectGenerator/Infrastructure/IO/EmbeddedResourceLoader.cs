namespace Legerity.Infrastructure.IO
{
    using System.Reflection;

    internal static class EmbeddedResourceLoader
    {
        internal static Task<string?> ReadAsync(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(fileName);
            if (stream == null)
            {
                return Task.FromResult(default(string));
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEndAsync()!;
        }
    }
}
