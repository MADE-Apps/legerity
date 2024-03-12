namespace Legerity.Features.Generators.Models;

using System.Collections.Generic;

internal class GeneratorTemplateData
{
    public GeneratorTemplateData(string ns, string page, string baseElementType)
    {
        Namespace = ns;
        Page = page;
        Type = baseElementType;
    }

    public string Page { get; set; }

    public string Type { get; set; }

    public string Namespace { get; set; }

    public UiElement Trait { get; set; }

    public List<UiElement> Elements { get; set; } = new();

    public override string ToString()
    {
        return $"[Page] {Page};";
    }
}