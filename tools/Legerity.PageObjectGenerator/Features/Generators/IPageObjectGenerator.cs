namespace Legerity.Features.Generators;

using System.Threading.Tasks;

internal interface IPageObjectGenerator
{
    Task GenerateAsync(string ns, string inputPath, string outputPath);
}