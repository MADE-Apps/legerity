namespace Legerity.Features.Generators.Android;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Infrastructure.IO;
using Generators;
using Models;
using Infrastructure.Extensions;
using MADE.Collections.Compare;
using MADE.Data.Validation.Extensions;
using Scriban;
using Serilog;

internal class AxmlPageObjectGenerator : IPageObjectGenerator
{
    private const string AndroidNamespace = "http://schemas.android.com/apk/res/android";

    private const string BaseElementType = "AndroidElement";

    private static readonly GenericEqualityComparer<string> SimpleStringComparer = new(s => s.ToLower());

    public static IEnumerable<string> SupportedCoreAndroidElements => new List<string>
    {
        "Button",
        "CheckBox",
        "DatePicker",
        "EditText",
        "RadioButton",
        "Spinner",
        "Switch",
        "TextView",
        "ToggleButton",
        "View"
    };

    public async Task GenerateAsync(string ns, string inputPath, string outputPath)
    {
        IEnumerable<string>? filePaths = GetAxmlFilePaths(inputPath)?.ToList();

        if (filePaths == null || !filePaths.Any())
        {
            Log.Warning("No AXML files found in {InputPath}", inputPath);
            return;
        }

        foreach (var filePath in filePaths)
        {
            Log.Information($"Processing {filePath}...");

            await using var fileStream = File.Open(filePath, FileMode.Open);
            var axml = XDocument.Load(fileStream);

            if (axml.Root != null)
            {
                var templateData =
                    new GeneratorTemplateData(ns, Path.GetFileNameWithoutExtension(filePath), BaseElementType);

                Log.Information($"Generating template for {templateData}...");

                IEnumerable<XElement> elements = FlattenElements(axml.Root.Elements());
                foreach (var element in elements)
                {
                    var id = RemoveAndroidIdReference(element.Attribute(XName.Get("id", AndroidNamespace))?.Value);
                    var contentDesc = element.Attribute(XName.Get("contentDescription", AndroidNamespace))?.Value;

                    var byLocatorType = GetByLocatorType(id, contentDesc);
                    if (byLocatorType == null || byLocatorType.IsNullOrWhiteSpace())
                    {
                        continue;
                    }

                    var byQueryValue = id ?? contentDesc;
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

                    templateData.Trait = uiElement;
                    templateData.Elements.Add(uiElement);
                }

                await GeneratePageObjectClassFileAsync(templateData, outputPath);
            }
            else
            {
                Log.Warning($"Skipping {filePath} as a page was not detected");
            }
        }
    }

    private static string? RemoveAndroidIdReference(string? value)
    {
        return value == null || string.IsNullOrWhiteSpace(value)
            ? null
            : value.Replace("+", string.Empty).Replace("@id/", string.Empty);
    }

    private static async Task GeneratePageObjectClassFileAsync(
        GeneratorTemplateData templateData,
        string outputFolder)
    {
        var pageObjectTemplate = Template.Parse(await EmbeddedResourceLoader.ReadAsync("Legerity.Templates.AndroidPageObject.template"));

        var outputFile = $"{templateData.Page}.cs";

        Log.Information($"Generating {outputFile} page object file...");
        var result = await pageObjectTemplate.RenderAsync(templateData);

        var output = File.Create(Path.Combine(outputFolder, outputFile));
        var outputWriter = new StreamWriter(output, Encoding.UTF8);

        await using (outputWriter)
        {
            await outputWriter.WriteAsync(result);
        }
    }

    private static string? GetByLocatorType(string? id, string? contentDesc)
    {
        if (id != null && !id.IsNullOrWhiteSpace())
        {
            return "Id";
        }

        return contentDesc != null && !contentDesc.IsNullOrWhiteSpace() ? "AndroidContentDesc" : null;
    }

    private static IEnumerable<string>? GetAxmlFilePaths(string searchFolder)
    {
        string[]? filePaths = default;

        try
        {
            filePaths = Directory.GetFiles(searchFolder, "*.axml", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            Log.Error("An error occurred while retrieving AXML files for processing");
        }

        return filePaths;
    }

    private static string GetElementWrapperType(string elementName)
    {
        return SupportedCoreAndroidElements.Contains(elementName, SimpleStringComparer) ? elementName : BaseElementType;
    }

    private IEnumerable<XElement> FlattenElements(IEnumerable<XElement> elements)
    {
        return elements.SelectMany(c => FlattenElements(c.Elements())).Concat(elements);
    }
}
