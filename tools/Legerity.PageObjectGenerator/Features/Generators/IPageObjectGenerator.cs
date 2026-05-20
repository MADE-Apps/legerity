namespace Legerity.Features.Generators;

internal interface IPageObjectGenerator
{
    Task GenerateAsync(string ns, string inputPath, string outputPath);
}