using System.Text;
using System.Xml.Linq;
using Legerity.Features.Generators.Models;
using Legerity.Infrastructure.Extensions;
using Legerity.Infrastructure.IO;
using MADE.Collections.Compare;
using MADE.Data.Validation.Extensions;
using Scriban;
using Serilog;

namespace Legerity.Features.Generators.IOS;

internal class StoryboardPageObjectGenerator : IPageObjectGenerator
{
    private const string BaseElementType = "IOSElementWrapper";

    private static readonly GenericEqualityComparer<string> SimpleStringComparer = new(s => s.ToLower());

    public static IEnumerable<string> SupportedCoreIOSElements => new List<string>
    {
        "button",
        "label",
        "textField",
        "slider",
        "switch",
        "progressView"
    };

    private static readonly Dictionary<string, string> ElementNameMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "button", "Button" },
        { "label", "Label" },
        { "textField", "TextField" },
        { "slider", "Slider" },
        { "switch", "Switch" },
        { "progressView", "ProgressView" }
    };

    public async Task GenerateAsync(string ns, string inputPath, string outputPath)
    {
        IEnumerable<string>? filePaths = GetStoryboardFilePaths(inputPath)?.ToList();

        if (filePaths == null || !filePaths.Any())
        {
            Log.Warning("No Storyboard or XIB files found in {InputPath}", inputPath);
            return;
        }

        foreach (var filePath in filePaths)
        {
            Log.Information($"Processing {filePath}...");

            await using FileStream fileStream = File.Open(filePath, FileMode.Open);
            var doc = XDocument.Load(fileStream);

            if (doc.Root == null)
            {
                Log.Warning($"Skipping {filePath} as the document could not be parsed");
                continue;
            }

            var scenes = doc.Root.Descendants("scene").ToList();
            if (scenes.Count == 0)
            {
                // XIB files may not have scenes; process the root directly
                await ProcessElementTree(
                    ns,
                    Path.GetFileNameWithoutExtension(filePath),
                    doc.Root,
                    outputPath).ConfigureAwait(false);
            }
            else
            {
                foreach (var scene in scenes)
                {
                    var viewController = scene.Descendants()
                        .FirstOrDefault(e => e.Name.LocalName.EndsWith("ViewController", StringComparison.OrdinalIgnoreCase)
                                             || e.Name.LocalName == "viewController");

                    if (viewController == null)
                    {
                        continue;
                    }

                    var customClass = viewController.Attribute("customClass")?.Value;
                    var pageName = customClass ?? Path.GetFileNameWithoutExtension(filePath);

                    await ProcessElementTree(ns, pageName, viewController, outputPath)
                        .ConfigureAwait(false);
                }
            }
        }
    }

    private static async Task ProcessElementTree(string ns, string pageName, XElement root, string outputPath)
    {
        var templateData = new GeneratorTemplateData(ns, pageName.Capitalize(), BaseElementType);

        Log.Information($"Generating template for {templateData}...");

        IEnumerable<XElement> elements = FlattenElements(root.Elements());
        foreach (XElement element in elements)
        {
            var accessibilityId = element.Attribute("accessibilityIdentifier")?.Value;
            var label = element.Attribute("label")?.Value;
            var text = element.Attribute("text")?.Value;

            var byLocatorType = GetByLocatorType(accessibilityId, label, text);
            if (byLocatorType == null || byLocatorType.IsNullOrWhiteSpace())
            {
                continue;
            }

            string? byQueryValue;
            if (byLocatorType == "AccessibilityId")
            {
                byQueryValue = accessibilityId;
            }
            else
            {
                byQueryValue = label ?? text;
            }

            if (byQueryValue == null || byQueryValue.IsNullOrWhiteSpace())
            {
                continue;
            }

            var uiElement = new UiElement(
                GetElementWrapperType(element.Name.LocalName),
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
            Log.Warning($"Skipping {pageName} as no identifiable elements were found");
        }
    }

    private static async Task GeneratePageObjectClassFileAsync(
        GeneratorTemplateData templateData,
        string outputFolder)
    {
        var pageObjectTemplate = Template.Parse(
            await EmbeddedResourceLoader.ReadAsync("Legerity.Templates.IOSPageObject.template")
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

    private static string? GetByLocatorType(string? accessibilityId, string? label, string? text)
    {
        if (accessibilityId != null && !accessibilityId.IsNullOrWhiteSpace())
        {
            return "AccessibilityId";
        }

        return (label != null && !label.IsNullOrWhiteSpace()) || (text != null && !text.IsNullOrWhiteSpace())
            ? "Label"
            : null;
    }

    private static IEnumerable<string>? GetStoryboardFilePaths(string searchFolder)
    {
        string[]? filePaths = default;

        try
        {
            var storyboardFiles = Directory.GetFiles(searchFolder, "*.storyboard", SearchOption.AllDirectories);
            var xibFiles = Directory.GetFiles(searchFolder, "*.xib", SearchOption.AllDirectories);
            filePaths = storyboardFiles.Concat(xibFiles).ToArray();
        }
        catch (UnauthorizedAccessException)
        {
            Log.Error("An error occurred while retrieving Storyboard/XIB files for processing");
        }

        return filePaths;
    }

    private static string GetElementWrapperType(string elementName)
    {
        return ElementNameMap.TryGetValue(elementName, out var mappedType) ? mappedType : BaseElementType;
    }

    private static IEnumerable<XElement> FlattenElements(IEnumerable<XElement> elements)
    {
        return elements.SelectMany(c => FlattenElements(c.Elements())).Concat(elements);
    }
}
