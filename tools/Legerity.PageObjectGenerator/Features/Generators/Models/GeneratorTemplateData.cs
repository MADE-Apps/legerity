namespace Legerity.Features.Generators.Models;

internal class GeneratorTemplateData
{
    public GeneratorTemplateData(string ns, string page, string baseElementType)
    {
        this.Namespace = ns;
        this.Page = page;
        this.Type = baseElementType;
    }

    public string Page { get; set; }

    public string Type { get; set; }

    public string Namespace { get; set; }

    public UiElement Trait { get; set; }

    public List<UiElement> Elements { get; set; } = new();

    public List<string> AdditionalUsings { get; set; } = new();

    public override string ToString()
    {
        return $"[Page] {this.Page};";
    }
}