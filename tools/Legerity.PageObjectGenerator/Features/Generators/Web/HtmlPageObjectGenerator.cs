using System.Text;
using HtmlAgilityPack;
using Legerity.Features.Generators.Models;
using Legerity.Infrastructure.Extensions;
using Legerity.Infrastructure.IO;
using MADE.Collections.Compare;
using MADE.Data.Validation.Extensions;
using Scriban;
using Serilog;

namespace Legerity.Features.Generators.Web;

internal class HtmlPageObjectGenerator : IPageObjectGenerator
{
    private const string BaseElementType = "WebElementWrapper";

    private static readonly GenericEqualityComparer<string> SimpleStringComparer = new(s => s.ToLower());

    private static readonly Dictionary<string, string> InputTypeToElementMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "text", "TextInput" },
        { "email", "TextInput" },
        { "password", "TextInput" },
        { "search", "TextInput" },
        { "tel", "TextInput" },
        { "url", "TextInput" },
        { "checkbox", "CheckBox" },
        { "radio", "RadioButton" },
        { "number", "NumberInput" },
        { "range", "RangeInput" },
        { "date", "DateInput" },
        { "file", "FileInput" },
        { "button", "Button" },
        { "submit", "Button" },
        { "reset", "Button" }
    };

    private static readonly Dictionary<string, string> TagToElementMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "button", "Button" },
        { "select", "Select" },
        { "textarea", "TextArea" },
        { "img", "Image" },
        { "table", "Table" },
        { "form", "Form" },
        { "ul", "List" },
        { "ol", "List" }
    };

    public async Task GenerateAsync(string ns, string inputPath, string outputPath)
    {
        IEnumerable<string>? filePaths = GetHtmlFilePaths(inputPath)?.ToList();

        if (filePaths == null || !filePaths.Any())
        {
            Log.Warning("No HTML files found in {InputPath}", inputPath);
            return;
        }

        foreach (var filePath in filePaths)
        {
            Log.Information($"Processing {filePath}...");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            if (doc.DocumentNode == null)
            {
                Log.Warning($"Skipping {filePath} as the document could not be parsed");
                continue;
            }

            var templateData =
                new GeneratorTemplateData(ns, Path.GetFileNameWithoutExtension(filePath).Capitalize(), BaseElementType);

            Log.Information($"Generating template for {templateData}...");

            var allElements = doc.DocumentNode.Descendants()
                .Where(n => n.NodeType == HtmlNodeType.Element);

            foreach (var element in allElements)
            {
                var id = element.GetAttributeValue("id", null);
                var name = element.GetAttributeValue("name", null);
                var dataTestId = element.GetAttributeValue("data-testid", null);

                var byLocatorType = GetByLocatorType(id, name, dataTestId);
                if (byLocatorType == null || byLocatorType.IsNullOrWhiteSpace())
                {
                    continue;
                }

                string? byQueryValue;
                if (byLocatorType == "Id")
                {
                    byQueryValue = id;
                }
                else if (byLocatorType == "Name")
                {
                    byQueryValue = name;
                }
                else
                {
                    byQueryValue = dataTestId;
                }

                if (byQueryValue == null || byQueryValue.IsNullOrWhiteSpace())
                {
                    continue;
                }

                var elementType = GetElementWrapperType(element);

                var uiElement = new UiElement(
                    elementType,
                    byQueryValue.Capitalize(),
                    byLocatorType,
                    byQueryValue);

                Log.Information($"Element found on page - {uiElement}");

                templateData.Trait ??= uiElement;
                templateData.Elements.Add(uiElement);
            }

            if (templateData.Elements.Count > 0)
            {
                await GeneratePageObjectClassFileAsync(templateData, outputPath).ConfigureAwait(false);
            }
            else
            {
                Log.Warning($"Skipping {filePath} as no identifiable elements were found");
            }
        }
    }

    private static async Task GeneratePageObjectClassFileAsync(
        GeneratorTemplateData templateData,
        string outputFolder)
    {
        var pageObjectTemplate = Template.Parse(
            await EmbeddedResourceLoader.ReadAsync("Legerity.Templates.WebPageObject.template")
                .ConfigureAwait(false));

        var outputFile = $"{templateData.Page}.cs";

        Log.Information($"Generating {outputFile} page object file...");
        var result = await pageObjectTemplate.RenderAsync(templateData).ConfigureAwait(false);

        FileStream output = File.Create(Path.Combine(outputFolder, outputFile));
        var outputWriter = new StreamWriter(output, Encoding.UTF8);

        await using (outputWriter)
        {
            await outputWriter.WriteAsync(result).ConfigureAwait(false);
        }
    }

    private static string? GetByLocatorType(string? id, string? name, string? dataTestId)
    {
        if (id != null && !id.IsNullOrWhiteSpace())
        {
            return "Id";
        }

        if (name != null && !name.IsNullOrWhiteSpace())
        {
            return "Name";
        }

        return dataTestId != null && !dataTestId.IsNullOrWhiteSpace() ? "DataTestId" : null;
    }

    private static IEnumerable<string>? GetHtmlFilePaths(string searchFolder)
    {
        string[]? filePaths = default;

        try
        {
            var htmlFiles = Directory.GetFiles(searchFolder, "*.html", SearchOption.AllDirectories);
            var htmFiles = Directory.GetFiles(searchFolder, "*.htm", SearchOption.AllDirectories);
            filePaths = htmlFiles.Concat(htmFiles).ToArray();
        }
        catch (UnauthorizedAccessException)
        {
            Log.Error("An error occurred while retrieving HTML files for processing");
        }

        return filePaths;
    }

    private static string GetElementWrapperType(HtmlNode element)
    {
        var tagName = element.Name.ToLowerInvariant();

        if (tagName == "input")
        {
            var inputType = element.GetAttributeValue("type", "text");
            return InputTypeToElementMap.TryGetValue(inputType, out var mappedType) ? mappedType : "TextInput";
        }

        return TagToElementMap.TryGetValue(tagName, out var elementType) ? elementType : BaseElementType;
    }
}
